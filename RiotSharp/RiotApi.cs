// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RiotApi.cs" company="">
//   
// </copyright>
// <summary>
//   Entry point for the API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using RiotSharp.ChampionEndpoint;
using RiotSharp.GameEndpoint;
using RiotSharp.LeagueEndpoint;
using RiotSharp.MatchEndpoint;
using RiotSharp.StatsEndpoint;
using RiotSharp.SummonerEndpoint;

namespace RiotSharp
{
    using RiotSharp.TeamEndpoint;

    using Season = RiotSharp.StatsEndpoint.Season;

    /// <summary>
    /// Entry point for the API.
    /// </summary>
    public class RiotApi
    {
        /// <summary>
        /// The summoner root url.
        /// </summary>
        private const string SummonerRootUrl = "/api/lol/{0}/v1.4/summoner";

        /// <summary>
        /// The by name url.
        /// </summary>
        private const string ByNameUrl = "/by-name/{0}";

        /// <summary>
        /// The names url.
        /// </summary>
        private const string NamesUrl = "/{0}/name";

        /// <summary>
        /// The masteries url.
        /// </summary>
        private const string MasteriesUrl = "/{0}/masteries";

        /// <summary>
        /// The runes url.
        /// </summary>
        private const string RunesUrl = "/{0}/runes";

        /// <summary>
        /// The champion root url.
        /// </summary>
        private const string ChampionRootUrl = "/api/lol/{0}/v1.2/champion";

        /// <summary>
        /// The game root url.
        /// </summary>
        private const string GameRootUrl = "/api/lol/{0}/v1.3/game";

        /// <summary>
        /// The recent games url.
        /// </summary>
        private const string RecentGamesUrl = "/by-summoner/{0}/recent";

        /// <summary>
        /// The league root url.
        /// </summary>
        private const string LeagueRootUrl = "/api/lol/{0}/v2.5/league";

        /// <summary>
        /// The league root v 24 url.
        /// </summary>
        private const string LeagueRootV24Url = "/api/lol/{0}/v2.4/league";

        /// <summary>
        /// The league challenger url.
        /// </summary>
        private const string LeagueChallengerUrl = "/challenger";

        /// <summary>
        /// The league by team url.
        /// </summary>
        private const string LeagueByTeamUrl = "/by-team/{0}";

        /// <summary>
        /// The league by summoner url.
        /// </summary>
        private const string LeagueBySummonerUrl = "/by-summoner/{0}";

        /// <summary>
        /// The league entry url.
        /// </summary>
        private const string LeagueEntryUrl = "/entry";

        /// <summary>
        /// The team root url.
        /// </summary>
        private const string TeamRootUrl = "/api/lol/{0}/v2.4/team";

        /// <summary>
        /// The team root v 23 url.
        /// </summary>
        private const string TeamRootV23Url = "/api/lol/{0}/v2.3/team";

        /// <summary>
        /// The team by summoner url.
        /// </summary>
        private const string TeamBySummonerUrl = "/by-summoner/{0}";

        /// <summary>
        /// The stats root url.
        /// </summary>
        private const string StatsRootUrl = "/api/lol/{0}/v1.3/stats";

        /// <summary>
        /// The stats summary url.
        /// </summary>
        private const string StatsSummaryUrl = "/by-summoner/{0}/summary";

        /// <summary>
        /// The stats ranked url.
        /// </summary>
        private const string StatsRankedUrl = "/by-summoner/{0}/ranked";

        /// <summary>
        /// The match root url.
        /// </summary>
        private const string MatchRootUrl = "/api/lol/{0}/v2.2/match";

        /// <summary>
        /// The match history root url.
        /// </summary>
        private const string MatchHistoryRootUrl = "/api/lol/{0}/v2.2/matchhistory";

        /// <summary>
        /// The id url.
        /// </summary>
        private const string IdUrl = "/{0}";

        /// <summary>
        /// The requester.
        /// </summary>
        private readonly RateLimitedRequester requester;

        /// <summary>
        /// The instance.
        /// </summary>
        private static RiotApi instance;

        /// <summary>
        /// Get the instance of RiotApi.
        /// </summary>
        /// <param name="apiKey">
        /// The api key.
        /// </param>
        /// <param name="rateLimitPer10S">
        /// The rate Limit Per 10 s.
        /// </param>
        /// <param name="rateLimitPer10M">
        /// The 10 minutes rate limit for your production api key.
        /// </param>
        /// <returns>
        /// The instance of RiotApi.
        /// </returns>
        public static RiotApi GetInstance(string apiKey, int rateLimitPer10S = 10, int rateLimitPer10M = 500)
        {
            if (instance == null || apiKey != Requester.ApiKey ||
                rateLimitPer10S != RateLimitedRequester.RateLimitPer10S ||
                rateLimitPer10M != RateLimitedRequester.RateLimitPer10M)
            {
                instance = new RiotApi(apiKey, rateLimitPer10S, rateLimitPer10M);
            }

            return instance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RiotApi"/> class.
        /// </summary>
        /// <param name="apiKey">
        /// The api key.
        /// </param>
        /// <param name="rateLimitPer10S">
        /// The rate limit per 10 s.
        /// </param>
        /// <param name="rateLimitPer10M">
        /// The rate limite per 10 m.
        /// </param>
        private RiotApi(string apiKey, int rateLimitPer10S, int rateLimitPer10M)
        {
            requester = RateLimitedRequester.Instance;
            Requester.ApiKey = apiKey;
            RateLimitedRequester.RateLimitPer10S = rateLimitPer10S;
            RateLimitedRequester.RateLimitPer10M = rateLimitPer10M;
        }

        /// <summary>
        /// Get a summoner by id synchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for a summoner.
        /// </param>
        /// <param name="summonerId">
        /// Id of the summoner you're looking for.
        /// </param>
        /// <returns>
        /// A summoner.
        /// </returns>
        public Summoner GetSummoner(Region region, int summonerId)
        {
            var json = requester.CreateRequest(
                string.Format(SummonerRootUrl, region) + string.Format(IdUrl, summonerId), region);
            var obj = JsonConvert.DeserializeObject<Dictionary<long, Summoner>>(json).Values.FirstOrDefault();
            if (obj != null)
            {
                obj.Region = region;
            }

            return obj;
        }

        /// <summary>
        /// Get a summoner by id asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for a summoner.
        /// </param>
        /// <param name="summonerId">
        /// Id of the summoner you're looking for.
        /// </param>
        /// <returns>
        /// A summoner.
        /// </returns>
        public async Task<Summoner> GetSummonerAsync(Region region, int summonerId)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(SummonerRootUrl, region) + string.Format(IdUrl, summonerId), region);
            var obj = (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<long, Summoner>>(json))).Values.FirstOrDefault();
            if (obj != null)
            {
                obj.Region = region;
            }

