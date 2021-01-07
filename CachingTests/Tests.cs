using Caching;
using System;
using System.Threading;
using Xunit;

namespace CachingTests
{
    public class Tests
    {
        [Fact]
        public void Accepts_and_retrieves_item()
        {
            var cache = new Cache.Factory().Create();
            cache.Put("Key", "Url", "Result");
            Assert.True(cache.TryGet("Key", "Url", out var result));
            Assert.Equal("Result", result);
        }

        [Fact]
        public void Item_not_cached()
        {
            var cache = new Cache.Factory().Create();
            cache.Put("Key", "Url", "Result");
            Assert.False(cache.TryGet("Key1", "Url", out var result));
            Assert.Null(result);
        }

        [Fact]
        public void Empty_cache()
        {
            var cache = new Cache.Factory().Create();
            Assert.False(cache.TryGet("Key", "Url", out var _));
        }

        [Fact]
        public void Wrong_parameters()
        {
            var cache = new Cache.Factory().Create();
            Assert.Throws<ArgumentException>("keywords", () => cache.Put("", "Url", "Result"));
            Assert.Throws<ArgumentException>("url", () => cache.Put("Key", null, "Result"));
            Assert.Throws<ArgumentException>("result", () => cache.Put("Key", "Url", " \t"));
            Assert.Throws<ArgumentException>("keywords", () => cache.TryGet("\n", "Url", out var _));
            Assert.Throws<ArgumentException>("url", () => cache.TryGet("Key", "   ", out var _));
        }

        [Fact]
        public void Time_Validity()
        {
            var span = TimeSpan.FromSeconds(3);
            var cache = new Cache.Factory().Create(span);
            cache.Put("Key", "Url", "Result");
            Assert.True(cache.TryGet("Key", "Url", out var result));
            Assert.Equal("Result", result);
            Thread.Sleep(span);
            Assert.False(cache.TryGet("Key", "Url", out var _));
            cache.Put("Key", "Url", "Result");
            Assert.True(cache.TryGet("Key", "Url", out var _));
        }
    }
}
