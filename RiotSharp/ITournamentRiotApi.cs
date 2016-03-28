using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.MatchEndpoint;
using RiotSharp.TournamentEndpoint;
using RiotSharp.TournamentEndpoint.Enums;

namespace RiotSharp
{
    #pragma warning disable 1591
    public interface ITournamentRiotApi
    {
        TournamentProvider CreateProvider(Region region, string url);
        Task<TournamentProvider> CreateProviderAsync(Region region, string url);
        Tournament CreateTournament(int providerId, string name);
        Task<Tournament> CreateTournamentAsync(int providerId, string name);

        string CreateTournamentCode(int tournamentId, int teamSize, List<long> allowedSummonerIds,
            TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType,
            string metadata);

        Task<string> CreateTournamentCodeAsync(int tournamentId, int teamSize, List<long> allowedSummonerIds,
            TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType,
            string metadata);

        List<string> CreateTournamentCodes(int tournamentId, int teamSize, TournamentSpectatorType spectatorType,
            TournamentPickType pickType, TournamentMapType mapType, string metadata, int count = 1);

        Task<List<string>> CreateTournamentCodesAsync(int tournamentId, int teamSize,
            TournamentSpectatorType spectatorType, TournamentPickType pickType, TournamentMapType mapType,
            string metadata, int count = 1);

        bool UpdateTournamentCode(string tournamentCode, List<long> allowedSummonerIds,
            TournamentSpectatorType? spectatorType, TournamentPickType? pickType, TournamentMapType? mapType);

        Task<bool> UpdateTournamentCodeAsync(string tournamentCode, List<long> allowedSummonerIds,
            TournamentSpectatorType? spectatorType, TournamentPickType? pickType, TournamentMapType? mapType);

        TournamentCodeDetail GetTournamentCodeDetails(string tournamentCode);
        Task<TournamentCodeDetail> GetTournamentCodeDetailsAsync(string tournamentCode);
        List<TournamentLobbyEvent> GetTournamentLobbyEvents(string tournamentCode);
        Task<List<TournamentLobbyEvent>> GetTournamentLobbyEventsAsync(string tournamentCode);
        long GetTournamentMatchId(Region region, string tournamentCode);
        Task<long> GetTournamentMatchIdAsync(Region region, string tournamentCode);
        MatchDetail GetTournamentMatch(Region region, long matchId, string tournamentCode, bool includeTimeline);

        Task<MatchDetail> GetTournamentMatchAsync(Region region, long matchId, string tournamentCode,
            bool includeTimeline);
    }
    #pragma warning restore 1591
}
