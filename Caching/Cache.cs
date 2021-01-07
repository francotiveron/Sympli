using System;
using System.Collections.Generic;

namespace Caching
{
    record CacheId(string Keywords, string Url);
    record CacheEntry(DateTime created, string Result);
    public interface ICache
    {
        bool TryGet(string keywords, string url, out string result);
        void Put(string keywords, string url, string result);
    }
    public interface ICacheFactory
    {
        ICache Create(TimeSpan? validityTimeSpan = null);
    }

    public class Cache : ICache
    {
        private Dictionary<CacheId, CacheEntry> store = new Dictionary<CacheId, CacheEntry>();
        private TimeSpan validity;

        Cache(TimeSpan? validityTimeSpan) {
            validity = validityTimeSpan ?? TimeSpan.FromHours(1);
        }

        public bool TryGet(string keywords, string url, out string result)
        {
            Validate(keywords, url);
            if (store.TryGetValue(new CacheId(keywords, url), out var entry)) {
                (DateTime created, string res) = entry;
                if (created > DateTime.Now - validity)
                {
                    result = res;
                    return true;
                }
            }
            result = null;
            return false;
        }

        public void Put(string keywords, string url, string result)
        {
            Validate(keywords, url, result);
            store[new CacheId(keywords, url)] = new CacheEntry(DateTime.Now, result);
        }

        void Validate(string keywords, string url)
        {
            if (string.IsNullOrWhiteSpace(keywords)) throw new ArgumentException($"Parameter must be non empty string", nameof(keywords));
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentException($"Parameter must be non empty string", nameof(url));
        }

        void Validate(string keywords, string url, string result)
        {
            Validate(keywords, url);
            if (string.IsNullOrWhiteSpace(result)) throw new ArgumentException($"Parameter must be non empty string", nameof(result));
        }

        public class Factory : ICacheFactory
        {
            public ICache Create(TimeSpan? validityTimeSpan = null) => new Cache(validityTimeSpan);
        }
    }

}
