using RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell;
using RiotSharp.Misc;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticSummonerSpellEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get a list of all summoner spells asynchronously.
        /// </summary>
        /// <param name="version">Patch version for returned data.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A SummonerSpellListStatic object containing all summoner spells.</returns>
        Task<SummonerSpellListStatic> GetAllAsync(string version, Language language = Language.en_US);
    }
}