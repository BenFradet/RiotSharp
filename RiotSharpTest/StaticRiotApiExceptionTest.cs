using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp;
using RiotSharp.StaticDataEndpoint;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;

namespace RiotSharpTest
{
    [TestClass]
    public class StaticRiotApiExceptionTest
    {
        private static IConfigurationRoot conf = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        private static string faultyApiKey = conf["FaultyApiKey"];
        private static StaticRiotApi faultyStaticApi = StaticRiotApi.GetInstance(faultyApiKey);

        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetStatic_ShouldThrowRiotSharpException_Test()
        {
            faultyStaticApi.GetChampion(Region.euw, 1, ChampionData.all);
        }
    }
}
