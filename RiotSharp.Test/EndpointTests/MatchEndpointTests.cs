using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RiotSharp.Test.EndpointTests
{
    [TestClass]
    public class MatchEndpointTests
    {
        private Mock<IRateLimitedRequester> _rateLimitedRequester;
        private IMatchEndpoint _matchEndpoint;

        private const string ResponsePath = "./Resources/MatchEndpoint/MatchList_EUW_Response.txt";

        [TestInitialize]
        public void Initialize()
        {
            _rateLimitedRequester = new Mock<IRateLimitedRequester>();
            _matchEndpoint = new MatchEndpoint(_rateLimitedRequester.Object, new PassThroughCache());
        }

        [TestMethod]
        public void GetMatchListAsync_GetTheListOfMatchesOfASpecificSummonerAsync_ReturnMatchList()
        {
            _rateLimitedRequester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).ReturnsAsync(File.ReadAllText(ResponsePath));

            var matchList = _matchEndpoint.GetMatchListAsync(Region.Euw, "SummonerId").Result;

            Assert.IsNotNull(matchList);
            foreach(var matchReference in matchList.Matches)
            {
                Assert.AreEqual(matchReference.PlatformId, Platform.EUW1);
                Assert.AreEqual(matchReference.Region, Region.Euw);
            }
        }
        
    }
}