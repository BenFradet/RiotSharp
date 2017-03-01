using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace RiotSharpTest
{
    [TestClass]
    public class RequesterTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];

        private static string RootDomain = "global.api.pvp.net";
        private static string ChampionRootUrl = "/api/lol/static-data/euw/v1.2/champion";
        private static string ImproperChampionRootUrl = "/api/lol/static-data/euw/v1.2/NOT_A_champion";

        [TestMethod]
        [TestCategory("Requester")]
        public void GetResult_ShouldSendBackResult_Test()
        {
            var requester = new Requester(apiKey);
            var json = requester.CreateGetRequest(ChampionRootUrl, RootDomain,
                new List<string> { $"locale=en_US", "" });

            Assert.IsTrue(json.Length > 0);
        }

        [TestMethod]
        [TestCategory("Requester")]
        public void GetResultAsync_ShouldSendBackResult_Test()
        {
            var requester = new Requester(apiKey);
            var json = requester.CreateGetRequestAsync(ChampionRootUrl, RootDomain,
                new List<string> { $"locale=en_US", "" });

            Assert.IsTrue(json.Result.Length > 0);
        }

        [TestMethod]
        [TestCategory("Requester")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetResult_BadURL_ShouldThrowRiotSharpException_Test()
        {
            var requester = new Requester(apiKey);
            var json = requester.CreateGetRequest(ImproperChampionRootUrl, RootDomain,
                new List<string> { $"locale=en_US", "" });
        }

        [TestMethod]
        [TestCategory("Requester")]
        [ExpectedException(typeof(RiotSharpException))]
        public async Task GetResultAsync_BadURL_ShouldThrowRiotSharpException_Test()
        {
            var requester = new Requester(apiKey);
            var json = await requester.CreateGetRequestAsync(ImproperChampionRootUrl, RootDomain,
                new List<string> { $"locale=en_US", "" });
        }
    }
}
