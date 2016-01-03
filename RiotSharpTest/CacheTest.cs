using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RiotSharpTest
{
    [TestClass]
    public class CacheTest
    {
        private const string TestKey = "testKey";
        private const string TestValue = "testValue";

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void AddGet_TimeSpan_ShouldAddToTheCache_Test()
        {
            Cache cache = new Cache();
            cache.Add(TestKey, TestValue, new TimeSpan(0, 5, 0));

            Assert.AreEqual(TestValue, cache.Get<string, string>(TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void AddGet_TimeSpan_ShouldAddAndExpire_Test()
        {
            Cache cache = new Cache();
            cache.Add(TestKey, TestValue, new TimeSpan(0, 0, 1));

            Assert.AreEqual(TestValue, cache.Get<string, string>(TestKey));
            Thread.Sleep(2000);
            Assert.IsNull(cache.Get<string, string>(TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void AddGet_DateTime_ShouldAdd_Test()
        {
            Cache cache = new Cache();
            cache.Add(TestKey, TestValue, DateTime.Now + new TimeSpan(0, 5, 0));

            Assert.AreEqual(TestValue, cache.Get<string, string>(TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void AddGet_DateTime_ShouldAddAndExpire_Test()
        {
            Cache cache = new Cache();
            cache.Add(TestKey, TestValue, DateTime.Now + new TimeSpan(0, 0, 1));

            Assert.AreEqual(TestValue, cache.Get<string, string>(TestKey));
            Thread.Sleep(2000);
            Assert.IsNull(cache.Get<string, string>(TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Add_ShouldUpdateIfPresent_Test()
        {
            Cache cache = new Cache();
            var otherValue = "otherValue";
            cache.Add(TestKey, TestValue, new TimeSpan(0, 0, 1));

            Assert.AreEqual(TestValue, cache.Get<string, string>(TestKey));
            cache.Add(TestKey, otherValue, new TimeSpan(0, 0, 1));
            Assert.AreEqual(otherValue, cache.Get<string, string>(TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Remove_ShouldDoNothingIfNull_Test()
        {
            Cache cache = new Cache();
            cache.Add(TestKey, TestValue, new TimeSpan(0, 0, 1));

            Assert.AreEqual(TestValue, cache.Get<string, string>(TestKey));
            cache.Remove<string>(null);
            Assert.AreEqual(TestValue, cache.Get<string, string>(TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Remove_ShouldDoNothingIfAbsent_Test()
        {
            Cache cache = new Cache();
            cache.Remove(TestKey);
            Assert.IsNull(cache.Get<string, string>(TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Remove_ShouldRemoveIfPresent_Test()
        {
            Cache cache = new Cache();
            cache.Add(TestKey, TestValue, new TimeSpan(0, 0, 1));

            Assert.AreEqual(TestValue, cache.Get<string, string>(TestKey));
            cache.Remove(TestKey);
            Assert.IsNull(cache.Get<string, string>(TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Clear_ShouldRemoveAll_Test()
        {
            Cache cache = new Cache();
            cache.Add(TestKey, TestValue, new TimeSpan(0, 0, 1));

            Assert.AreEqual(TestValue, cache.Get<string, string>(TestKey));
            cache.Clear();
            Assert.IsNull(cache.Get<string, string>(TestKey));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Keys_ShouldGetAllKeysOfType_Test()
        {
            Cache cache = new Cache();
            cache.Add(TestKey, TestValue, new TimeSpan(0, 0, 1));
            cache.Add(1, TestValue, new TimeSpan(0, 0, 1));

            var keysOfTypeString = cache.Keys<string>().ToList();
            Assert.AreEqual(1, keysOfTypeString.Count);
            Assert.AreEqual(TestKey, keysOfTypeString.First());
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Keys_ShouldGetEmptyOfTypeIfNoMatches_Test()
        {
            Cache cache = new Cache();
            cache.Add(TestKey, TestValue, new TimeSpan(0, 0, 1));
            cache.Add(1, TestValue, new TimeSpan(0, 0, 1));

            var keysOfTypeFloat = cache.Keys<float>().ToList();
            Assert.IsTrue(Enumerable.Empty<float>().SequenceEqual(keysOfTypeFloat));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Keys_ShouldGetAllKeys_Test()
        {
            Cache cache = new Cache();
            cache.Add(TestKey, TestValue, new TimeSpan(0, 0, 1));
            cache.Add(1, TestValue, new TimeSpan(0, 0, 1));

            var keys = cache.Keys().ToList();
            Assert.AreEqual(2, keys.Count);
            Assert.IsTrue((new List<object> { TestKey, 1 }).SequenceEqual(keys));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Keys_ShouldGetEmptyIfEmptyCache_Test()
        {
            Cache cache = new Cache();
            Assert.IsTrue(Enumerable.Empty<object>().SequenceEqual(cache.Keys()));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Values_ShouldGetAllValuesOfType_Test()
        {
            Cache cache = new Cache();
            cache.Add(TestKey, TestValue, new TimeSpan(0, 0, 1));
            cache.Add(1, new List<int> { 1 }, new TimeSpan(0, 0, 1));

            var valuesOfTypeString = cache.Values<string>().ToList();
            Assert.AreEqual(1, valuesOfTypeString.Count);
            Assert.AreEqual(TestValue, valuesOfTypeString.First());
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Values_ShouldGetEmptyOfTypeIfNoMatches_Test()
        {
            Cache cache = new Cache();
            cache.Add(TestKey, TestValue, new TimeSpan(0, 0, 1));
            cache.Add(1, TestValue, new TimeSpan(0, 0, 1));

            var valuesOfTypeListInt = cache.Values<List<int>>().ToList();
            Assert.IsTrue(Enumerable.Empty<List<int>>().SequenceEqual(valuesOfTypeListInt));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Values_ShouldGetAllValues_Test()
        {
            Cache cache = new Cache();
            cache.Add(TestKey, TestValue, new TimeSpan(0, 0, 1));
            cache.Add(1, TestValue, new TimeSpan(0, 0, 1));

            var values = cache.Values().ToList();
            Assert.AreEqual(2, values.Count);
            Assert.IsTrue((new List<object> { TestValue, TestValue }).SequenceEqual(values));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Values_ShouldGetEmptyIfEmptyCache_Test()
        {
            Cache cache = new Cache();
            Assert.IsTrue(Enumerable.Empty<object>().SequenceEqual(cache.Values()));
        }

        [TestMethod]
        [TestCategory("Cache")]
        public void Count_ShouldGiveProperResults_Test()
        {
            Cache cache = new Cache();

            Assert.AreEqual(0, cache.Count());
            cache.Add(TestKey, TestValue, new TimeSpan(0, 5, 0));
            Assert.AreEqual(1, cache.Count());
            cache.Add(TestKey, TestValue, new TimeSpan(0, 5, 0));
            Assert.AreEqual(1, cache.Count());
            cache.Add("otherKey", TestValue, new TimeSpan(0, 5, 0));
            Assert.AreEqual(2, cache.Count());
        }
    }
}
