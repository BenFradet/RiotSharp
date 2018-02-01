using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            _riotApi = new RiotApi(_requester.Object);
        }

        [TestMethod]
        public void GetThirdPartyCode_Test()
        {
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).ReturnsAsync(response);
            var code = _riotApi.ThirdParty.GetThirdPartyCodeBySummonerIdAsync(Region.na,1).Result;
            Assert.AreEqual("someReponse", code);
        }

        [TestMethod]
        public async Task GetThirdPartyCodeAsync_Test()
        {
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).ReturnsAsync(response);
            var code = await _riotApi.ThirdParty.GetThirdPartyCodeBySummonerIdAsync(Region.na, 1);
            Assert.AreEqual("someReponse", code);
        }
    }
}
