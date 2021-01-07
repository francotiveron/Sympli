using Caching;
using Crawling;
using Moq;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CrawlingTests
{
    public class Tests
    {
        SearchEngineFactory factory;
        string response;
        string Respond(string uri) => response;
        public Tests()
        {
            var mock = new Mock<IClient>();
            mock.Setup(client => client.GetAsync(It.IsAny<string>())).ReturnsAsync((Func<string, string>)Respond);
            var client = mock.Object;
            factory = new SearchEngineFactory(new Cache.Factory(), client);
        }

        [Fact]
        public void Engines_are_found()
        {
            var engines = factory.Engines;
            Assert.Contains(engines, engine => engine.Name.Contains("Google") && engine.Available);
            Assert.Contains(engines, engine => engine.Name.Contains("Bing") && !engine.Available);
        }

        [Fact]
        public async Task Find_3_Occurrences()
        {
            var engine = factory.Engines.First(e => e.Available).Get();
            response = response_3_Occurrences;
            var result = await engine.SearchAsync("Keyword", @"https://www.acme.com");
            Assert.Equal("2, 3, 6", result);
        }

        [Fact]
        public async Task Find_0_Occurrences()
        {
            var engine = factory.Engines.First(e => e.Available).Get();
            response = response_0_Occurrences;
            var result = await engine.SearchAsync("Keyword", @"https://www.acme.com");
            Assert.Equal("0", result);
        }

        [Fact]
        public async Task Null_parameters()
        {
            var engine = factory.Engines.First(e => e.Available).Get();
            response = response_0_Occurrences;
            await Assert.ThrowsAsync<ArgumentException>("keywords", () => engine.SearchAsync(null, @"https://www.acme.com"));
            await Assert.ThrowsAsync<ArgumentException>("url", () => engine.SearchAsync("Keyword", null));
        }

        [Fact]
        public async Task Future_engine()
        {
            var engine = factory.Engines.First(e => !e.Available).Get();
            response = response_0_Occurrences;
            await Assert.ThrowsAsync<NotImplementedException>(() => engine.SearchAsync("Keyword", @"https://www.acme.com"));
        }

        const string response_3_Occurrences =
            @"
            div class=""ZINbbc xpd O9g5cc uUPGi""
            Item without
            div class=""ZINbbc xpd O9g5cc uUPGi""
            Item with https://www.acme.com
            div class=""ZINbbc xpd O9g5cc uUPGi""
            Item with https://www.acme.com
            div class=""ZINbbc xpd O9g5cc uUPGi""
            Item without
            div class=""ZINbbc xpd O9g5cc uUPGi""
            div class=""ZINbbc xpd O9g5cc uUPGi""            
            Item with https://www.acme.com
            ";

        const string response_0_Occurrences =
            @"
            div class=""ZINbbc xpd O9g5cc uUPGi""
            Item without
            div class=""ZINbbc xpd O9g5cc uUPGi""
            Item without
            div class=""ZINbbc xpd O9g5cc uUPGi""
            Item without
            div class=""ZINbbc xpd O9g5cc uUPGi""
            Item without
            div class=""ZINbbc xpd O9g5cc uUPGi""
            div class=""ZINbbc xpd O9g5cc uUPGi""            
            ";
    }
}
