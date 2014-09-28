// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RiotApiExceptionTest.cs" company="">
//   
// </copyright>
// <summary>
//   The riot api exception test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Configuration;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using RiotSharp;

namespace RiotSharpTest
{
    /// <summary>
    /// The riot api exception test.
    /// </summary>
    [TestClass]
    public class RiotApiExceptionTest
    {
        /// <summary>
        /// The faulty api key.
        /// </summary>
        private static string faultyApiKey = ConfigurationManager.AppSettings["FaultyApiKey"];

        /// <summary>
        /// The id.
        /// </summary>
        private static int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);

        /// <summary>
        /// The faulty api.
        /// </summary>
        private static RiotApi faultyApi = RiotApi.GetInstance(faultyApiKey);

        /// <summary>
        /// The get summoner_ should throw riot sharp exception_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetSummoner_ShouldThrowRiotSharpException_Test()
        {
            var summoner = faultyApi.GetSummoner(Region.euw, id);
        }

        /// <summary>
        /// The get champions_ should throw riot sharp exception_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetChampions_ShouldThrowRiotSharpException_Test()
        {
            var champions = faultyApi.GetChampions(Region.euw);
        }
    }
}
