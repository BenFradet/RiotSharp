using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RiotSharp.Caching;
using RiotSharp.Endpoints.ChampionEndpoint;
using RiotSharp.Endpoints.Interfaces;
using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RiotSharp.Test.EndpointTests
{
    [TestClass]
    public class ChampionEndpointTests : CommonTestBase
    {
        private static readonly RiotApi Api = RiotApi.GetDevelopmentInstance(ApiKey);

        [TestMethod]
        [TestCategory("ChampionRotation"), TestCategory("Async")]
        public void GetChampionRotationAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var championRotation = Api.Champion.GetChampionRotationAsync(Region.Eun1).Result;

                Assert.IsTrue(championRotation.FreeChampionIds.Count == 15);
                Assert.IsTrue(championRotation.FreeChampionIdsForNewPlayers.Count == 10);
                Assert.IsTrue(championRotation.MaxNewPlayerLevel > 0);
            });
        }
    }
}
