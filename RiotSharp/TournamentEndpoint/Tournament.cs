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

        public string CreateTournamentCode(int teamSize, List<long> allowedSummonerIds, TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType, string metaData)
        {
            return TournamentRiotApi.GetInstance().CreateTournamentCode(Id, teamSize, allowedSummonerIds, spectatorType, pickType, mapType, metaData);
        }

        public async Task<string> CreateTournamentCodeAsync(int teamSize, List<long> allowedSummonerIds, TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType, string metaData)
        {
            return await TournamentRiotApi.GetInstance().CreateTournamentCodeAsync(Id, teamSize, allowedSummonerIds, spectatorType, pickType, mapType, metaData);
        }

        public List<string> CreateTournamentCodes(int teamSize, TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType, string metaData, int count = 1)
        {
            return TournamentRiotApi.GetInstance().CreateTournamentCodes(Id, teamSize, spectatorType, pickType, mapType, metaData, count);
        }

        public async Task<List<string>> CreateTournamentCodesAsync(int teamSize, TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType, string metaData, int count = 1)
        {
            return await TournamentRiotApi.GetInstance().CreateTournamentCodesAsync(Id, teamSize, spectatorType, pickType, mapType, metaData, count);
        }
    }
}
