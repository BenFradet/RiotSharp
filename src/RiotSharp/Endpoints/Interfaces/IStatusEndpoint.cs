using System.Threading.Tasks;
using RiotSharp.Endpoints.StatusEndpoint;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces
{
    /// <summary>
    /// Entry point for the status API.
    /// Requests to this endpoint are not counted against the application rate limits and are not being cached.
    /// </summary>
    public interface IStatusEndpoint
    {
        /// <summary>
        /// Get the League of Legends status for the given shard asynchronously.
        /// </summary>
        /// <param name="region">Region for which to check the status.</param>
        /// <returns>A shard status object containing different information regarding the shard.</returns>
        Task<ShardStatus> GetShardStatusAsync(Region region);
    }
}
