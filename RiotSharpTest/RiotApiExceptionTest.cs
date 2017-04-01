using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using System;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;

namespace RiotSharpTest
{
    [TestClass]
    public class RiotApiExceptionTest
    {
        private static IConfigurationRoot conf = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        private static int id = int.Parse(conf["Summoner1Id"]);
        private static string faultyApiKey = conf["FaultyApiKey"];
        private static RiotApi faultyApi = RiotApi.GetInstance(faultyApiKey);
        private static string apiKey = conf["ApiKey"];
        private static Region region = (Region)Enum.Parse(typeof(Region), conf["Region"]);

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetSummoner_ShouldThrowRiotSharpException_Test()
        {
            faultyApi.GetSummoner(region, id);
        }

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetChampions_ShouldThrowRiotSharpException_Test()
        {
            faultyApi.GetChampions(region);
        }
    }
}
