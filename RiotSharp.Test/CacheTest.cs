using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RiotSharp.Caching;

namespace RiotSharp.Test
{
    [TestClass]
    public class CacheTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory("Cache")]
        public void AddGet_TimeSpan_ShouldAddToTheCache_ReturnTrue()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 5, 0));

            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void AddGet_TimeSpan_ShouldAddAndExpire_ReturnTrue()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            Thread.Sleep(2000);
            Assert.IsNull(cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void AddGet_DateTime_ShouldAdd_ReturnTheTestValue()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, DateTime.Now + new TimeSpan(0, 5, 0));

            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void AddGet_DateTime_ShouldAddAndExpire_ReturnTrue()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, DateTime.Now + new TimeSpan(0, 0, 1));

            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            Thread.Sleep(2000);
            Assert.IsNull(cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Add_ShouldUpdateIfPresent_ReturnUpdatedValue()
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
        public void Remove_ShouldDoNothingIfNull_ReturnDontThrowExceptionIfNull()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            cache.Remove<string>(null);
            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Remove_ShouldDoNothingIfAbsent_ReturnNull()
        {
            Cache cache = new Cache();
            cache.Remove(CacheTestBase.TestKey);

            cache.Get<string, string>(CacheTestBase.TestKey);
            Assert.IsNull(cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Remove_ShouldRemoveIfPresent_ReturnNull()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            cache.Remove(CacheTestBase.TestKey);
            Assert.IsNull(cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Clear_ShouldRemoveAll_ReturnNull()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            Assert.AreEqual(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            cache.Clear();
            Assert.IsNull(cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Keys_ShouldGetAllKeysOfType_ReturnOneKeyTypeAndTheTestKey()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));
            cache.Add(1, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            var keysOfTypeString = cache.Keys<string>().ToList();
            Assert.AreEqual(1, keysOfTypeString.Count);
            Assert.AreEqual(CacheTestBase.TestKey, keysOfTypeString.First());
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Keys_ShouldGetEmptyOfTypeIfNoMatches_ReturnTrue()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));
            cache.Add(1, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            var keysOfTypeFloat = cache.Keys<float>().ToList();
            Assert.IsTrue(Enumerable.Empty<float>().SequenceEqual(keysOfTypeFloat));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Keys_ShouldGetAllKeys_ReturnContainTwoKeysAndTestKey()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));
            cache.Add(1, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            var keys = cache.Keys().ToList();
            Assert.AreEqual(2, keys.Count);
            Assert.IsTrue((new List<object> { CacheTestBase.TestKey, 1 }).SequenceEqual(keys));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Keys_ShouldGetEmptyIfEmptyCache_ReturnTrue()
        {
            Cache cache = new Cache();
            Assert.IsTrue(Enumerable.Empty<object>().SequenceEqual(cache.Keys()));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Values_ShouldGetAllValuesOfType_ReturnContainOneTestKey()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));
            cache.Add(1, new List<int> { 1 }, new TimeSpan(0, 0, 1));

            var valuesOfTypeString = cache.Values<string>().ToList();
            Assert.AreEqual(1, valuesOfTypeString.Count);
            Assert.AreEqual(CacheTestBase.TestValue, valuesOfTypeString.First());
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Values_ShouldGetEmptyOfTypeIfNoMatches_ReturnTrue()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));
            cache.Add(1, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            var valuesOfTypeListInt = cache.Values<List<int>>().ToList();
            Assert.IsTrue(Enumerable.Empty<List<int>>().SequenceEqual(valuesOfTypeListInt));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Values_ShouldGetAllValues_ReturnContainTwoTestValues()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));
            cache.Add(1, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            var values = cache.Values().ToList();
            Assert.AreEqual(2, values.Count);
            Assert.IsTrue((new List<object> { CacheTestBase.TestValue, CacheTestBase.TestValue }).SequenceEqual(values));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Values_ShouldGetEmptyIfEmptyCache_ReturnTrue()
        {
            Cache cache = new Cache();
            Assert.IsTrue(Enumerable.Empty<object>().SequenceEqual(cache.Values()));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Count_ShouldGiveProperResults_ReturnTheCorrectCounts()
        {
            Cache cache = new Cache();

            Assert.AreEqual(0, cache.Count());
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 5, 0));
            Assert.AreEqual(1, cache.Count());
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 5, 0));
            Assert.AreEqual(1, cache.Count());
            cache.Add("otherKey", CacheTestBase.TestValue, new TimeSpan(0, 5, 0));
            Assert.AreEqual(2, cache.Count());
        }
    }
}
