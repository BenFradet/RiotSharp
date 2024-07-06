using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RiotSharpNET8.Caching;
using RiotSharpNET8.Endpoints.Interfaces;
using RiotSharpNET8.Endpoints.MatchEndpoint;
using RiotSharpNET8.Http.Interfaces;
using RiotSharpNET8.Misc;

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
        [Ignore] // TODO: out-of-date.
        public void GetMatchListAsync_GetTheListOfMatchesOfASpecificSummonerAsync_ReturnMatchList()
        {
            _rateLimitedRequester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                It.IsAny<List<string>>(), It.IsAny<bool>())).ReturnsAsync(File.ReadAllText(ResponsePath));

            var matchList = _matchEndpoint.GetMatchListAsync(Region.Euw, "SummonerId").Result;

            Assert.IsNotNull(matchList);
            foreach(var matchId in matchList)
            {
                Assert.IsTrue(matchId.StartsWith("EUW1_"));
            }
        }
        
    }
}