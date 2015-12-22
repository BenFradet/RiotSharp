using System;
using System.Threading.Tasks;

namespace RiotSharp.TournamentEndpoint
{
    [Serializable]
    public class TournamentProvider
    {
        internal TournamentProvider() { }

        public int Id { get; set; }

        public Tournament CreateTournament(string name)
        {
            return TournamentRiotApi.GetInstance().CreateTournament(Id, name);
        }

        public async Task<Tournament> CreateTournamentAsync(string name)
        {
            return await TournamentRiotApi.GetInstance().CreateTournamentAsync(Id, name);
        }
    }
}
