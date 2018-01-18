using System.Threading.Tasks;
using RiotSharp.Endpoints.StatusEndpoint;
using RiotSharp.Misc;

namespace RiotSharp.Interfaces
{
    /// <summary>
    /// Entry point for the status API.
    /// </summary>
    public interface IStatusRiotApi
    {
        /// <summary>
        /// Get shard status asynchronously.
        /// Returns the data available on the status.leagueoflegends.com website for the given platform.
        /// </summary>
        /// <param name="region">Region for which to check the status.</param>
        /// <returns>A shard status object containing different information regarding the shard.</returns>
        Task<ShardStatus> GetShardStatusAsync(Region region);
    }
}
