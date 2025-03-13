using NUnit.Framework;
using RiotSharpNET8.Caching;
using System;

namespace RiotSharpNET8.Test.CacheTests
{
    [TestFixture]
    public class InMemoryCacheTest
    {
        private ICache _cache;

        [SetUp]
        public void SetUp()
        {
            _cache = new InMemoryCache();
        }

        [Test]
        public void Add_WithSlidingExpiration_ShouldAddToCache()
        {
            var key = "testKey";
            var value = "testValue";
            var slidingExpiration = TimeSpan.FromMinutes(5);

            _cache.Add(key, value, slidingExpiration);

            var cachedValue = _cache.Get<string, string>(key);
            Assert.That(cachedValue, Is.EqualTo(value));
        }

        [Test]
        public void Add_WithAbsoluteExpiration_ShouldAddToCache()
        {
            var key = "testKey";
            var value = "testValue";
            var absoluteExpiration = DateTime.Now.AddMinutes(5);

            _cache.Add(key, value, absoluteExpiration);

            var cachedValue = _cache.Get<string, string>(key);
            Assert.That(cachedValue, Is.EqualTo(value));
        }

        [Test]
        public void Get_WithNonExistentKey_ShouldReturnNull()
        {
            var key = "nonExistentKey";

            var cachedValue = _cache.Get<string, string>(key);
            Assert.That(cachedValue, Is.Null);
        }

        [Test]
        public void Remove_ShouldRemoveFromCache()
        {
            var key = "testKey";
            var value = "testValue";
            var slidingExpiration = TimeSpan.FromMinutes(5);

            _cache.Add(key, value, slidingExpiration);
            _cache.Remove(key);

            var cachedValue = _cache.Get<string, string>(key);
            Assert.That(cachedValue, Is.Null);
        }

        [Test]
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

            var cachedValue1 = _cache.Get<string, string>(key1);
            var cachedValue2 = _cache.Get<string, string>(key2);
            Assert.That(cachedValue1, Is.Null);
            Assert.That(cachedValue2, Is.Null);
        }

        [Test]
        public void Add_WithSlidingExpiration_ShouldExpire()
        {
            var key = "testKey";
            var value = "testValue";
            var slidingExpiration = TimeSpan.FromSeconds(1);

            _cache.Add(key, value, slidingExpiration);
            System.Threading.Thread.Sleep(2000);

            var cachedValue = _cache.Get<string, string>(key);
            Assert.That(cachedValue, Is.Null);
        }

        [Test]
        public void Add_WithAbsoluteExpiration_ShouldExpire()
        {
            var key = "testKey";
            var value = "testValue";
            var absoluteExpiration = DateTime.Now.AddSeconds(1);

            _cache.Add(key, value, absoluteExpiration);
            System.Threading.Thread.Sleep(2000);

            var cachedValue = _cache.Get<string, string>(key);
            Assert.That(cachedValue, Is.Null);
        }

        [Test]
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
            Assert.That(count, Is.EqualTo(2));
        }
    }
}
