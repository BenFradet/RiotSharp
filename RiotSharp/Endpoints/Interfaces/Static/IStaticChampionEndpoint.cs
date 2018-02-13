using RiotSharp.Endpoints.StaticDataEndpoint;
using RiotSharp.Endpoints.StaticDataEndpoint.Champion;
using RiotSharp.Misc;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticChampionEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get a champion asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="championId">Id of the champion to retrieve.</param>
        /// <param name="championData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A champion.</returns>
        Task<ChampionStatic> GetChampionAsync(Region region, int championId,
            ChampionData championData = ChampionData.All, Language language = Language.en_US);

        /// <summary>
        /// Get a list of all champions asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="championData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A ChampionListStatic object containing all champions.</returns>
        Task<ChampionListStatic> GetChampionsAsync(Region region,
            ChampionData championData = ChampionData.All, Language language = Language.en_US);
    }
}