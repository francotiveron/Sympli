using Caching;
using Crawling;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Exactly 2 parameters are required (KEYWORDS and URL)");
                Console.WriteLine("Example: ConsoleApp \"e-settlements\" www.sympli.com");
                return -1;
            }

            var descriptors = new SearchEngineFactory(new Cache.Factory(), new Client()).Engines;

            Console.WriteLine("Found Search Engines:");
            foreach (var d in descriptors) Console.WriteLine(d);

            var descriptor = descriptors.First(engine => engine.Available);
            Console.WriteLine($"Using First Available ({descriptor.Name})");
            var engine = descriptor.Get();
            var result = await engine.SearchAsync(args[0], args[1]);
            Console.WriteLine($"The URL {args[1]} has been found in the following results:" );
            Console.WriteLine(result);
            return 0;
        }
    }

    class Client : IClient
    {
        HttpClient _http = new HttpClient();
        public Task<string> GetAsync(string uri) => _http.GetStringAsync(uri);
    }
}
