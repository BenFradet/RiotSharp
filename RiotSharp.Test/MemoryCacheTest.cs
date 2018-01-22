using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using RiotSharp.Caching;

namespace RiotSharp.Test
{
    [TestClass]
    public class MemoryCacheTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory("Cache")]
        public void AddGet_TimeSpan_ShouldAddToTheCache_Test()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 5, 0));

            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void AddGet_TimeSpan_ShouldAddAndExpire_Test()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            Thread.Sleep(2000);
            Assert.IsNull(cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void AddGet_DateTime_ShouldAdd_Test()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, DateTime.Now + new TimeSpan(0, 5, 0));

            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void AddGet_DateTime_ShouldAddAndExpire_Test()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, DateTime.Now + new TimeSpan(0, 0, 1));

            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            Thread.Sleep(2000);
            Assert.IsNull(cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Add_ShouldUpdateIfPresent_Test()
        {
            Cache cache = new Cache();
            var otherValue = "otherValue";
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            cache.Add(CacheTestBase.TestKey, otherValue, new TimeSpan(0, 0, 1));
            Assert.AreEqual(otherValue, cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Remove_ShouldDoNothingIfNull_Test()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            cache.Remove<string>(null);
            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Remove_ShouldDoNothingIfAbsent_Test()
        {
            Cache cache = new Cache();
            cache.Remove(CacheTestBase.TestKey);
            Assert.IsNull(cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Remove_ShouldRemoveIfPresent_Test()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            cache.Remove(CacheTestBase.TestKey);
            Assert.IsNull(cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Clear_ShouldRemoveAll_Test()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            cache.Clear();
            Assert.IsNull(cache.Get<string, string>(CacheTestBase.TestKey));
        }
    }
}
