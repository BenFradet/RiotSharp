using RiotSharp.Endpoints.StaticDataEndpoint;
using RiotSharp.Endpoints.StaticDataEndpoint.Mastery;
using RiotSharp.Misc;
using System.Threading.Tasks;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticMasteryEndpoint : IStaticEndpoint
    {
        /// <summary>
        /// Get a list of all masteries asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="masteryData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>An MasteryListStatic object containing all masteries.</returns>
        Task<MasteryListStatic> GetMasteriesAsync(Region region,
            MasteryData masteryData = MasteryData.All, Language language = Language.en_US);

        /// <summary>
        /// Get a mastery asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="masteryId">Id of the mastery to retrieve.</param>
        /// <param name="masteryData">Data to retrieve.</param>
        /// <param name="language">Language of th data to be retrieved.</param>
        /// <returns>A mastery.</returns>
        Task<MasteryStatic> GetMasteryAsync(Region region, int masteryId,
            MasteryData masteryData = MasteryData.All, Language language = Language.en_US);
    }
}