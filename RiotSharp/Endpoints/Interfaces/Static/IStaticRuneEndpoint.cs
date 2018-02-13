using RiotSharp.Endpoints.StaticDataEndpoint;
using RiotSharp.Endpoints.StaticDataEndpoint.Rune;
using RiotSharp.Misc;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticRuneEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get a rune asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="runeId">Id of the rune to retrieve.</param>
        /// <param name="runeData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A rune.</returns>
        Task<RuneStatic> GetRuneAsync(Region region, int runeId, RuneData runeData = RuneData.All,
           Language language = Language.en_US);

        /// <summary>
        /// Get a list of all runes asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="runeData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A RuneListStatic object containing all runes.</returns>
        Task<RuneListStatic> GetRunesAsync(Region region, RuneData runeData = RuneData.All,
            Language language = Language.en_US);
    }
}