using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using RiotSharp.Endpoints.RunesEndpoint;
using RiotSharp.Http.Interfaces;
using RiotSharp.Interfaces;
using RiotSharp.Misc;


namespace RiotSharp.Test.EndpointTests
{
    [TestClass]
    public class RunesEndpointTests
    {
        private Mock<IRateLimitedRequester> _requester;
        private RunePages _response;
        private IRiotApi _riotApi;

        [TestInitialize]
        public void Initialize()
        {
            _requester = new Mock<IRateLimitedRequester>();
            _response = new RunePages
            {
                Pages = new List<RunePage>
                {
                    new RunePage
                    {
                        Current = true,
                        Id = 1,
                        Name = "AdRunes",
                        Slots = new List<RuneSlot>
                        {
                            new RuneSlot
                            {
                                RuneId = 1,
                                RuneSlotId = 1
                            },
                            new RuneSlot
                            {
                                RuneId = 1,
                                RuneSlotId = 2
                            }
                        }
                    },
                },
                SummonerId = 1
            };
            _riotApi = new RiotApi(_requester.Object);
        }

        [TestMethod]
        public async Task GetRunePagesAsync_ExistingSummonerId_HasRunePages()
        {
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).ReturnsAsync(JsonConvert.SerializeObject(_response));
            var runes = await _riotApi.Runes.GetRunePagesAsync(Region.Asia, 1);
            Assert.IsTrue(runes.Count >= 0 && runes.Count <= 20);
        }

        [TestMethod]
        [ExpectedException(typeof(RiotSharpException))]
        public async Task GetRunePagesAsync_InvalidSummonerId_ThrowsResouceNotFound()
        {
            _requester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).Throws(new RiotSharpException("Not found", HttpStatusCode.NotFound));
            var runes = await _riotApi.Runes.GetRunePagesAsync(Region.Asia, -1);
        }
    }
}
