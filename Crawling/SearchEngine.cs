using Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawling
{
    public interface ISearchEngine
    {
        Task<string> SearchAsync(string keywords, string url);
    }

    public interface IClient
    {
        Task<string> GetAsync(string uri);
    }

    abstract class SearchEngine : ISearchEngine
    {
        private ICache _cache;
        private IClient _client;
        protected string HostUrl { get; }
        protected abstract string Query(string keywords, string url);
        protected abstract string Marker { get; }
        protected SearchEngine(string hostUrl, ICache cache, IClient http)
        {
            HostUrl = hostUrl;
            _cache = cache;
            _client = http;
        }


        public async Task<string> SearchAsync(string keywords, string url)
        {
            Validate(keywords, url);
            if (_cache.TryGet(keywords, url, out var result))
            {
                return result;
            }
            else
            {
                List<int> locations = new List<int>();

                var content = await _client.GetAsync(Query(keywords, url));
                var found = Regex.Matches(content, Marker);
                var indexes = found.Select(match => match.Index).Append(content.Length).ToArray();
                for (int i = 0; i < indexes.Length - 1; i++)
                {
                    var item = content.Substring(indexes[i], indexes[i + 1] - indexes[i]);
                    if (item.Contains(url)) locations.Add(i + 1);
                }
                var res = locations.Count == 0 ? "0" : string.Join(", ", locations);
                _cache.Put(keywords, url, res);
                return res;
            }
        }
        void Validate(string keywords, string url)
        {
            if (string.IsNullOrWhiteSpace(keywords)) throw new ArgumentException($"Parameter must be non empty string", nameof(keywords));
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentException($"Parameter must be non empty string", nameof(url));
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    class SearchEngineFutureAttribute : Attribute { }
    
    class GoogleSearchEngine : SearchEngine
    {
        public GoogleSearchEngine(ICache cache, IClient client) : base(@"https://www.google.com", cache, client) {}

        protected override string Query(string keywords, string url) => $@"{ HostUrl}/search?q={keywords}&num=100";

        protected override string Marker => @"div class=""ZINbbc xpd O9g5cc uUPGi""";
    }


    [SearchEngineFuture]
    class BingSearchEngine : SearchEngine
    {
        public BingSearchEngine(ICache cache, IClient client) : base(@"https://www.bing.com", cache, client) { }

        protected override string Query(string keywords, string url)
        {
            throw new NotImplementedException();
        }

        protected override string Marker { get; }
    }

    public interface ISearchEngineDescriptor
    {
        string Name { get; }
        bool Available { get; }
        ISearchEngine Get();
    }


    public class SearchEngineFactory
    {
        ICacheFactory CacheFactory { get; }
        IClient Client { get; }

        record SearchEngineDescriptor(string Name, bool Available, Type Type, SearchEngineFactory Factory) : ISearchEngineDescriptor
        {
            ISearchEngine _instance;
            public ISearchEngine Get() => _instance ??= (ISearchEngine)Activator.CreateInstance(Type, new object[] { Factory.CacheFactory.Create(), Factory.Client });
            public override string ToString() => Name + (Available ? " (Available)" : " (Implementation in Progress)");
        }

        public ISearchEngineDescriptor[] Engines { get; }
        public SearchEngineFactory(ICacheFactory cacheFactory, IClient client)
        {
            CacheFactory = cacheFactory;
            Client = client;
            Engines =
                Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(SearchEngine)))
                .Select(t => new SearchEngineDescriptor(t.Name, IsAvailable(t), t, this))
                .ToArray();

            bool IsAvailable(Type t) => t.GetCustomAttribute<SearchEngineFutureAttribute>() == null;
        }
    }
}
