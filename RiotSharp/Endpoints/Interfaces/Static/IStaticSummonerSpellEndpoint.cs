using RiotSharp.Endpoints.StaticDataEndpoint;
using RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell;
using RiotSharp.Misc;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticSummonerSpellEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get a summoner spell asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="summonerSpellId">Id of the summoner spell to retrieve.</param>
        /// <param name="summonerSpellData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <param name="version">Patch version for returned data. If not specified, the latest version for the region is used. 
        /// List of valid versions can be obtained from the /versions endpoint.</param>
        /// <returns>A summoner spell.</returns>
        Task<SummonerSpellStatic> GetSummonerSpellAsync(Region region, int summonerSpellId,
            SummonerSpellData summonerSpellData = SummonerSpellData.All, Language language = Language.en_US,
            string version = null);

        /// <summary>
        /// Get a list of all summoner spells asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="summonerSpellData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <param name="version">Patch version for returned data. If not specified, the latest version for the region is used. 
        /// List of valid versions can be obtained from the /versions endpoint.</param>
        /// <returns>A SummonerSpellListStatic object containing all summoner spells.</returns>
        Task<SummonerSpellListStatic> GetSummonerSpellsAsync(Region region,
            SummonerSpellData summonerSpellData = SummonerSpellData.All, Language language = Language.en_US,
            string version = null);
    }
}