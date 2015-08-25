using RiotSharp.ChampionEndpoint;
using RiotSharp.CurrentGameEndpoint;
using RiotSharp.FeaturedGamesEndpoint;
using RiotSharp.GameEndpoint;
using RiotSharp.LeagueEndpoint;
using RiotSharp.MatchEndpoint;
using RiotSharp.StatsEndpoint;
using RiotSharp.SummonerEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    public interface IRiotApi
    {
        Summoner GetSummoner(Region region, int summonerId);
        Task<Summoner> GetSummonerAsync(Region region, int summonerId);
        List<Summoner> GetSummoners(Region region, List<int> summonerIds);
        Task<List<Summoner>> GetSummonersAsync(Region region, List<int> summonerIds);
        Summoner GetSummoner(Region region, string summonerName);
        Task<Summoner> GetSummonerAsync(Region region, string summonerName);
        List<Summoner> GetSummoners(Region region, List<string> summonerNames);
        Task<List<Summoner>> GetSummonersAsync(Region region, List<string> summonerNames);
        SummonerBase GetSummonerName(Region region, int summonerId);
        Task<SummonerBase> GetSummonerNameAsync(Region region, int summonerId);
        List<SummonerBase> GetSummonersNames(Region region, List<int> summonerIds);
        Task<List<SummonerBase>> GetSummonersNamesAsync(Region region, List<int> summonerIds);
        List<Champion> GetChampions(Region region, bool freeToPlay = false);
        Task<List<Champion>> GetChampionsAsync(Region region, bool freeToPlay = false);
        Champion GetChampion(Region region, int championId);
        Task<Champion> GetChampionAsync(Region region, int championId);
        Dictionary<long, List<MasteryPage>> GetMasteryPages(Region region, List<int> summonerIds);
        Task<Dictionary<long, List<MasteryPage>>> GetMasteryPagesAsync(Region region, List<int> summonerIds);
        Dictionary<long, List<RunePage>> GetRunePages(Region region, List<int> summonerIds);
        Task<Dictionary<long, List<RunePage>>> GetRunePagesAsync(Region region, List<int> summonerIds);
        Dictionary<long, List<League>> GetLeagues(Region region, List<int> summonerIds);
        Task<Dictionary<long, List<League>>> GetLeaguesAsync(Region region, List<int> summonerIds);
        Dictionary<long, List<League>> GetEntireLeagues(Region region, List<int> summonerIds);
        Task<Dictionary<long, List<League>>> GetEntireLeaguesAsync(Region region, List<int> summonerIds);
        Dictionary<string, List<League>> GetLeagues(Region region, List<string> teamIds);
        Task<Dictionary<string, List<League>>> GetLeaguesAsync(Region region, List<string> teamIds);
        Dictionary<string, List<League>> GetEntireLeagues(Region region, List<string> teamIds);
        Task<Dictionary<string, List<League>>> GetEntireLeaguesAsync(Region region, List<string> teamIds);
        League GetChallengerLeague(Region region, Queue queue);
        Task<League> GetChallengerLeagueAsync(Region region, Queue queue);
        League GetMasterLeague(Region region, Queue queue);
        Task<League> GetMasterLeagueAsync(Region region, Queue queue);
        Dictionary<long, List<TeamEndpoint.Team>> GetTeams(Region region, List<int> summonerIds);
        Task<Dictionary<long, List<TeamEndpoint.Team>>> GetTeamsAsync(Region region, List<int> summonerIds);
        Dictionary<string, TeamEndpoint.Team> GetTeams(Region region, List<string> teamIds);
        Task<Dictionary<string, TeamEndpoint.Team>> GetTeamsAsync(Region region, List<string> teamIds);
        MatchDetail GetMatch(Region region, long matchId, bool includeTimeline = false);
        Task<MatchDetail> GetMatchAsync(Region region, long matchId, bool includeTimeline = false);
        List<MatchSummary> GetMatchHistory(Region region, long summonerId,
            int beginIndex = 0, int endIndex = 14,
            List<int> championIds = null, List<Queue> rankedQueues = null);
        Task<List<MatchSummary>> GetMatchHistoryAsync(Region region, long summonerId,
            int beginIndex = 0, int endIndex = 14,
            List<int> championIds = null, List<Queue> rankedQueues = null);
        List<PlayerStatsSummary> GetStatsSummaries(Region region, long summonerId);
        Task<List<PlayerStatsSummary>> GetStatsSummariesAsync(Region region, long summonerId);
        List<PlayerStatsSummary> GetStatsSummaries(Region region, long summonerId, StatsEndpoint.Season season);
        Task<List<PlayerStatsSummary>> GetStatsSummariesAsync(Region region, long summonerId,
            StatsEndpoint.Season season);
        List<ChampionStats> GetStatsRanked(Region region, long summonerId);
        Task<List<ChampionStats>> GetStatsRankedAsync(Region region, long summonerId);
        List<ChampionStats> GetStatsRanked(Region region, long summonerId, StatsEndpoint.Season season);
        Task<List<ChampionStats>> GetStatsRankedAsync(Region region, long summonerId,
            StatsEndpoint.Season season);
        List<Game> GetRecentGames(Region region, long summonerId);
        Task<List<Game>> GetRecentGamesAsync(Region region, long summonerId);
        CurrentGame GetCurrentGame(Platform platform, long summonerId);
        Task<CurrentGame> GetCurrentGameAsync(Platform platform, long summonerId);
        FeaturedGames GetFeaturedGames(Region region);
        Task<FeaturedGames> GetFeaturedGamesAsync(Region region);
    }
}
