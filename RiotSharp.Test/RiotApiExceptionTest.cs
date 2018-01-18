﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RiotSharp.Test
{
    [TestClass]
    public class RiotApiExceptionTest
    {
        private static readonly RiotApi FaultyApi = RiotApi.GetDevelopmentInstance(CommonTestBase.FaultyApiKey);

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetSummoner_ShouldThrowRiotSharpException_Test()
        {
            FaultyApi.Summoner.GetSummonerBySummonerId(CommonTestBase.Summoner1And2Region, CommonTestBase.Summoner1Id);
        }

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetChampions_ShouldThrowRiotSharpException_Test()
        {
            FaultyApi.Champion.GetChampions(CommonTestBase.Summoner1And2Region);
        }
    }
}
