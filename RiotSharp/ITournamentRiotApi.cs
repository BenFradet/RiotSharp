using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotSharp.MatchEndpoint;
using RiotSharp.TournamentEndpoint;

namespace RiotSharp
{
    public interface ITournamentRiotApi
    {
        TournamentProvider CreateProvider(Region region, string url);
        Task<TournamentProvider> CreateProviderAsync(Region region, string url);
        Tournament CreateTournament(TournamentProvider provider, string name);
        Task<Tournament> CreateTournamentAsync(TournamentProvider provider, string name);
        TournamentCodeDetail CreateTournamentCode(Tournament tournament, int teamSize, List<long> allowedSummonerIds, SpectatorType spectatorType, PickType pickType, MapType mapType, string metaData);
        Task<TournamentCodeDetail> CreateTournamentCodeAsync(Tournament tournament, int teamSize, List<long> allowedSummonerIds, SpectatorType spectatorType, PickType pickType, MapType mapType, string metaData);
        List<TournamentCodeDetail> CreateTournamentCodes(Tournament tournament, int teamSize, List<long> allowedSummonerIds, SpectatorType spectatorType, PickType pickType, MapType mapType, string metaData, int count = 1);
        Task<List<TournamentCodeDetail>> CreateTournamentCodesAsync(Tournament tournament, int teamSize, List<long> allowedSummonerIds, SpectatorType spectatorType, PickType pickType, MapType mapType, string metaData, int count = 1);
        void UpdateTournamentCode(string tournamentCode, List<long> allowedSummonerIds, SpectatorType spectatorType, PickType pickType, MapType mapType);
        void UpdateTournamentCodeAsync(string tournamentCode, List<long> allowedSummonerIds, SpectatorType spectatorType, PickType pickType, MapType mapType);
        TournamentCodeDetail GetTournamentCodeDetails(string tournamentCode);
        Task<TournamentCodeDetail> GetTournamentCodeDetailsAsync(string tournamentCode);
        List<TournamentLobbyEvent> GetTournamentLobbyEvents(string tournamentCode);
        Task<List<TournamentLobbyEvent>> GetTournamentLobbyEventsAsync(string tournamentCode);
        long GetTournamentMatchId(Region region, string tournamentCode);
        Task<long> GetTournamentMatchIdAsync(Region region, string tournamentCode);
        MatchDetail GetTournamentMatch(Region region, long matchId, string tournamentCode, bool includeTimeline);
        Task<MatchDetail> GetTournamentMatchAsync(Region region, long matchId, string tournamentCode, bool includeTimeline);
    }
}
