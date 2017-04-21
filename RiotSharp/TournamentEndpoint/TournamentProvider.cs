using System;
using System.Threading.Tasks;

namespace RiotSharp.TournamentEndpoint
{
    /// <summary>
    /// Represents a tournament provider in the Riot API.
    /// </summary>
    [Obsolete]
    public class TournamentProvider
    {
        [Obsolete]
        internal TournamentProvider()
        {
        }

        /// <summary>
        /// The provider ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Creates a tournament for this provider.
        /// </summary>
        /// <param name="name">An optional tournament name.</param>
        /// <returns>A tournament instance.</returns>
        [Obsolete]
        public Tournament CreateTournamentV1(string name)
        {
            return TournamentRiotApi.GetInstance().CreateTournamentV1(Id, name);
        }

        /// <summary>
        ///     Asynchronously creates a tournament for this provider.
        /// </summary>
        /// <param name="name">An optional tournament name.</param>
        /// <returns>A tournament instance.</returns>
        [Obsolete]
        public async Task<Tournament> CreateTournamentV1Async(string name)
        {
            return await TournamentRiotApi.GetInstance().CreateTournamentV1Async(Id, name);
        }
    }
}
