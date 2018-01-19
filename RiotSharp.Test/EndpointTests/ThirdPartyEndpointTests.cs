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
        private string _response;
        private IRiotApi _riotApi;

        [TestInitialize]
        public void Initialize()
        {
            _requester = new Mock<IRateLimitedRequester>();
            _response = "someReponse";
            _riotApi = new RiotApi(_requester.Object);
        }

        [TestMethod]
        public void GetThirdPartyCode_Test()
        {
            _requester.Setup(moq => moq.CreateGetRequest(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).Returns(_response);
            var code = _riotApi.ThirdParty.GetThirdPartyCodeBySummonerId(Region.na,1);
            Assert.AreEqual("someReponse", code);
        }

        [TestMethod]
        public async Task GetThirdPartyCodeAsync_Test()
        {
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).ReturnsAsync(_response);
            var code = await _riotApi.ThirdParty.GetThirdPartyCodeBySummonerIdAsync(Region.na, 1);
            Assert.AreEqual("someReponse", code);
        }
    }
}
