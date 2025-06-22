using RiotSharp.Core.Caching;

namespace RiotSharp.Core.Tests.CacheTests
{
    public class InMemoryCacheTest
    {
        private readonly ICache _cache;

        public InMemoryCacheTest()
        {
            _cache = new InMemoryCache();
        }

        [Fact]
        public void Add_WithSlidingExpiration_ShouldAddToCache()
        {
            var key = "testKey";
            var value = "testValue";
            var slidingExpiration = TimeSpan.FromMinutes(5);

            _cache.Add(key, value, slidingExpiration);

            var cachedValue = _cache.Get<string, string>(key);
            Assert.Equal(value, cachedValue);
        }

        [Fact]
        public void Add_WithAbsoluteExpiration_ShouldAddToCache()
        {
            var key = "testKey";
            var value = "testValue";
            var absoluteExpiration = DateTime.Now.AddMinutes(5);

            _cache.Add(key, value, absoluteExpiration);

            var cachedValue = _cache.Get<string, string>(key);
            Assert.Equal(value, cachedValue);
        }

        [Fact]
        public void Get_WithNonExistentKey_ShouldReturnNull()
        {
            var key = "nonExistentKey";

            var cachedValue = _cache.Get<string, string>(key);
            Assert.Null(cachedValue);
        }

        [Fact]
        public void Remove_ShouldRemoveFromCache()
        {
            var key = "testKey";
            var value = "testValue";
            var slidingExpiration = TimeSpan.FromMinutes(5);

            _cache.Add(key, value, slidingExpiration);
            _cache.Remove(key);

            var cachedValue = _cache.Get<string, string>(key);
            Assert.Null(cachedValue);
        }

        [Fact]
        public void Clear_ShouldRemoveAllItemsFromCache()
        {
            var key1 = "testKey1";
            var value1 = "testValue1";
            var key2 = "testKey2";
            var value2 = "testValue2";
            var slidingExpiration = TimeSpan.FromMinutes(5);

            _cache.Add(key1, value1, slidingExpiration);
            _cache.Add(key2, value2, slidingExpiration);
            _cache.Clear();

            Assert.Null(_cache.Get<string, string>(key1));
            Assert.Null(_cache.Get<string, string>(key2));
        }

        [Fact]
        public void Add_WithSlidingExpiration_ShouldExpire()
        {
            var key = "testKey";
            var value = "testValue";
            var slidingExpiration = TimeSpan.FromSeconds(1);

            _cache.Add(key, value, slidingExpiration);
            Thread.Sleep(2000);

            var cachedValue = _cache.Get<string, string>(key);
            Assert.Null(cachedValue);
        }

        [Fact]
        public void Add_WithAbsoluteExpiration_ShouldExpire()
        {
            var key = "testKey";
            var value = "testValue";
            var absoluteExpiration = DateTime.Now.AddSeconds(1);

            _cache.Add(key, value, absoluteExpiration);
            Thread.Sleep(2000);

            var cachedValue = _cache.Get<string, string>(key);
            Assert.Null(cachedValue);
        }

        [Fact]
        public void Count_ShouldReturnCorrectNumberOfItems()
        {
            var key1 = "testKey1";
            var value1 = "testValue1";
            var key2 = "testKey2";
            var value2 = "testValue2";
            var slidingExpiration = TimeSpan.FromMinutes(5);

            _cache.Add(key1, value1, slidingExpiration);
            _cache.Add(key2, value2, slidingExpiration);

            var count = _cache.Count();
            Assert.Equal(2, count);
        }
    }
}
