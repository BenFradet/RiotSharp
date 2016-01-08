using System;
using System.Threading.Tasks;

namespace RiotSharp.TournamentEndpoint
{
    /// <summary>
    /// Represents a tournament provider in the Riot API.
    /// </summary>
    public class TournamentProvider
    {
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
        public Tournament CreateTournament(string name)
        {
            return TournamentRiotApi.GetInstance().CreateTournament(Id, name);
        }

        /// <summary>
        ///     Asynchronously creates a tournament for this provider.
        /// </summary>
        /// <param name="name">An optional tournament name.</param>
        /// <returns>A tournament instance.</returns>
        public async Task<Tournament> CreateTournamentAsync(string name)
        {
            return await TournamentRiotApi.GetInstance().CreateTournamentAsync(Id, name);
        }
    }
}
