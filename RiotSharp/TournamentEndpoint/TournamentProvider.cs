using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            throw new NotImplementedException();
        }

        public Task<Tournament> CreateTournamentAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
