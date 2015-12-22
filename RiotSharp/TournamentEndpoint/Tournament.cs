using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.TournamentEndpoint
{
    [Serializable]
    public class Tournament
    {
        internal Tournament() { }

        public int Id { get; set; }

        TournamentCodeDetail CreateTournamentCode(int teamSize, List<long> allowedSummonerIds, SpectatorType spectatorType, PickType pickType, MapType mapType, string metaData)
        {
            throw new NotImplementedException();
        }

        Task<TournamentCodeDetail> CreateTournamentCodeAsync(int teamSize, List<long> allowedSummonerIds, SpectatorType spectatorType, PickType pickType, MapType mapType, string metaData)
        {
            throw new NotImplementedException();
        }

        List<TournamentCodeDetail> CreateTournamentCodes(int teamSize, SpectatorType spectatorType, PickType pickType, MapType mapType, string metaData, int count = 1)
        {
            throw new NotImplementedException();
        }

        Task<List<TournamentCodeDetail>> CreateTournamentCodesAsync(int teamSize, SpectatorType spectatorType, PickType pickType, MapType mapType, string metaData, int count = 1)
        {
            throw new NotImplementedException();
        }
    }
}
