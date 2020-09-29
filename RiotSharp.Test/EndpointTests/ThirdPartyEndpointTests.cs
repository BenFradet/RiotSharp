using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Http.Interfaces;
using RiotSharp.Interfaces;
using RiotSharp.Misc;

namespace RiotSharp.Test.EndpointTests
{
    [TestClass]
    public class ThirdPartyEndpointTests
    {
        private Mock<IRequester> _requester;
        private Mock<IRateLimitedRequester> _rateLimitedRequester;
        private const string response = "*someReponse*";
        private IRiotApi _riotApi;

        [TestInitialize]
        public void Initialize()
        {
            _requester = new Mock<IRequester>();
            _rateLimitedRequester = new Mock<IRateLimitedRequester>();
            var staticEndpointProvider = new Mock<IStaticEndpointProvider>();
            _riotApi = new RiotApi(_rateLimitedRequester.Object, _requester.Object, staticEndpointProvider.Object);
        }

        [TestMethod]
        public void GetThirdPartyCodeBySummonerIdAsync_GetAThridPartyCodeBySummonerID_ReturnSummerIDCodeResult()
        {
            _rateLimitedRequester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).ReturnsAsync(response);
            var code = _riotApi.ThirdParty.GetThirdPartyCodeBySummonerIdAsync(Region.Na, "SummonerId").Result;
            Assert.AreEqual("someReponse", code);
        }

        [TestMethod]
        public async Task GetThirdPartyCodeBySummonerIdAsync_GetAThridPartyCodeBySummonerID_ReturnSummerIDCode()
        {
            _rateLimitedRequester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).ReturnsAsync(response);
            var code = await _riotApi.ThirdParty.GetThirdPartyCodeBySummonerIdAsync(Region.Na, "SummonerId");
            Assert.AreEqual("someReponse", code);
        }
    }
}
