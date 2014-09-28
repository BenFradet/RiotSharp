// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaticRiotApiExceptionTest.cs" company="">
//
// </copyright>
// <summary>
//   The static riot api exception test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Configuration;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using RiotSharp;
using RiotSharp.StaticDataEndpoint;

namespace RiotSharpTest
{
    /// <summary>
    /// The static riot api exception test.
    /// </summary>
    [TestClass]
    public class StaticRiotApiExceptionTest
    {
        /// <summary>
        /// The faulty api key.
        /// </summary>
        private static string faultyApiKey = ConfigurationManager.AppSettings["FaultyApiKey"];

        /// <summary>
        /// The faulty static api.
        /// </summary>
        private static StaticRiotApi faultyStaticApi = StaticRiotApi.GetInstance(faultyApiKey);

        /// <summary>
        /// The get static_ should throw riot sharp exception_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("Exception")]
        [ExpectedException(typeof(RiotSharpException))]
        public void GetStatic_ShouldThrowRiotSharpException_Test()
        {
            var champ = faultyStaticApi.GetChampion(Region.euw, 1, ChampionData.all);
        }
    }
}
