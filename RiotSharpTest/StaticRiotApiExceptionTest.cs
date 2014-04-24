using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using System.Configuration;

namespace RiotSharpTest
{
    [TestClass]
    public class StaticRiotApiExceptionTest
    {
        private static string faultyApiKey = ConfigurationManager.AppSettings["FaultyApiKey"];
        private static StaticRiotApi faultyStaticApi = StaticRiotApi.GetInstance(faultyApiKey);

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetStatic_ShouldThrowRiotSharpException_Test()
        {
            var champ = faultyStaticApi.GetChampion(Region.euw, 1, ChampionData.all);
        }
    }
}
