using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using System;
using System.Threading;

namespace RiotSharpTest
{
    [TestClass]
    public class CacheTest
    {
        private const string TestKey = "testKey";
        private const string TestValue = "testValue";

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
    }
}
