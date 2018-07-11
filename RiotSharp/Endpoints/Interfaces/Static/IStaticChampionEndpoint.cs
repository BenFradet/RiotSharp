using RiotSharp.Endpoints.StaticDataEndpoint;
using RiotSharp.Endpoints.StaticDataEndpoint.Champion;
using RiotSharp.Misc;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticChampionEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get a champion by his key asynchronously.
        /// </summary>
        /// <param name="key">Champion key, e.g. "Aatrox".</param>
        /// <param name="version">Patch version for returned data.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A champion.</returns>
        Task<ChampionStatic> GetByKey(string key, string version, Language language = Language.en_US);

        /// <summary>
        /// Get a list of all champions asynchronously.
        /// </summary>
        /// <param name="version">Patch version for returned data.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A ChampionListStatic object containing all champions.</returns>
        Task<ChampionListStatic> GetAll(string version, Language language = Language.en_US);
    }
}