            return obj;
        }

        /// <summary>
        /// Get summoners by ids synchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for summoners.
        /// </param>
        /// <param name="summonerIds">
        /// List of ids of the summoners you're looking for.
        /// </param>
        /// <returns>
        /// A list of summoners.
        /// </returns>
        public List<Summoner> GetSummoners(Region region, List<int> summonerIds)
        {
            var json =
                requester.CreateRequest(
                    string.Format(SummonerRootUrl, region) + string.Format(IdUrl, Util.BuildIdsString(summonerIds)),
                    region);
            var list = JsonConvert.DeserializeObject<Dictionary<long, Summoner>>(json).Values.ToList();
            foreach (var summ in list)
            {
                summ.Region = region;
            }

            return list;
        }

        /// <summary>
        /// Get summoners by ids asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for summoners.
        /// </param>
        /// <param name="summonerIds">
        /// List of ids of the summoners you're looking for.
        /// </param>
        /// <returns>
        /// A list of summoners.
        /// </returns>
        public async Task<List<Summoner>> GetSummonersAsync(Region region, List<int> summonerIds)
        {
            var json =
                await
                requester.CreateRequestAsync(
                    string.Format(SummonerRootUrl, region) + string.Format(IdUrl, Util.BuildIdsString(summonerIds)),
                    region);
            var list = (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<long, Summoner>>(json))).Values.ToList();
            foreach (var summ in list)
            {
                summ.Region = region;
            }

            return list;
        }

        /// <summary>
        /// Get a summoner by name synchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for a summoner.
        /// </param>
        /// <param name="summonerName">
        /// Name of the summoner you're looking for.
        /// </param>
        /// <returns>
        /// A summoner.
        /// </returns>
        public Summoner GetSummoner(Region region, string summonerName)
        {
            var json = requester.CreateRequest(
                string.Format(SummonerRootUrl, region) +
                    string.Format(ByNameUrl, Uri.EscapeDataString(summonerName)), 
                region);
            var obj = JsonConvert.DeserializeObject<Dictionary<string, Summoner>>(json).Values.FirstOrDefault();
            if (obj != null)
            {
                obj.Region = region;
            }

            return obj;
        }

        /// <summary>
        /// Get a summoner by name asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for a summoner.
        /// </param>
        /// <param name="summonerName">
        /// Name of the summoner you're looking for.
        /// </param>
        /// <returns>
        /// A summoner.
        /// </returns>
        public async Task<Summoner> GetSummonerAsync(Region region, string summonerName)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(SummonerRootUrl, region) +
                    string.Format(ByNameUrl, Uri.EscapeDataString(summonerName)), 
                region);
            var obj = (await Task.Factory.StartNew(() =>
                    JsonConvert.DeserializeObject<Dictionary<string, Summoner>>(json))).Values.FirstOrDefault();
            if (obj != null)
            {
                obj.Region = region;
            }

            return obj;
        }

        /// <summary>
        /// Get summoners by names synchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for summoners.
        /// </param>
        /// <param name="summonerNames">
        /// List of names of the summoners you're looking for.
        /// </param>
        /// <returns>
        /// A list of summoners.
        /// </returns>
        public List<Summoner> GetSummoners(Region region, List<string> summonerNames)
        {
            var json = requester.CreateRequest(
                string.Format(SummonerRootUrl, region) +
                    string.Format(ByNameUrl, Util.BuildNamesString(summonerNames)), 
                region);
            var list = JsonConvert.DeserializeObject<Dictionary<string, Summoner>>(json).Values.ToList();
            foreach (var summ in list)
            {
                summ.Region = region;
            }

            return list;
        }

        /// <summary>
        /// Get summoners by names asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for summoners.
        /// </param>
        /// <param name="summonerNames">
        /// List of names of the summoners you're looking for.
        /// </param>
        /// <returns>
        /// A list of summoners.
        /// </returns>
        public async Task<List<Summoner>> GetSummonersAsync(Region region, List<string> summonerNames)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(SummonerRootUrl, region) +
                    string.Format(ByNameUrl, Util.BuildNamesString(summonerNames)), 
                region);
            var list = (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<string, Summoner>>(json))).Values.ToList();
            foreach (var summ in list)
            {
                summ.Region = region;
            }

            return list;
        }

        /// <summary>
        /// Get a  summoner's name and id synchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for summoners.
        /// </param>
        /// <param name="summonerId">
        /// Id of the summoner you're looking for.
        /// </param>
        /// <returns>
        /// A summoner (id and name).
        /// </returns>
        public SummonerBase GetSummonerName(Region region, int summonerId)
        {
            var json = requester.CreateRequest(
                string.Format(SummonerRootUrl, region) + string.Format(NamesUrl, summonerId), region);
            var child = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return new SummonerBase(child.Keys.FirstOrDefault(), child.Values.FirstOrDefault(), requester, region);
        }

        /// <summary>
        /// Get a  summoner's name and id asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for summoners.
        /// </param>
        /// <param name="summonerId">
        /// Id of the summoner you're looking for.
        /// </param>
        /// <returns>
        /// A summoner (id and name).
        /// </returns>
        public async Task<SummonerBase> GetSummonerNameAsync(Region region, int summonerId)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(SummonerRootUrl, region) + string.Format(NamesUrl, summonerId), region);
            var child = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return new SummonerBase(child.Keys.FirstOrDefault(), child.Values.FirstOrDefault(), requester, region);
        }

        /// <summary>
        /// Get a list of summoner's names and ids synchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for summoners.
        /// </param>
        /// <param name="summonerIds">
        /// List of ids of the summoners you're looking for.
        /// </param>
        /// <returns>
        /// A list of ids and names of summoners.
        /// </returns>
        public List<SummonerBase> GetSummonersNames(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(
                string.Format(SummonerRootUrl, region) +
                    string.Format(NamesUrl, Util.BuildIdsString(summonerIds)), 
                region);
            var summoners = new List<SummonerBase>();
            var children = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            foreach (var child in children)
            {
                summoners.Add(new SummonerBase(child.Key, child.Value, requester, region));
            }

            return summoners;
        }

        /// <summary>
        /// Get a list of summoner's names and ids asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for summoners.
        /// </param>
        /// <param name="summonerIds">
        /// List of ids of the summoners you're looking for.
        /// </param>
        /// <returns>
        /// A list of ids and names of summoners.
        /// </returns>
        public async Task<List<SummonerBase>> GetSummonersNamesAsync(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(SummonerRootUrl, region) +
                    string.Format(NamesUrl, Util.BuildIdsString(summonerIds)), 
                region);
            var summoners = new List<SummonerBase>();
            var children = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            foreach (var sb in children)
            {
                summoners.Add(new SummonerBase(sb.Key, sb.Value, requester, region));
            }

            return summoners;
        }

        /// <summary>
        /// Get the list of champions by region synchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for champions.
        /// </param>
        /// <returns>
        /// A list of champions.
        /// </returns>
        public List<Champion> GetChampions(Region region)
        {
            var json = requester.CreateRequest(string.Format(ChampionRootUrl, region), region);
            return JsonConvert.DeserializeObject<ChampionList>(json).Champions;
        }

        /// <summary>
        /// Get the list of champions by region asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for champions.
        /// </param>
        /// <returns>
        /// A list of champions.
        /// </returns>
        public async Task<List<Champion>> GetChampionsAsync(Region region)
        {
            var json = await requester.CreateRequestAsync(string.Format(ChampionRootUrl, region), region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<ChampionList>(json))).Champions;
        }

        /// <summary>
        /// Get a champion from its id synchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for a champion.
        /// </param>
        /// <param name="championId">
        /// Id of the champion you're looking for.
        /// </param>
        /// <returns>
        /// A champion.
        /// </returns>
        public Champion GetChampion(Region region, int championId)
        {
            var json = requester.CreateRequest(
                string.Format(ChampionRootUrl, region) + string.Format(IdUrl, championId), region);
            return JsonConvert.DeserializeObject<Champion>(json);
        }

        /// <summary>
        /// Get a champion from its id asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for a champion.
        /// </param>
        /// <param name="championId">
        /// Id of the champion you're looking for.
        /// </param>
        /// <returns>
        /// A champion.
        /// </returns>
        public async Task<Champion> GetChampionAsync(Region region, int championId)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(ChampionRootUrl, region) + string.Format(IdUrl, championId), 
                region);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Champion>(json));
        }

        /// <summary>
        /// Get mastery pages for a list summoners' ids synchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for mastery pages for a list of summoners.
        /// </param>
        /// <param name="summonerIds">
        /// A list of summoners' ids for which you wish to retrieve the masteries.
        /// </param>
        /// <returns>
        /// A dictionary where the keys are the summoners' ids and the values are lists of mastery pages.
        /// </returns>
        public Dictionary<long, List<MasteryPage>> GetMasteryPages(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(
                string.Format(SummonerRootUrl, region) +
                    string.Format(MasteriesUrl, Util.BuildIdsString(summonerIds)), 
                region);
            return ConstructMasteryDict(JsonConvert.DeserializeObject<Dictionary<string, MasteryPages>>(json));
        }

        /// <summary>
        /// Get mastery pages for a list summoners' ids asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for mastery pages for a list of summoners.
        /// </param>
        /// <param name="summonerIds">
        /// A list of summoners' ids for which you wish to retrieve the masteries.
        /// </param>
        /// <returns>
        /// A dictionary where the keys are the summoners' ids and the values are lists of mastery pages.
        /// </returns>
        public async Task<Dictionary<long, List<MasteryPage>>> GetMasteryPagesAsync(
            Region region,
            List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(SummonerRootUrl, region) +
                    string.Format(MasteriesUrl, Util.BuildIdsString(summonerIds)), 
                region);
            return ConstructMasteryDict(await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<string, MasteryPages>>(json)));
        }

        /// <summary>
        /// Get rune pages for a list summoners' ids synchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for mastery pages for a list of summoners.
        /// </param>
        /// <param name="summonerIds">
        /// A list of summoners' ids for which you wish to retrieve the masteries.
        /// </param>
        /// <returns>
        /// A dictionary where the keys are the summoners' ids and the values are lists of rune pages.
        /// </returns>
        public Dictionary<long, List<RunePage>> GetRunePages(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(
                string.Format(SummonerRootUrl, region) +
                    string.Format(RunesUrl, Util.BuildIdsString(summonerIds)), 
                region);
            return ConstructRuneDict(JsonConvert.DeserializeObject<Dictionary<string, RunePages>>(json));
        }

        /// <summary>
        /// Get rune pages for a list summoners' ids asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for mastery pages for a list of summoners.
        /// </param>
        /// <param name="summonerIds">
        /// A list of summoners' ids for which you wish to retrieve the masteries.
        /// </param>
        /// <returns>
        /// A dictionary where the keys are the summoners' ids and the values are lists of rune pages.
        /// </returns>
        public async Task<Dictionary<long, List<RunePage>>> GetRunePagesAsync(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(SummonerRootUrl, region) +
                    string.Format(RunesUrl, Util.BuildIdsString(summonerIds)), 
                region);
            return ConstructRuneDict(await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<string, RunePages>>(json)));
        }

        /// <summary>
        /// Retrieves the league entries for the specified summoners.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for the leagues of summoners.
        /// </param>
        /// <param name="summonerIds">
        /// The summoner ids.
        /// </param>
        /// <returns>
        /// A map of list of league entries indexed by the summoner id.
        /// </returns>
        public Dictionary<long, List<League>> GetLeagues(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(
                string.Format(LeagueRootUrl, region) +
                    string.Format(LeagueBySummonerUrl, Util.BuildIdsString(summonerIds)) + LeagueEntryUrl, 
                region);
            return JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json);
        }

        /// <summary>
        /// Retrieves the league entries for the specified summoners asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for the leagues of summoners.
        /// </param>
        /// <param name="summonerIds">
        /// The summoner ids.
        /// </param>
        /// <returns>
        /// A map of list of league entries indexed by the summoner id.
        /// </returns>
        public async Task<Dictionary<long, List<League>>> GetLeaguesAsync(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(LeagueRootUrl, region) +
                    string.Format(LeagueBySummonerUrl, Util.BuildIdsString(summonerIds)) + LeagueEntryUrl, 
                region);
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json));
        }

        /// <summary>
        /// Retrieves the entire leagues for the specified summoners.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for the leagues of summoners.
        /// </param>
        /// <param name="summonerIds">
        /// The summoner ids.
        /// </param>
        /// <returns>
        /// A map of list of leagues indexed by the summoner id.
        /// </returns>
        public Dictionary<long, List<League>> GetEntireLeagues(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(
                string.Format(LeagueRootUrl, region) +
                    string.Format(LeagueBySummonerUrl, Util.BuildIdsString(summonerIds)), 
                region);
            return JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json);
        }

        /// <summary>
        /// Retrieves the entire leagues for the specified summoners asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for the leagues of summoners.
        /// </param>
        /// <param name="summonerIds">
        /// The summoner ids.
        /// </param>
        /// <returns>
        /// A map of list of leagues indexed by the summoner id.
        /// </returns>
        public async Task<Dictionary<long, List<League>>> GetEntireLeaguesAsync(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(LeagueRootUrl, region) +
                    string.Format(LeagueBySummonerUrl, Util.BuildIdsString(summonerIds)), 
                region);
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json));
        }

        /// <summary>
        /// Retrieves the league entries for the specified teams.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for the leagues of teams.
        /// </param>
        /// <param name="teamIds">
        /// The team ids.
        /// </param>
        /// <returns>
        /// A map of list of leagues indexed by the team id.
        /// </returns>
        public Dictionary<string, List<League>> GetLeagues(Region region, List<string> teamIds)
        {
            var json = requester.CreateRequest(
                string.Format(LeagueRootUrl, region) +
                    string.Format(LeagueByTeamUrl, Util.BuildNamesString(teamIds)) + LeagueEntryUrl, 
                region);
            return JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(json);
        }

        /// <summary>
        /// Retrieves the league entries for the specified teams asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for the leagues of teams.
        /// </param>
        /// <param name="teamIds">
        /// The team ids.
        /// </param>
        /// <returns>
        /// A map of list of league entries indexed by the team id.
        /// </returns>
        public async Task<Dictionary<string, List<League>>> GetLeaguesAsync(Region region, List<string> teamIds)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(LeagueRootUrl, region) +
                    string.Format(LeagueByTeamUrl, Util.BuildNamesString(teamIds)) + LeagueEntryUrl, 
                region);
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(json));
        }

        /// <summary>
        /// Retrieves the entire leagues for the specified teams.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for the leagues of teams.
        /// </param>
        /// <param name="teamIds">
        /// The team ids.
        /// </param>
        /// <returns>
        /// A map of list of entire leagues indexed by the team id.
        /// </returns>
        public Dictionary<string, List<League>> GetEntireLeagues(Region region, List<string> teamIds)
        {
            var json = requester.CreateRequest(
                string.Format(LeagueRootUrl, region) +
                    string.Format(LeagueByTeamUrl, Util.BuildNamesString(teamIds)), 
                region);
            return JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(json);
        }

        /// <summary>
        /// Retrieves the entire leagues for the specified teams asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for the leagues of teams.
        /// </param>
        /// <param name="teamIds">
        /// The team ids.
        /// </param>
        /// <returns>
        /// A map of list of entire leagues indexed by the team id.
        /// </returns>
        public async Task<Dictionary<string, List<League>>> GetEntireLeaguesAsync(Region region, List<string> teamIds)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(LeagueRootUrl, region) +
                    string.Format(LeagueByTeamUrl, Util.BuildNamesString(teamIds)), 
                region);
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(json));
        }

        /// <summary>
        /// Get the challenger league for a particular queue.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for a challenger league.
        /// </param>
        /// <param name="queue">
        /// Queue in which you wish to look for a challenger league.
        /// </param>
        /// <returns>
        /// A league which contains all the challengers for this specific region and queue.
        /// </returns>
        public League GetChallengerLeague(Region region, Queue queue)
        {
            var json = requester.CreateRequest(
                string.Format(LeagueRootUrl, region) + LeagueChallengerUrl, 
                region, 
                new List<string> { string.Format("type={0}", queue.ToCustomString()) });
            return JsonConvert.DeserializeObject<League>(json);
        }

        /// <summary>
        /// Get the challenger league for a particular queue asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for a challenger league.
        /// </param>
        /// <param name="queue">
        /// Queue in which you wish to look for a challenger league.
        /// </param>
        /// <returns>
        /// A league which contains all the challengers for this specific region and queue.
        /// </returns>
        public async Task<League> GetChallengerLeagueAsync(Region region, Queue queue)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(LeagueRootUrl, region) + LeagueChallengerUrl, 
                region, 
                new List<string> { string.Format("type={0}", queue.ToCustomString()) });
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<League>(json));
        }

        /// <summary>
        /// Retrieves the league entries for the specified summoners.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for the leagues of summoners.
        /// </param>
        /// <param name="summonerIds">
        /// The summoner ids.
        /// </param>
        /// <returns>
        /// A map of list of league entries indexed by the summoner id.
        /// </returns>
        [Obsolete("The league api v2.4 is deprecated, please use GetLeagues() instead.")]
        public Dictionary<long, List<League>> GetLeaguesV24(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(
                string.Format(LeagueRootV24Url, region) +
                    string.Format(LeagueBySummonerUrl, Util.BuildIdsString(summonerIds)) + LeagueEntryUrl, 
                region);
            return JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json);
        }

        /// <summary>
        /// Retrieves the league entries for the specified summoners asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for the leagues of summoners.
        /// </param>
        /// <param name="summonerIds">
        /// The summoner ids.
        /// </param>
        /// <returns>
        /// A map of list of league entries indexed by the summoner id.
        /// </returns>
        [Obsolete("The league api v2.4 is deprecated, please use GetLeaguesAsync() instead.")]
        public async Task<Dictionary<long, List<League>>> GetLeaguesV24Async(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(LeagueRootV24Url, region) +
                    string.Format(LeagueBySummonerUrl, Util.BuildIdsString(summonerIds)) + LeagueEntryUrl, 
                region);
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json));
        }

        /// <summary>
        /// Retrieves the entire leagues for the specified summoners.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for the leagues of summoners.
        /// </param>
        /// <param name="summonerIds">
        /// The summoner ids.
        /// </param>
        /// <returns>
        /// A map of list of leagues indexed by the summoner id.
        /// </returns>
        [Obsolete("The league api v2.4 is deprecated, please use GetEntireLeagues() instead.")]
        public Dictionary<long, List<League>> GetEntireLeaguesV24(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(
                string.Format(LeagueRootV24Url, region) +
                    string.Format(LeagueBySummonerUrl, Util.BuildIdsString(summonerIds)), 
                region);
            return JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json);
        }

        /// <summary>
        /// Retrieves the entire leagues for the specified summoners asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for the leagues of summoners.
        /// </param>
        /// <param name="summonerIds">
        /// The summoner ids.
        /// </param>
        /// <returns>
        /// A map of list of leagues indexed by the summoner id.
        /// </returns>
        [Obsolete("The league api v2.4 is deprecated, please use GetEntireLeaguesAsync() instead.")]
        public async Task<Dictionary<long, List<League>>> GetEntireLeaguesV24Async(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(LeagueRootV24Url, region) +
                    string.Format(LeagueBySummonerUrl, Util.BuildIdsString(summonerIds)), 
                region);
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json));
        }

        /// <summary>
        /// Retrieves the league entries for the specified teams.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for the leagues of teams.
        /// </param>
        /// <param name="teamIds">
        /// The team ids.
        /// </param>
        /// <returns>
        /// A map of list of leagues indexed by the team id.
        /// </returns>
        [Obsolete("The league api v2.4 is deprecated, please use GetLeagues() instead.")]
        public Dictionary<string, List<League>> GetLeaguesV24(Region region, List<string> teamIds)
        {
            var json = requester.CreateRequest(
                string.Format(LeagueRootV24Url, region) +
                    string.Format(LeagueByTeamUrl, Util.BuildNamesString(teamIds)) + LeagueEntryUrl, 
                region);
            return JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(json);
        }

        /// <summary>
        /// Retrieves the league entries for the specified teams asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for the leagues of teams.
        /// </param>
        /// <param name="teamIds">
        /// The team ids.
        /// </param>
        /// <returns>
        /// A map of list of league entries indexed by the team id.
        /// </returns>
        [Obsolete("The league api v2.4 is deprecated, please use GetLeaguesAsync() instead.")]
        public async Task<Dictionary<string, List<League>>> GetLeaguesV24Async(Region region, List<string> teamIds)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(LeagueRootV24Url, region) +
                    string.Format(LeagueByTeamUrl, Util.BuildNamesString(teamIds)) + LeagueEntryUrl, 
                region);
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(json));
        }

        /// <summary>
        /// Retrieves the entire leagues for the specified teams.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for the leagues of teams.
        /// </param>
        /// <param name="teamIds">
        /// The team ids.
        /// </param>
        /// <returns>
        /// A map of list of entire leagues indexed by the team id.
        /// </returns>
        [Obsolete("The league api v2.4 is deprecated, please use GetEntireLeagues() instead.")]
        public Dictionary<string, List<League>> GetEntireLeaguesV24(Region region, List<string> teamIds)
        {
            var json = requester.CreateRequest(
                string.Format(LeagueRootV24Url, region) +
                    string.Format(LeagueByTeamUrl, Util.BuildNamesString(teamIds)), 
                region);
            return JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(json);
        }

        /// <summary>
        /// Retrieves the entire leagues for the specified teams asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for the leagues of teams.
        /// </param>
        /// <param name="teamIds">
        /// The team ids.
        /// </param>
        /// <returns>
        /// A map of list of entire leagues indexed by the team id.
        /// </returns>
        [Obsolete("The league api v2.4 is deprecated, please use GetEntireLeaguesAsync() instead.")]
        public async Task<Dictionary<string, List<League>>> GetEntireLeaguesV24Async(
            Region region,
            List<string> teamIds)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(LeagueRootV24Url, region) +
                    string.Format(LeagueByTeamUrl, Util.BuildNamesString(teamIds)), 
                region);
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(json));
        }

        /// <summary>
        /// Get the challenger league for a particular queue.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for a challenger league.
        /// </param>
        /// <param name="queue">
        /// Queue in which you wish to look for a challenger league.
        /// </param>
        /// <returns>
        /// A league which contains all the challengers for this specific region and queue.
        /// </returns>
        [Obsolete("The league api v2.4 is deprecated, please use GetChallengerLeague() instead.")]
        public League GetChallengerLeagueV24(Region region, Queue queue)
        {
            var json = requester.CreateRequest(
                string.Format(LeagueRootV24Url, region) + LeagueChallengerUrl, 
                region, 
                new List<string> { string.Format("type={0}", queue.ToCustomString()) });
            return JsonConvert.DeserializeObject<League>(json);
        }

        /// <summary>
        /// Get the challenger league for a particular queue asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which you wish to look for a challenger league.
        /// </param>
        /// <param name="queue">
        /// Queue in which you wish to look for a challenger league.
        /// </param>
        /// <returns>
        /// A league which contains all the challengers for this specific region and queue.
        /// </returns>
        [Obsolete("The league api v2.4 is deprecated, please use GetChallengerLeagueAsync() instead.")]
        public async Task<League> GetChallengerLeagueV24Async(Region region, Queue queue)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(LeagueRootV24Url, region) + LeagueChallengerUrl, 
                region, 
                new List<string> { string.Format("type={0}", queue.ToCustomString()) });
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<League>(json));
        }

        /// <summary>
        /// Get the teams for the specified ids synchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which the teams are located.
        /// </param>
        /// <param name="summonerIds">
        /// List of summoner ids
        /// </param>
        /// <returns>
        /// A map of teams indexed by the summoner's id.
        /// </returns>
        public Dictionary<long, List<Team>> GetTeams(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(
                string.Format(TeamRootUrl, region) +
                    string.Format(TeamBySummonerUrl, Util.BuildIdsString(summonerIds)), 
                region);
            return JsonConvert.DeserializeObject<Dictionary<long, List<Team>>>(json);
        }

        /// <summary>
        /// Get the teams for the specified ids asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which the teams are located.
        /// </param>
        /// <param name="summonerIds">
        /// List of summoner ids.
        /// </param>
        /// <returns>
        /// A map of teams indexed by their id.
        /// </returns>
        public async Task<Dictionary<long, List<Team>>> GetTeamsAsync(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(TeamRootUrl, region) +
                    string.Format(TeamBySummonerUrl, Util.BuildIdsString(summonerIds)), 
                region);
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<long, List<Team>>>(json));
        }

        /// <summary>
        /// Get the teams for the specified ids synchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which the teams are located.
        /// </param>
        /// <param name="teamIds">
        /// List of string of the teams' ids.
        /// </param>
        /// <returns>
        /// A map of teams indexed by their id.
        /// </returns>
        public Dictionary<string, Team> GetTeams(Region region, List<string> teamIds)
        {
            var json = requester.CreateRequest(
                string.Format(TeamRootUrl, region) + string.Format(IdUrl, Util.BuildNamesString(teamIds)), 
                region);
            return JsonConvert.DeserializeObject<Dictionary<string, Team>>(json);
        }

        /// <summary>
        /// Get the teams for the specified ids asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which the teams are located.
        /// </param>
        /// <param name="teamIds">
        /// List of string of the teams' ids.
        /// </param>
        /// <returns>
        /// A map of teams indexed by their id.
        /// </returns>
        public async Task<Dictionary<string, Team>> GetTeamsAsync(Region region, List<string> teamIds)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(TeamRootUrl, region) + string.Format(IdUrl, Util.BuildNamesString(teamIds)), 
                region);
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<string, Team>>(json));
        }

        /// <summary>
        /// Get the teams for the specified ids synchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which the teams are located.
        /// </param>
        /// <param name="summonerIds">
        /// List of summoner ids
        /// </param>
        /// <returns>
        /// A map of teams indexed by the summoner's id.
        /// </returns>
        [Obsolete("The team api v2.3 is deprecated, please use GetTeams() instead.")]
        public Dictionary<long, List<Team>> GetTeamsV23(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(
                string.Format(TeamRootV23Url, region) +
                    string.Format(TeamBySummonerUrl, Util.BuildIdsString(summonerIds)), 
                region);
            return JsonConvert.DeserializeObject<Dictionary<long, List<Team>>>(json);
        }

        /// <summary>
        /// Get the teams for the specified ids asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which the teams are located.
        /// </param>
        /// <param name="summonerIds">
        /// List of summoner ids.
        /// </param>
        /// <returns>
        /// A map of teams indexed by their id.
        /// </returns>
        [Obsolete("The team api v2.3 is deprecated, please use GetTeamsAsync() instead.")]
        public async Task<Dictionary<long, List<Team>>> GetTeamsV23Async(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(TeamRootV23Url, region) +
                    string.Format(TeamBySummonerUrl, Util.BuildIdsString(summonerIds)), 
                region);
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<long, List<Team>>>(json));
        }

        /// <summary>
        /// Get the teams for the specified ids synchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which the teams are located.
        /// </param>
        /// <param name="teamIds">
        /// List of string of the teams' ids.
        /// </param>
        /// <returns>
        /// A map of teams indexed by their id.
        /// </returns>
        [Obsolete("The team api v2.3 is deprecated, please use GetTeams() instead.")]
        public Dictionary<string, Team> GetTeamsV23(Region region, List<string> teamIds)
        {
            var json =
                requester.CreateRequest(
                    string.Format(TeamRootV23Url, region) + string.Format(IdUrl, Util.BuildNamesString(teamIds)),
                    region);
            return JsonConvert.DeserializeObject<Dictionary<string, Team>>(json);
        }

        /// <summary>
        /// Get the teams for the specified ids asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which the teams are located.
        /// </param>
        /// <param name="teamIds">
        /// List of string of the teams' ids.
        /// </param>
        /// <returns>
        /// A map of teams indexed by their id.
        /// </returns>
        [Obsolete("The team api v2.3 is deprecated, please use GetTeamsAsync() instead.")]
        public async Task<Dictionary<string, Team>> GetTeamsV23Async(Region region, List<string> teamIds)
        {
            var json =
                await
                requester.CreateRequestAsync(
                    string.Format(TeamRootV23Url, region) + string.Format(IdUrl, Util.BuildNamesString(teamIds)),
                    region);
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<string, Team>>(json));
        }

        /// <summary>
        /// Get match information about a specific match synchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which the match took place.
        /// </param>
        /// <param name="matchId">
        /// The match ID to be retrieved.
        /// </param>
        /// <param name="includeTimeline">
        /// Whether or not to include timeline information.
        /// </param>
        /// <returns>
        /// A match detail object containing information about the match.
        /// </returns>
        public MatchDetail GetMatch(Region region, long matchId, bool includeTimeline = false)
        {
            var json = requester.CreateRequest(
                string.Format(MatchRootUrl, region) + string.Format(IdUrl, matchId), 
                region, 
                new List<string> { string.Format("includeTimeline={0}", includeTimeline) });
            return JsonConvert.DeserializeObject<MatchDetail>(json);
        }

        /// <summary>
        /// Get match information about a specific match asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which the match took place.
        /// </param>
        /// <param name="matchId">
        /// The match ID to be retrieved.
        /// </param>
        /// <param name="includeTimeline">
        /// Whether or not to include timeline information.
        /// </param>
        /// <returns>
        /// A match detail object containing information about the match.
        /// </returns>
        public async Task<MatchDetail> GetMatchAsync(Region region, long matchId, bool includeTimeline = false)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(MatchRootUrl, region) + string.Format(IdUrl, matchId), 
                region, 
                new List<string> { string.Format("includeTimeline={0}", includeTimeline) });
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<MatchDetail>(json));
        }

        /// <summary>
        /// Get the mach history of a specific summoner synchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which the summoner is.
        /// </param>
        /// <param name="summonerId">
        /// Summoner ID for which you want to retrieve the match history.
        /// </param>
        /// <param name="beginIndex">
        /// The begin index to use for fetching games.
        /// The range has to be less than or equal to 15.
        /// </param>
        /// <param name="endIndex">
        /// The end index to use for fetching games.
        /// The range has to be less than or equal to 15.
        /// </param>
        /// <param name="championIds">
        /// List of champion IDs to use for fetching games.
        /// </param>
        /// <param name="rankedQueues">
        /// List of ranked queue types to use for fetching games. Non-ranked queue types
        /// will be ignored.
        /// </param>
        /// <returns>
        /// A list of match summaries object.
        /// </returns>
        public List<MatchSummary> GetMatchHistory(
            Region region,
            long summonerId,
            int beginIndex = 0,
            int endIndex = 14,
            List<int> championIds = null,
            List<Queue> rankedQueues = null)
        {
            var addedArguments = new List<string>
                                     {
                                         string.Format("beginIndex={0}", beginIndex),
                                         string.Format("endIndex={0}", endIndex),
                                     };
            if (championIds != null)
            {
                addedArguments.Add(string.Format("championIds={0}", Util.BuildIdsString(championIds)));
            }

            if (rankedQueues != null)
            {
                addedArguments.Add(string.Format("rankedQueues={0}", Util.BuildQueuesString(rankedQueues)));
            }

            var json =
                requester.CreateRequest(
                    string.Format(MatchHistoryRootUrl, region) + string.Format(IdUrl, summonerId),
                    region,
                    addedArguments);
            return JsonConvert.DeserializeObject<PlayerHistory>(json).Matches;
        }

        /// <summary>
        /// Get the mach history of a specific summoner asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region in which the summoner is.
        /// </param>
        /// <param name="summonerId">
        /// Summoner ID for which you want to retrieve the match history.
        /// </param>
        /// <param name="beginIndex">
        /// The begin index to use for fetching games.
        /// endIndex - beginIndex has to be inferior to 15.
        /// </param>
        /// <param name="endIndex">
        /// The end index to use for fetching games.
        /// endIndex - beginIndex has to be inferior to 15.
        /// </param>
        /// <param name="championIds">
        /// List of champion IDs to use for fetching games.
        /// </param>
        /// <param name="rankedQueues">
        /// List of ranked queue types to use for fetching games. Non-ranked queue types
        /// will be ignored.
        /// </param>
        /// <returns>
        /// A list of match summaries object.
        /// </returns>
        public async Task<List<MatchSummary>> GetMatchHistoryAsync(
            Region region,
            long summonerId,
            int beginIndex = 0,
            int endIndex = 14,
            List<int> championIds = null,
            List<Queue> rankedQueues = null)
        {
            var addedArguments = new List<string>
                                     {
                                         string.Format("beginIndex={0}", beginIndex),
                                         string.Format("endIndex={0}", endIndex),
                                     };
            if (championIds != null)
            {
                addedArguments.Add(string.Format("championIds={0}", Util.BuildIdsString(championIds)));
            }

            if (rankedQueues != null)
            {
                addedArguments.Add(string.Format("rankedQueues={0}", Util.BuildQueuesString(rankedQueues)));
            }

            var json =
                await
                requester.CreateRequestAsync(
                    string.Format(MatchHistoryRootUrl, region) + string.Format(IdUrl, summonerId),
                    region,
                    addedArguments);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<PlayerHistory>(json).Matches);
        }

        /// <summary>
        /// Get player stats by summoner ID synchronously.
        /// </summary>
        /// <param name="region">
        /// Region where to retrieve the data.
        /// </param>
        /// <param name="summonerId">
        /// ID of the summoner for which to retrieve player stats.
        /// </param>
        /// <returns>
        /// A list of player stats summaries.
        /// </returns>
        public List<PlayerStatsSummary> GetStatsSummaries(Region region, long summonerId)
        {
            var json = requester.CreateRequest(
                string.Format(StatsRootUrl, region) + string.Format(StatsSummaryUrl, summonerId), 
                region);
            return JsonConvert.DeserializeObject<PlayerStatsSummaryList>(json).PlayerStatSummaries;
        }

        /// <summary>
        /// Get player stats by summoner ID asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region where to retrieve the data.
        /// </param>
        /// <param name="summonerId">
        /// ID of the summoner for which to retrieve player stats.
        /// </param>
        /// <returns>
        /// A list of player stats summaries.
        /// </returns>
        public async Task<List<PlayerStatsSummary>> GetStatsSummariesAsync(Region region, long summonerId)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(StatsRootUrl, region) + string.Format(StatsSummaryUrl, summonerId), 
                region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<PlayerStatsSummaryList>(json))).PlayerStatSummaries;
        }

        /// <summary>
        /// Get player stats by summoner ID synchronously.
        /// </summary>
        /// <param name="region">
        /// Region where to retrieve the data.
        /// </param>
        /// <param name="summonerId">
        /// ID of the summoner for which to retrieve player stats.
        /// </param>
        /// <param name="season">
        /// If specified, stats for the given season are returned.
        /// Otherwise, stats for the current season are returned.
        /// </param>
        /// <returns>
        /// A list of player stats summaries.
        /// </returns>
        public List<PlayerStatsSummary> GetStatsSummaries(Region region, long summonerId, Season season)
        {
            var json = requester.CreateRequest(
                string.Format(StatsRootUrl, region) + string.Format(StatsSummaryUrl, summonerId), 
                region, 
                new List<string> { string.Format("season={0}", season.ToString().ToUpper()) });
            return JsonConvert.DeserializeObject<PlayerStatsSummaryList>(json).PlayerStatSummaries;
        }

        /// <summary>
        /// Get player stats by summoner ID asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region where to retrieve the data.
        /// </param>
        /// <param name="summonerId">
        /// ID of the summoner for which to retrieve player stats.
        /// </param>
        /// <param name="season">
        /// If specified, stats for the given season are returned.
        /// Otherwise, stats for the current season are returned.
        /// </param>
        /// <returns>
        /// A list of player stats summaries.
        /// </returns>
        public async Task<List<PlayerStatsSummary>> GetStatsSummariesAsync(
            Region region,
            long summonerId,
            Season season)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(StatsRootUrl, region) + string.Format(StatsSummaryUrl, summonerId), 
                region, 
                new List<string> { string.Format("season={0}", season.ToString().ToUpper()) });
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<PlayerStatsSummaryList>(json))).PlayerStatSummaries;
        }

        /// <summary>
        /// Get ranked stats by summoner ID synchronously.
        /// </summary>
        /// <param name="region">
        /// Region where to retrieve the data.
        /// </param>
        /// <param name="summonerId">
        /// ID of the summoner for which to retrieve ranked stats.
        /// </param>
        /// <returns>
        /// A list of champion stats.
        /// </returns>
        public List<ChampionStats> GetStatsRanked(Region region, long summonerId)
        {
            var json = requester.CreateRequest(
                string.Format(StatsRootUrl, region) + string.Format(StatsRankedUrl, summonerId), 
                region);
            return JsonConvert.DeserializeObject<RankedStats>(json).ChampionStats;
        }

        /// <summary>
        /// Get ranked stats by summoner ID asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region where to retrieve the data.
        /// </param>
        /// <param name="summonerId">
        /// ID of the summoner for which to retrieve ranked stats.
        /// </param>
        /// <returns>
        /// A list of champion stats.
        /// </returns>
        public async Task<List<ChampionStats>> GetStatsRankedAsync(Region region, long summonerId)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(StatsRootUrl, region) + string.Format(StatsRankedUrl, summonerId), 
                region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<RankedStats>(json))).ChampionStats;
        }

        /// <summary>
        /// Get ranked stats by summoner ID synchronously.
        /// </summary>
        /// <param name="region">
        /// Region where to retrieve the data.
        /// </param>
        /// <param name="summonerId">
        /// ID of the summoner for which to retrieve ranked stats.
        /// </param>
        /// <param name="season">
        /// If specified, stats for the given season are returned.
        /// Otherwise, stats for the current season are returned.
        /// </param>
        /// <returns>
        /// A list of champion stats.
        /// </returns>
        public List<ChampionStats> GetStatsRanked(Region region, long summonerId, Season season)
        {
            var json = requester.CreateRequest(
                string.Format(StatsRootUrl, region) + string.Format(StatsRankedUrl, summonerId), 
                region, 
                new List<string> { string.Format("season={0}", season.ToString().ToUpper()) });
            return JsonConvert.DeserializeObject<RankedStats>(json).ChampionStats;
        }

        /// <summary>
        /// Get ranked stats by summoner ID asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region where to retrieve the data.
        /// </param>
        /// <param name="summonerId">
        /// ID of the summoner for which to retrieve ranked stats.
        /// </param>
        /// <param name="season">
        /// If specified, stats for the given season are returned.
        /// Otherwise, stats for the current season are returned.
        /// </param>
        /// <returns>
        /// A list of champion stats.
        /// </returns>
        public async Task<List<ChampionStats>> GetStatsRankedAsync(Region region, long summonerId, Season season)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(StatsRootUrl, region) + string.Format(StatsRankedUrl, summonerId), 
                region, 
                new List<string> { string.Format("season={0}", season.ToString().ToUpper()) });
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<RankedStats>(json))).ChampionStats;
        }

        /// <summary>
        /// Get the 10 most recent games by summoner ID synchronously.
        /// </summary>
        /// <param name="region">
        /// Region where to retrieve the data.
        /// </param>
        /// <param name="summonerId">
        /// ID of the summoner for which to retrieve recent games.
        /// </param>
        /// <returns>
        /// A list of the 10 most recent games.
        /// </returns>
        public List<Game> GetRecentGames(Region region, long summonerId)
        {
            var json = requester.CreateRequest(
                string.Format(GameRootUrl, region) + string.Format(RecentGamesUrl, summonerId), 
                region);
            return JsonConvert.DeserializeObject<RecentGames>(json).Games;
        }

        /// <summary>
        /// Get the 10 most recent games by summoner ID asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region where to retrieve the data.
        /// </param>
        /// <param name="summonerId">
        /// ID of the summoner for which to retrieve recent games.
        /// </param>
        /// <returns>
        /// A list of the 10 most recent games.
        /// </returns>
        public async Task<List<Game>> GetRecentGamesAsync(Region region, long summonerId)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(GameRootUrl, region) + string.Format(RecentGamesUrl, summonerId), 
                region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<RecentGames>(json))).Games;
        }

        /// <summary>
        /// The construct mastery dict.
        /// </summary>
        /// <param name="dict">
        /// The dict.
        /// </param>
        /// <returns>
        /// The <see cref="Dictionary{TKey, TValue}"/>.
        /// </returns>
        private Dictionary<long, List<MasteryPage>> ConstructMasteryDict(Dictionary<string, MasteryPages> dict)
        {
            var returnDict = new Dictionary<long, List<MasteryPage>>();
            foreach (var masteryPage in dict.Values)
            {
                returnDict.Add(masteryPage.SummonerId, masteryPage.Pages);
            }

            return returnDict;
        }

        /// <summary>
        /// The construct rune dict.
        /// </summary>
        /// <param name="dict">
        /// The dict.
        /// </param>
        /// <returns>
        /// The <see cref="Dictionary{TKey, TValue}"/>.
        /// </returns>
        private Dictionary<long, List<RunePage>> ConstructRuneDict(Dictionary<string, RunePages> dict)
        {
            var returnDict = new Dictionary<long, List<RunePage>>();
            foreach (var runePage in dict.Values)
            {
                returnDict.Add(runePage.SummonerId, runePage.Pages);
            }

            return returnDict;
        }
    }
}