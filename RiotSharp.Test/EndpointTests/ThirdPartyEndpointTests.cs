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
        private Mock<IRateLimitedRequester> _requester;
        private const string response = "*someReponse*";
        private IRiotApi _riotApi;

        [TestInitialize]
        public void Initialize()
        {
            _requester = new Mock<IRateLimitedRequester>();
            var staticEndpointProvider = new Mock<IStaticEndpointProvider>();
            _riotApi = new RiotApi(_requester.Object, staticEndpointProvider.Object);
        }

        [TestMethod]
        public void GetThirdPartyCode_Test()
        {
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).ReturnsAsync(response);
            var code = _riotApi.ThirdParty.GetThirdPartyCodeBySummonerIdAsync(Region.na, "SummonerId").Result;
            Assert.AreEqual("someReponse", code);
        }

        [TestMethod]
        public async Task GetThirdPartyCodeAsync_Test()
        {
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).ReturnsAsync(response);
            var code = await _riotApi.ThirdParty.GetThirdPartyCodeBySummonerIdAsync(Region.na, "SummonerId");
            Assert.AreEqual("someReponse", code);
        }
    }
}
