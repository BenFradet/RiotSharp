using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace RiotSharpTest
{
    [TestClass]
    public class StaticRiotApiTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static StaticRiotApi api = StaticRiotApi.GetInstance(apiKey);

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetChampions_Test()
        {
            var champs = api.GetChampions(Region.euw);

            Assert.IsNotNull(champs.Data);
            Assert.IsTrue(champs.Data.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            var champs = api.GetChampionsAsync(Region.euw);

            Assert.IsNotNull(champs.Result.Data);
            Assert.IsTrue(champs.Result.Data.Count > 0);
        }
    }
}
