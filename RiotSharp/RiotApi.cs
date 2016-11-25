using Newtonsoft.Json;
using RiotSharp.ChampionEndpoint;
using RiotSharp.ChampionMasteryEndpoint;
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
using System.Threading.Tasks;

namespace RiotSharp
{
    /// <summary>
    /// Entry point for the API.
    /// </summary>
    public class RiotApi : IRiotApi
    {
        private const string SummonerRootUrl = "/api/lol/{0}/v1.4/summoner";
        private const string ByNameUrl = "/by-name/{0}";
        private const string NamesUrl = "/{0}/name";
        private const string MasteriesUrl = "/{0}/masteries";
        private const string RunesUrl = "/{0}/runes";

        private const string ChampionRootUrl = "/api/lol/{0}/v1.2/champion";

        private const string GameRootUrl = "/api/lol/{0}/v1.3/game";
        private const string RecentGamesUrl = "/by-summoner/{0}/recent";

        private const string LeagueRootUrl = "/api/lol/{0}/v2.5/league";
        private const string LeagueChallengerUrl = "/challenger";
        private const string LeagueMasterUrl = "/master";

        private const string LeagueByTeamUrl = "/by-team/{0}";
        private const string LeagueBySummonerUrl = "/by-summoner/{0}";
        private const string LeagueEntryUrl = "/entry";

        private const string TeamRootUrl = "/api/lol/{0}/v2.4/team";
        private const string TeamBySummonerURL = "/by-summoner/{0}";

        private const string StatsRootUrl = "/api/lol/{0}/v1.3/stats";
        private const string StatsSummaryUrl = "/by-summoner/{0}/summary";
        private const string StatsRankedUrl = "/by-summoner/{0}/ranked";

        private const string MatchRootUrl = "/api/lol/{0}/v2.2/match";
        private const string MatchListRootUrl = "/api/lol/{0}/v2.2/matchlist/by-summoner";

        private const string CurrentGameRootUrl = "/observer-mode/rest/consumer/getSpectatorGameInfo/{0}";

        private const string FeaturedGamesRootUrl = "/observer-mode/rest/featured";

        private const string IdUrl = "/{0}";

        private const string ChampionMasteryRootUrl = "/championmastery/location/{0}/player/{1}";
        private const string ChampionMasteryByChampionId = "/champion/{0}";
        private const string ChampionMasteryAllChampions = "/champions";
        private const string ChampionMasteryTotalScore = "/score";
        private const string ChampionMasteryTopChampions = "/topchampions";

        // used in call which have a maximum number of items you can retrieve in a single call
        private const int MaxNrSummoners = 40;
        private const int MaxNrMasteryPages = 40;
        private const int MaxNrRunePages = 40;
        private const int MaxNrLeagues = 10;
        private const int MaxNrEntireLeagues = 10;
        private const int MaxNrTeams = 10;

        private RateLimitedRequester requester;

        private static RiotApi instance;
        /// <summary>
        /// Get the instance of RiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="rateLimitPer10s">The 10 seconds rate limit for your production api key.</param>
        /// <param name="rateLimitPer10m">The 10 minutes rate limit for your production api key.</param>
        /// <returns>The instance of RiotApi.</returns>
        public static RiotApi GetInstance(string apiKey, int rateLimitPer10s = 10, int rateLimitPer10m = 500)
        {
            if (instance == null || Requesters.RiotApiRequester == null ||
                apiKey != Requesters.RiotApiRequester.ApiKey ||
                rateLimitPer10s != Requesters.RiotApiRequester.RateLimitPer10S ||
                rateLimitPer10m != Requesters.RiotApiRequester.RateLimitPer10M)
            {
                instance = new RiotApi(apiKey, rateLimitPer10s, rateLimitPer10m);
            }
            return instance;
        }

        private RiotApi(string apiKey, int rateLimitPer10s, int rateLimitPer10m)
        {
            Requesters.RiotApiRequester = new RateLimitedRequester(apiKey, rateLimitPer10s, rateLimitPer10m);
            requester = Requesters.RiotApiRequester;
        }

        /// <summary>
        /// Get a summoner by id synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        public Summoner GetSummoner(Region region, long summonerId)
        {
            var json = requester.CreateGetRequest(
                string.Format(SummonerRootUrl, region.ToString()) + string.Format(IdUrl, summonerId), region);
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
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        public async Task<Summoner> GetSummonerAsync(Region region, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(SummonerRootUrl, region.ToString()) + string.Format(IdUrl, summonerId), region);
            var obj = (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Dictionary<long, Summoner>>(json))).Values.FirstOrDefault();
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }

        /// <summary>
        /// Get summoners by ids synchronously, you can submit more than 40 summoner ids.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerIds">List of ids of the summoners you're looking for, not limited to 40.</param>
        /// <returns>A list of summoners.</returns>
        public List<Summoner> GetSummoners(Region region, List<long> summonerIds)
        {
            var list = new List<Summoner>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrSummoners))
            {
                var json = requester.CreateGetRequest(
                    string.Format(SummonerRootUrl,
                        region.ToString()) + string.Format(IdUrl, Util.BuildIdsString(grp)),
                    region);
                var subList = JsonConvert.DeserializeObject<Dictionary<long, Summoner>>(json).Values.ToList();
                list.AddRange(subList);
            }
            foreach (var summ in list)
            {
                summ.Region = region;
            }
            return list;
        }

        /// <summary>
        /// Get summoners by ids asynchronously, you can submit more than 40 summoner ids.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerIds">List of ids of the summoners you're looking for, not limited to 40.</param>
        /// <returns>A list of summoners.</returns>
        public async Task<List<Summoner>> GetSummonersAsync(Region region, List<long> summonerIds)
        {
            var list = new List<Summoner>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrSummoners))
            {
                var json = await requester.CreateGetRequestAsync(
                    string.Format(SummonerRootUrl,
                        region.ToString()) + string.Format(IdUrl, Util.BuildIdsString(grp)),
                    region);
                var subList = (await Task.Factory.StartNew(() =>
                    JsonConvert.DeserializeObject<Dictionary<long, Summoner>>(json))).Values.ToList();
                list.AddRange(subList);
            }
            foreach (var summ in list)
            {
                summ.Region = region;
            }
            return list;
        }

        /// <summary>
        /// Get a summoner by name synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerName">Name of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        public Summoner GetSummoner(Region region, string summonerName)
        {
            var json = requester.CreateGetRequest(
                string.Format(SummonerRootUrl, region.ToString()) +
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
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerName">Name of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        public async Task<Summoner> GetSummonerAsync(Region region, string summonerName)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(SummonerRootUrl, region.ToString()) +
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
        /// Get summoners by names synchronously, you can submit more than 40 summoner names.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerNames">List of names of the summoners you're looking for, not limited to 40.</param>
        /// <returns>A list of summoners.</returns>
        public List<Summoner> GetSummoners(Region region, List<string> summonerNames)
        {
            var list = new List<Summoner>();
            foreach (var grp in MakeGroups(summonerNames, MaxNrSummoners))
            {
                var json = requester.CreateGetRequest(
                    string.Format(SummonerRootUrl,
                        region.ToString()) + string.Format(ByNameUrl, Util.BuildNamesString(grp)),
                    region);
                var subList = JsonConvert.DeserializeObject<Dictionary<string, Summoner>>(json).Values.ToList();
                list.AddRange(subList);
            }
            foreach (var summ in list)
            {
                summ.Region = region;
            }
            return list;
        }

        /// <summary>
        /// Get summoners by names asynchronously, you can submit more than 40 summoner names.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerNames">List of names of the summoners you're looking for, not limited to 40.</param>
        /// <returns>A list of summoners.</returns>
        public async Task<List<Summoner>> GetSummonersAsync(Region region, List<string> summonerNames)
        {
            var list = new List<Summoner>();
            foreach (var grp in MakeGroups(summonerNames, MaxNrSummoners))
            {
                var json = await requester.CreateGetRequestAsync(
                    string.Format(SummonerRootUrl,
                        region.ToString()) + string.Format(ByNameUrl, Util.BuildNamesString(grp)),
                    region);
                var subList = (await Task.Factory.StartNew(() =>
                    JsonConvert.DeserializeObject<Dictionary<string, Summoner>>(json))).Values.ToList();
                list.AddRange(subList);
            }
            foreach (var summ in list)
            {
                summ.Region = region;
            }
            return list;
        }

        /// <summary>
        /// Get a  summoner's name and id synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A summoner (id and name).</returns>
        public SummonerBase GetSummonerName(Region region, long summonerId)
        {
            var json = requester.CreateGetRequest(
                string.Format(SummonerRootUrl, region.ToString()) + string.Format(NamesUrl, summonerId), region);
            var child = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return new SummonerBase(child.Keys.FirstOrDefault(), child.Values.FirstOrDefault(), requester, region);
        }

        /// <summary>
        /// Get a  summoner's name and id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A summoner (id and name).</returns>
        public async Task<SummonerBase> GetSummonerNameAsync(Region region, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(SummonerRootUrl, region.ToString()) + string.Format(NamesUrl, summonerId), region);
            var child = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return new SummonerBase(child.Keys.FirstOrDefault(), child.Values.FirstOrDefault(), requester, region);
        }

        /// <summary>
        /// Get a list of summoner's names and ids synchronously, you can submit more than 40 summoner ids.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerIds">List of ids of the summoners you're looking for, not limited to 40.</param>
        /// <returns>A list of ids and names of summoners.</returns>
        public List<SummonerBase> GetSummonerNames(Region region, List<long> summonerIds)
        {
            var list = new List<SummonerBase>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrSummoners))
            {
                var json = requester.CreateGetRequest(
                    string.Format(SummonerRootUrl,
                        region.ToString()) + string.Format(NamesUrl, Util.BuildIdsString(grp)),
                    region);
                var children = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                foreach (var child in children)
                {
                    list.Add(new SummonerBase(child.Key, child.Value, requester, region));
                }

            }
            return list;
        }

        /// <summary>
        /// Get a list of summoner's names and ids asynchronously, you can submit more than 40 summoner ids.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerIds">List of ids of the summoners you're looking for, not limited to 40.</param>
        /// <returns>A list of ids and names of summoners.</returns>
        public async Task<List<SummonerBase>> GetSummonerNamesAsync(Region region, List<long> summonerIds)
        {
            var list = new List<SummonerBase>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrSummoners))
            {
                var json = await requester.CreateGetRequestAsync(
                    string.Format(SummonerRootUrl,
                        region.ToString()) + string.Format(NamesUrl, Util.BuildIdsString(grp)),
                    region);
                var children = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                foreach (var child in children)
                {
                    list.Add(new SummonerBase(child.Key, child.Value, requester, region));
                }
            }
            return list;
        }

        /// <summary>
        /// Get the list of champions by region synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for champions.</param>
        /// <param name="freeToPlay">If set to true will return only free to play champions.</param>
        /// <returns>A list of champions.</returns>
        public List<Champion> GetChampions(Region region, bool freeToPlay = false)
        {
            var json = requester.CreateGetRequest(string.Format(ChampionRootUrl, region.ToString()), region,
                new List<string> { string.Format("freeToPlay={0}", freeToPlay ? "true" : "false") });
            return JsonConvert.DeserializeObject<ChampionList>(json).Champions;
        }

        /// <summary>
        /// Get the list of champions by region asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for champions.</param>
        /// <param name="freeToPlay">If set to true will return only free to play champions.</param>
        /// <returns>A list of champions.</returns>
        public async Task<List<Champion>> GetChampionsAsync(Region region, bool freeToPlay = false)
        {
            var json = await requester.CreateGetRequestAsync(string.Format(ChampionRootUrl, region.ToString()), region,
                new List<string> { string.Format("freeToPlay={0}", freeToPlay ? "true" : "false") });
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<ChampionList>(json))).Champions;
        }

        /// <summary>
        /// Get a champion from its id synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a champion.</param>
        /// <param name="championId">Id of the champion you're looking for.</param>
        /// <returns>A champion.</returns>
        public Champion GetChampion(Region region, int championId)
        {
            var json = requester.CreateGetRequest(
                string.Format(ChampionRootUrl, region.ToString()) + string.Format(IdUrl, championId), region);
            return JsonConvert.DeserializeObject<Champion>(json);
        }

        /// <summary>
        /// Get a champion from its id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a champion.</param>
        /// <param name="championId">Id of the champion you're looking for.</param>
        /// <returns>A champion.</returns>
        public async Task<Champion> GetChampionAsync(Region region, int championId)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(ChampionRootUrl, region.ToString()) + string.Format(IdUrl, championId),
                region);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Champion>(json));
        }

        /// <summary>
        /// Get mastery pages for a list of summoner ids synchronously, you can submit more than 40 summoner ids.
        /// </summary>
        /// <param name="region">Region in which you wish to look for mastery pages for a list of summoners.</param>
        /// <param name="summonerIds">A list of summoners' ids for which you wish to retrieve the masteries, not
        /// limited to 40.</param>
        /// <returns>A dictionary where the keys are the summoners' ids and the values are lists of mastery pages.
        /// </returns>
        public Dictionary<long, List<MasteryPage>> GetMasteryPages(Region region, List<long> summonerIds)
        {
            var dict = new Dictionary<long, List<MasteryPage>>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrMasteryPages))
            {
                var json = requester.CreateGetRequest(
                    string.Format(SummonerRootUrl,
                        region.ToString()) + string.Format(MasteriesUrl, Util.BuildIdsString(grp)),
                    region);
                var subDict =
                    ConstructMasteryDict(JsonConvert.DeserializeObject<Dictionary<string, MasteryPages>>(json));
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Get mastery pages for a list of summoner ids asynchronously, you can submit more than 40 summoner ids.
        /// </summary>
        /// <param name="region">Region in which you wish to look for mastery pages for a list of summoners.</param>
        /// <param name="summonerIds">A list of summoners' ids for which you wish to retrieve the masteries, not
        /// limited to 40.</param>
        /// <returns>A dictionary where the keys are the summoners' ids and the values are lists of mastery pages.
        /// </returns>
        public async Task<Dictionary<long, List<MasteryPage>>> GetMasteryPagesAsync(Region region,
            List<long> summonerIds)
        {
            var dict = new Dictionary<long, List<MasteryPage>>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrMasteryPages))
            {
                var json = await requester.CreateGetRequestAsync(
                    string.Format(SummonerRootUrl,
                        region.ToString()) + string.Format(MasteriesUrl, Util.BuildIdsString(grp)),
                    region);
                var subDict = ConstructMasteryDict(await Task.Factory.StartNew(() =>
                    JsonConvert.DeserializeObject<Dictionary<string, MasteryPages>>(json)));
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Get rune pages for a list of summoner ids synchronously, you can submit more than 40 summoner ids.
        /// </summary>
        /// <param name="region">Region in which you wish to look for mastery pages for a list of summoners.</param>
        /// <param name="summonerIds">A list of summoner ids for which you wish to retrieve the masteries, not limited
        /// to 40.</param>
        /// <returns>A dictionary where the keys are the summoners' ids and the values are lists of rune pages.
        /// </returns>
        public Dictionary<long, List<RunePage>> GetRunePages(Region region, List<long> summonerIds)
        {
            var dict = new Dictionary<long, List<RunePage>>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrRunePages))
            {
                var json = requester.CreateGetRequest(
                    string.Format(SummonerRootUrl,
                        region.ToString()) + string.Format(RunesUrl, Util.BuildIdsString(grp)),
                    region);
                var subDict = ConstructRuneDict(JsonConvert.DeserializeObject<Dictionary<string, RunePages>>(json));
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Get rune pages for a list of summoner ids asynchronously, you can submit more than 40 summoner ids.
        /// </summary>
        /// <param name="region">Region in which you wish to look for mastery pages for a list of summoners.</param>
        /// <param name="summonerIds">A list of summoner ids for which you wish to retrieve the masteries, not limited
        /// to 40.</param>
        /// <returns>A dictionary where the keys are the summoners' ids and the values are lists of rune pages.
        /// </returns>
        public async Task<Dictionary<long, List<RunePage>>> GetRunePagesAsync(Region region, List<long> summonerIds)
        {
            var dict = new Dictionary<long, List<RunePage>>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrRunePages))
            {
                var json = await requester.CreateGetRequestAsync(
                    string.Format(SummonerRootUrl,
                        region.ToString()) + string.Format(RunesUrl, Util.BuildIdsString(grp)),
                    region);
                var subDict = ConstructRuneDict(await Task.Factory.StartNew(() =>
                    JsonConvert.DeserializeObject<Dictionary<string, RunePages>>(json)));
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Retrieves the league entries for the specified summoners, you can submit more than 10 summoner ids.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the leagues of summoners.</param>
        /// <param name="summonerIds">The summoner ids, not limited to 10.</param>
        /// <returns>A map of list of league entries indexed by the summoner id.</returns>
        public Dictionary<long, List<League>> GetLeagues(Region region, List<long> summonerIds)
        {
            var dict = new Dictionary<long, List<League>>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrLeagues))
            {
                var json = requester.CreateGetRequest(
                    string.Format(LeagueRootUrl, region.ToString()) +
                        string.Format(LeagueBySummonerUrl, Util.BuildIdsString(grp)) + LeagueEntryUrl,
                    region);
                var subDict = JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json);
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Retrieves the league entries for the specified summoners asynchronously, you can submit more than 10
        /// summoner ids.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the leagues of summoners.</param>
        /// <param name="summonerIds">The summoner ids, not limited to 10.</param>
        /// <returns>A map of list of league entries indexed by the summoner id.</returns>
        public async Task<Dictionary<long, List<League>>> GetLeaguesAsync(Region region, List<long> summonerIds)
        {
            var dict = new Dictionary<long, List<League>>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrLeagues))
            {
                var json = await requester.CreateGetRequestAsync(
                    string.Format(LeagueRootUrl, region.ToString()) +
                        string.Format(LeagueBySummonerUrl, Util.BuildIdsString(grp)) + LeagueEntryUrl,
                    region);
                var subDict = await Task.Factory.StartNew(() =>
                    JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json));
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Retrieves the entire leagues for the specified summoners, you can submit more than 10 summoner ids.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the leagues of summoners.</param>
        /// <param name="summonerIds">The summoner ids, not limited to 10.</param>
        /// <returns>A map of list of leagues indexed by the summoner id.</returns>
        public Dictionary<long, List<League>> GetEntireLeagues(Region region, List<long> summonerIds)
        {
            var dict = new Dictionary<long, List<League>>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrEntireLeagues))
            {
                var json = requester.CreateGetRequest(
                    string.Format(LeagueRootUrl,
                        region.ToString()) + string.Format(LeagueBySummonerUrl, Util.BuildIdsString(grp)),
                    region);
                var subDict = JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json);
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Retrieves the entire leagues for the specified summoners asynchronously, you can submit more than 10
        /// summoner ids.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the leagues of summoners.</param>
        /// <param name="summonerIds">The summoner ids, not limited to 10.</param>
        /// <returns>A map of list of leagues indexed by the summoner id.</returns>
        public async Task<Dictionary<long, List<League>>> GetEntireLeaguesAsync(Region region,
            List<long> summonerIds)
        {
            var dict = new Dictionary<long, List<League>>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrEntireLeagues))
            {
                var json = await requester.CreateGetRequestAsync(
                    string.Format(LeagueRootUrl,
                        region.ToString()) + string.Format(LeagueBySummonerUrl, Util.BuildIdsString(grp)),
                    region);
                var subDict = await Task.Factory.StartNew(() =>
                    JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json));
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Retrieves the league entries for the specified teams, you can submit more than 10 team ids.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the leagues of teams.</param>
        /// <param name="teamIds">The team ids, not limited to 10.</param>
        /// <returns>A map of list of leagues indexed by the team id.</returns>
        public Dictionary<string, List<League>> GetLeagues(Region region, List<string> teamIds)
        {
            var dict = new Dictionary<string, List<League>>();
            foreach (var grp in MakeGroups(teamIds, MaxNrLeagues))
            {
                var json = requester.CreateGetRequest(
                    string.Format(LeagueRootUrl, region.ToString()) +
                        string.Format(LeagueByTeamUrl, Util.BuildNamesString(grp)) + LeagueEntryUrl,
                    region);
                var subDict = JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(json);
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Retrieves the league entries for the specified teams asynchronously, you can submit more than 10 team ids.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the leagues of teams.</param>
        /// <param name="teamIds">The team ids, not limited to 10.</param>
        /// <returns>A map of list of league entries indexed by the team id.</returns>
        public async Task<Dictionary<string, List<League>>> GetLeaguesAsync(Region region, List<string> teamIds)
        {
            var dict = new Dictionary<string, List<League>>();
            foreach (var grp in MakeGroups(teamIds, MaxNrLeagues))
            {
                var json = await requester.CreateGetRequestAsync(
                    string.Format(LeagueRootUrl, region.ToString()) +
                        string.Format(LeagueByTeamUrl, Util.BuildNamesString(grp)) + LeagueEntryUrl,
                    region);
                var subDict = await Task.Factory.StartNew(() =>
                    JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(json));
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Retrieves the entire leagues for the specified teams, you can submit more than 10 team ids.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the leagues of teams.</param>
        /// <param name="teamIds">The team ids, not limited to 10.</param>
        /// <returns>A map of list of entire leagues indexed by the team id.</returns>
        public Dictionary<string, List<League>> GetEntireLeagues(Region region, List<string> teamIds)
        {
            var dict = new Dictionary<string, List<League>>();
            foreach (var grp in MakeGroups(teamIds, MaxNrEntireLeagues))
            {
                var json = requester.CreateGetRequest(
                    string.Format(LeagueRootUrl,
                        region.ToString()) + string.Format(LeagueByTeamUrl, Util.BuildNamesString(grp)),
                    region);
                var subDict = JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(json);
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Retrieves the entire leagues for the specified teams asynchronously, you can submit more than 10 team ids.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the leagues of teams.</param>
        /// <param name="teamIds">The team ids, not limited to 10.</param>
        /// <returns>A map of list of entire leagues indexed by the team id.</returns>
        public async Task<Dictionary<string, List<League>>> GetEntireLeaguesAsync(Region region,
            List<string> teamIds)
        {
            var dict = new Dictionary<string, List<League>>();
            foreach (var grp in MakeGroups(teamIds, MaxNrEntireLeagues))
            {
                var json = await requester.CreateGetRequestAsync(
                    string.Format(LeagueRootUrl, region.ToString()) +
                        string.Format(LeagueByTeamUrl, Util.BuildNamesString(grp)),
                    region);
                var subDict = await Task.Factory.StartNew(() =>
                    JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(json));
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Get the challenger league for a particular queue.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a challenger league.</param>
        /// <param name="queue">Queue in which you wish to look for a challenger league.</param>
        /// <returns>A league which contains all the challengers for this specific region and queue.</returns>
        public League GetChallengerLeague(Region region, Queue queue)
        {
            var json = requester.CreateGetRequest(
                string.Format(LeagueRootUrl, region.ToString()) + LeagueChallengerUrl,
                region,
                new List<string> { string.Format("type={0}", queue.ToCustomString()) });
            return JsonConvert.DeserializeObject<League>(json);
        }

        /// <summary>
        /// Get the challenger league for a particular queue asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a challenger league.</param>
        /// <param name="queue">Queue in which you wish to look for a challenger league.</param>
        /// <returns>A league which contains all the challengers for this specific region and queue.</returns>
        public async Task<League> GetChallengerLeagueAsync(Region region, Queue queue)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(LeagueRootUrl, region.ToString()) + LeagueChallengerUrl,
                region,
                new List<string> { string.Format("type={0}", queue.ToCustomString()) });
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<League>(json));
        }

        /// <summary>
        /// Get the master league for a particular queue.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a master league.</param>
        /// <param name="queue">Queue in which you wish to look for a master league.</param>
        /// <returns>A league which contains all the masters for this specific region and queue.</returns>
        public League GetMasterLeague(Region region, Queue queue)
        {
            var json = requester.CreateGetRequest(
                string.Format(LeagueRootUrl, region.ToString()) + LeagueMasterUrl,
                region,
                new List<string> { string.Format("type={0}", queue.ToCustomString()) });
            return JsonConvert.DeserializeObject<League>(json);
        }

        /// <summary>
        /// Get the master league for a particular queue asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a master league.</param>
        /// <param name="queue">Queue in which you wish to look for a master league.</param>
        /// <returns>A league which contains all the masters for this specific region and queue.</returns>
        public async Task<League> GetMasterLeagueAsync(Region region, Queue queue)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(LeagueRootUrl, region.ToString()) + LeagueMasterUrl,
                region,
                new List<string> { string.Format("type={0}", queue.ToCustomString()) });
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<League>(json));
        }

        /// <summary>
        /// Get the teams for the specified ids synchronously, you can submit more than 10 summoner ids.
        /// </summary>
        /// <param name="region">Region in which the teams are located.</param>
        /// <param name="summonerIds">List of summoner ids, not limited to 10.</param>
        /// <returns>A map of teams indexed by summoner id.</returns>
        public Dictionary<long, List<TeamEndpoint.Team>> GetTeams(Region region, List<long> summonerIds)
        {
            var dict = new Dictionary<long, List<TeamEndpoint.Team>>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrTeams))
            {
                var json = requester.CreateGetRequest(
                    string.Format(TeamRootUrl,
                        region.ToString()) + string.Format(TeamBySummonerURL, Util.BuildIdsString(grp)),
                    region);
                var subDict = JsonConvert.DeserializeObject<Dictionary<long, List<TeamEndpoint.Team>>>(json);
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Get the teams for the specified ids asynchronously, you can submit more than 10 summoner ids.
        /// </summary>
        /// <param name="region">Region in which the teams are located.</param>
        /// <param name="summonerIds">List of summoner ids, not limited to 10.</param>
        /// <returns>A map of teams indexed by summoner id.</returns>
        public async Task<Dictionary<long, List<TeamEndpoint.Team>>> GetTeamsAsync(Region region,
            List<long> summonerIds)
        {
            var dict = new Dictionary<long, List<TeamEndpoint.Team>>();
            foreach (var grp in MakeGroups(summonerIds, MaxNrTeams))
            {
                var json = await requester.CreateGetRequestAsync(
                    string.Format(TeamRootUrl,
                        region.ToString()) + string.Format(TeamBySummonerURL, Util.BuildIdsString(grp)),
                    region);
                var subDict = await Task.Factory.StartNew(() =>
                    JsonConvert.DeserializeObject<Dictionary<long, List<TeamEndpoint.Team>>>(json));
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Get the teams for the specified ids synchronously, you can submit more than 10 team ids.
        /// </summary>
        /// <param name="region">Region in which the teams are located.</param>
        /// <param name="teamIds">List of the team ids, not limited to 10.</param>
        /// <returns>A map of teams indexed by their id.</returns>
        public Dictionary<string, TeamEndpoint.Team> GetTeams(Region region, List<string> teamIds)
        {
            var dict = new Dictionary<string, TeamEndpoint.Team>();
            foreach (var grp in MakeGroups(teamIds, MaxNrTeams))
            {
                var json = requester.CreateGetRequest(
                    string.Format(TeamRootUrl, region.ToString()) + string.Format(IdUrl, Util.BuildNamesString(grp)),
                    region);
                var subDict = JsonConvert.DeserializeObject<Dictionary<string, TeamEndpoint.Team>>(json);
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Get the teams for the specified ids asynchronously, you can submit more than 10 team ids.
        /// </summary>
        /// <param name="region">Region in which the teams are located.</param>
        /// <param name="teamIds">List of the team ids, not limited to 10.</param>
        /// <returns>A map of teams indexed by their id.</returns>
        public async Task<Dictionary<string, TeamEndpoint.Team>> GetTeamsAsync(Region region, List<string> teamIds)
        {
            var dict = new Dictionary<string, TeamEndpoint.Team>();
            foreach (var grp in MakeGroups(teamIds, MaxNrTeams))
            {
                var json = await requester.CreateGetRequestAsync(
                    string.Format(TeamRootUrl, region.ToString()) + string.Format(IdUrl, Util.BuildNamesString(grp)),
                    region);
                var subDict = await Task.Factory.StartNew(() =>
                    JsonConvert.DeserializeObject<Dictionary<string, TeamEndpoint.Team>>(json));
                foreach (var child in subDict)
                {
                    dict.Add(child.Key, child.Value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Get match information about a specific match synchronously.
        /// </summary>
        /// <param name="region">Region in which the match took place.</param>
        /// <param name="matchId">The match ID to be retrieved.</param>
        /// <param name="includeTimeline">Whether or not to include timeline information.</param>
        /// <returns>A match detail object containing information about the match.</returns>
        public MatchDetail GetMatch(Region region, long matchId, bool includeTimeline = false)
        {
            var json = requester.CreateGetRequest(
                string.Format(MatchRootUrl, region.ToString()) + string.Format(IdUrl, matchId),
                region,
                new List<string> { string.Format("includeTimeline={0}", includeTimeline) });
            return JsonConvert.DeserializeObject<MatchDetail>(json);
        }

        /// <summary>
        /// Get match information about a specific match asynchronously.
        /// </summary>
        /// <param name="region">Region in which the match took place.</param>
        /// <param name="matchId">The match ID to be retrieved.</param>
        /// <param name="includeTimeline">Whether or not to include timeline information.</param>
        /// <returns>A match detail object containing information about the match.</returns>
        public async Task<MatchDetail> GetMatchAsync(Region region, long matchId, bool includeTimeline = false)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(MatchRootUrl, region.ToString()) + string.Format(IdUrl, matchId),
                region,
                new List<string> { string.Format("includeTimeline={0}", includeTimeline) });
            return await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<MatchDetail>(json));
        }

        /// <summary>
        /// Get the list of matches of a specific summoner synchronously.
        /// </summary>
        /// <param name="region">Region in which the summoner is.</param>
        /// <param name="summonerId">Summoner ID for which you want to retrieve the match list.</param>
        /// <param name="championIds">List of champion IDS to use for fetching games.</param>
        /// <param name="rankedQueues">List of ranked queue types to use for fetching games. Non-ranked queue types
        ///  will be ignored.</param>
        /// <param name="seasons">List of seasons for which to filter the match list by.</param>
        /// <param name="beginTime">The earliest date you wish to get matches from.</param>
        /// <param name="endTime">The latest date you wish to get matches from.</param>
        /// <param name="beginIndex">The begin index to use for fetching matches.</param>
        /// <param name="endIndex">The end index to use for fetching matches.</param>
        /// <returns>A list of Match references object.</returns>
        public MatchList GetMatchList(Region region, long summonerId,
            List<long> championIds = null, List<Queue> rankedQueues = null,
            List<MatchEndpoint.Enums.Season> seasons = null, DateTime? beginTime = null, DateTime? endTime = null,
            int? beginIndex = null, int? endIndex = null)
        {
            var addedArguments = new List<string> {
                    string.Format("beginIndex={0}", beginIndex),
                    string.Format("endIndex={0}", endIndex),
            };
            if (beginTime != null)
            {
                addedArguments.Add(string.Format("beginTime={0}", beginTime.Value.ToLong()));
            }
            if (endTime != null)
            {
                addedArguments.Add(string.Format("endTime={0}", endTime.Value.ToLong()));
            }
            if (championIds != null)
            {
                addedArguments.Add(string.Format("championIds={0}", Util.BuildIdsString(championIds)));
            }
            if (rankedQueues != null)
            {
                addedArguments.Add(string.Format("rankedQueues={0}", Util.BuildQueuesString(rankedQueues)));
            }
            if (seasons != null)
            {
                addedArguments.Add(string.Format("seasons={0}", Util.BuildSeasonString(seasons)));
            }

            var json = requester.CreateGetRequest(
                string.Format(MatchListRootUrl, region.ToString()) + string.Format(IdUrl, summonerId),
                region,
                addedArguments);
            return JsonConvert.DeserializeObject<MatchList>(json);
        }

        /// <summary>
        /// Get the list of matches of a specific summoner asynchronously.
        /// </summary>
        /// <param name="region">Region in which the summoner is.</param>
        /// <param name="summonerId">Summoner ID for which you want to retrieve the match list.</param>
        /// <param name="championIds">List of champion IDS to use for fetching games.</param>
        /// <param name="rankedQueues">List of ranked queue types to use for fetching games. Non-ranked queue types
        ///  will be ignored.</param>
        /// <param name="seasons">List of seasons for which to filter the match list by.</param>
        /// <param name="beginTime">The earliest date you wish to get matches from.</param>
        /// <param name="endTime">The latest date you wish to get matches from.</param>
        /// <param name="beginIndex">The begin index to use for fetching matches.</param>
        /// <param name="endIndex">The end index to use for fetching matches.</param>
        /// <returns>A list of Match references object.</returns>
        public async Task<MatchList> GetMatchListAsync(Region region, long summonerId,
            List<long> championIds = null, List<Queue> rankedQueues = null,
            List<MatchEndpoint.Enums.Season> seasons = null, DateTime? beginTime = null,
            DateTime? endTime = null, int? beginIndex = null, int? endIndex = null)
        {
            var addedArguments = new List<string> {
                    string.Format("beginIndex={0}", beginIndex),
                    string.Format("endIndex={0}", endIndex),
            };
            if (beginTime != null)
            {
                addedArguments.Add(string.Format("beginTime={0}", beginTime.Value.ToLong()));
            }
            if (endTime != null)
            {
                addedArguments.Add(string.Format("endTime={0}", endTime.Value.ToLong()));
            }
            if (championIds != null)
            {
                addedArguments.Add(string.Format("championIds={0}", Util.BuildIdsString(championIds)));
            }
            if (rankedQueues != null)
            {
                addedArguments.Add(string.Format("rankedQueues={0}", Util.BuildQueuesString(rankedQueues)));
            }
            if (seasons != null)
            {
                addedArguments.Add(string.Format("seasons={0}", Util.BuildSeasonString(seasons)));
            }


            var json = await requester.CreateGetRequestAsync(
                string.Format(MatchListRootUrl, region.ToString()) + string.Format(IdUrl, summonerId),
                region,
                addedArguments);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<MatchList>(json));
        }

        /// <summary>
        /// Get player stats by summoner ID synchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve player stats.</param>
        /// <returns>A list of player stats summaries.</returns>
        public List<PlayerStatsSummary> GetStatsSummaries(Region region, long summonerId)
        {
            var json = requester.CreateGetRequest(
                string.Format(StatsRootUrl, region) + string.Format(StatsSummaryUrl, summonerId),
                region);
            return JsonConvert.DeserializeObject<PlayerStatsSummaryList>(json).PlayerStatSummaries;
        }

        /// <summary>
        /// Get player stats by summoner ID asynchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve player stats.</param>
        /// <returns>A list of player stats summaries.</returns>
        public async Task<List<PlayerStatsSummary>> GetStatsSummariesAsync(Region region, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(StatsRootUrl, region) + string.Format(StatsSummaryUrl, summonerId),
                region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<PlayerStatsSummaryList>(json))).PlayerStatSummaries;
        }

        /// <summary>
        /// Get player stats by summoner ID synchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve player stats.</param>
        /// <param name="season">If specified, stats for the given season are returned.
        /// Otherwise, stats for the current season are returned.</param>
        /// <returns>A list of player stats summaries.</returns>
        public List<PlayerStatsSummary> GetStatsSummaries(Region region, long summonerId, Season season)
        {
            var json = requester.CreateGetRequest(
                string.Format(StatsRootUrl, region) + string.Format(StatsSummaryUrl, summonerId),
                region,
                new List<string> { string.Format("season={0}", season.ToString().ToUpper()) });
            return JsonConvert.DeserializeObject<PlayerStatsSummaryList>(json).PlayerStatSummaries;
        }

        /// <summary>
        /// Get player stats by summoner ID asynchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve player stats.</param>
        /// <param name="season">If specified, stats for the given season are returned.
        /// Otherwise, stats for the current season are returned.</param>
        /// <returns>A list of player stats summaries.</returns>
        public async Task<List<PlayerStatsSummary>> GetStatsSummariesAsync(Region region, long summonerId,
            Season season)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(StatsRootUrl, region) + string.Format(StatsSummaryUrl, summonerId),
                region,
                new List<string> { string.Format("season={0}", season.ToString().ToUpper()) });
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<PlayerStatsSummaryList>(json))).PlayerStatSummaries;
        }

        /// <summary>
        /// Get ranked stats by summoner ID synchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve ranked stats.</param>
        /// <returns>A list of champion stats.</returns>
        public List<ChampionStats> GetStatsRanked(Region region, long summonerId)
        {
            var json = requester.CreateGetRequest(
                string.Format(StatsRootUrl, region) + string.Format(StatsRankedUrl, summonerId),
                region);
            return JsonConvert.DeserializeObject<RankedStats>(json).ChampionStats;
        }

        /// <summary>
        /// Get ranked stats by summoner ID asynchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve ranked stats.</param>
        /// <returns>A list of champion stats.</returns>
        public async Task<List<ChampionStats>> GetStatsRankedAsync(Region region, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(StatsRootUrl, region) + string.Format(StatsRankedUrl, summonerId),
                region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<RankedStats>(json))).ChampionStats;
        }

        /// <summary>
        /// Get ranked stats by summoner ID synchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve ranked stats.</param>
        /// <param name="season">If specified, stats for the given season are returned.
        /// Otherwise, stats for the current season are returned.</param>
        /// <returns>A list of champion stats.</returns>
        public List<ChampionStats> GetStatsRanked(Region region, long summonerId, Season season)
        {
            var json = requester.CreateGetRequest(
                string.Format(StatsRootUrl, region) + string.Format(StatsRankedUrl, summonerId),
                region,
                new List<string> { string.Format("season={0}", season.ToString().ToUpper()) });
            return JsonConvert.DeserializeObject<RankedStats>(json).ChampionStats;
        }

        /// <summary>
        /// Get ranked stats by summoner ID asynchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve ranked stats.</param>
        /// <param name="season">If specified, stats for the given season are returned.
        /// Otherwise, stats for the current season are returned.</param>
        /// <returns>A list of champion stats.</returns>
        public async Task<List<ChampionStats>> GetStatsRankedAsync(Region region, long summonerId,
            Season season)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(StatsRootUrl, region) + string.Format(StatsRankedUrl, summonerId),
                region,
                new List<string> { string.Format("season={0}", season.ToString().ToUpper()) });
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<RankedStats>(json))).ChampionStats;
        }

        /// <summary>
        /// Get the 10 most recent games by summoner ID synchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve recent games.</param>
        /// <returns>A list of the 10 most recent games.</returns>
        public List<Game> GetRecentGames(Region region, long summonerId)
        {
            var json = requester.CreateGetRequest(
                string.Format(GameRootUrl, region) + string.Format(RecentGamesUrl, summonerId),
                region);
            return JsonConvert.DeserializeObject<RecentGames>(json).Games;
        }

        /// <summary>
        /// Get the 10 most recent games by summoner ID asynchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve recent games.</param>
        /// <returns>A list of the 10 most recent games.</returns>
        public async Task<List<Game>> GetRecentGamesAsync(Region region, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(GameRootUrl, region) + string.Format(RecentGamesUrl, summonerId),
                region);
            return (await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<RecentGames>(json))).Games;
        }

        private Dictionary<long, List<MasteryPage>> ConstructMasteryDict(Dictionary<string, MasteryPages> dict)
        {
            var returnDict = new Dictionary<long, List<MasteryPage>>();
            foreach (var masteryPage in dict.Values)
            {
                returnDict.Add(masteryPage.SummonerId, masteryPage.Pages);
            }
            return returnDict;
        }

        private Dictionary<long, List<RunePage>> ConstructRuneDict(Dictionary<string, RunePages> dict)
        {
            var returnDict = new Dictionary<long, List<RunePage>>();
            foreach (var runePage in dict.Values)
            {
                returnDict.Add(runePage.SummonerId, runePage.Pages);
            }
            return returnDict;
        }

        /// <summary>
        /// Gets the current game by summoner ID synchronously.
        /// </summary>
        /// <param name="platform">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve current game.</param>
        /// <returns>Current game of the summoner.</returns>
        public CurrentGame GetCurrentGame(Platform platform, long summonerId)
        {
            var json = requester.CreateGetRequest(
                string.Format(CurrentGameRootUrl, platform.ToString()) + string.Format(IdUrl, summonerId),
                platform.ConvertToRegion());
            return JsonConvert.DeserializeObject<CurrentGame>(json);
        }

        /// <summary>
        /// Gets the current game by summoner ID asynchronously.
        /// </summary>
        /// <param name="platform">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve current game.</param>
        /// <returns>Current game of the summoner.</returns>
        public async Task<CurrentGame> GetCurrentGameAsync(Platform platform, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(CurrentGameRootUrl, platform.ToString()) + string.Format(IdUrl, summonerId),
                platform.ConvertToRegion());
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<CurrentGame>(json)));
        }

        /// <summary>
        /// Gets the featured games by region synchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <returns>Featured games for the region.</returns>
        public FeaturedGames GetFeaturedGames(Region region)
        {
            var json = requester.CreateGetRequest(
                FeaturedGamesRootUrl,
                region);
            return JsonConvert.DeserializeObject<FeaturedGames>(json);
        }

        /// <summary>
        /// Gets the featured games by region asynchronously.
        /// </summary>
        /// <param name="region">Region where to retrieve the data.</param>
        /// <returns>Featured games for the region.</returns>
        public async Task<FeaturedGames> GetFeaturedGamesAsync(Region region)
        {
            var json = await requester.CreateGetRequestAsync(
                FeaturedGamesRootUrl,
                region);
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<FeaturedGames>(json)));
        }

        /// <summary>
        /// Gets a champion mastery by summoner ID synchronously.
        /// </summary>
        /// <param name="platform">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve champion mastery.</param>
        /// <param name="championId">ID of the champion for which to retrieve mastery.</param>
        /// <returns>Champion mastery for summoner ID and champion ID.</returns>
        public ChampionMastery GetChampionMastery(Platform platform, long summonerId, int championId)
        {
            var rootUrl = string.Format(ChampionMasteryRootUrl, platform, summonerId);
            var additionalUrl = string.Format(ChampionMasteryByChampionId, championId);

            var json = requester.CreateGetRequest(rootUrl + additionalUrl, platform.ConvertToRegion());
            return JsonConvert.DeserializeObject<ChampionMastery>(json);
        }

        /// <summary>
        /// Gets a champion mastery by summoner ID asynchronously.
        /// </summary>
        /// <param name="platform">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve champion mastery.</param>
        /// <param name="championId">ID of the champion for which to retrieve mastery.</param>
        /// <returns>Champion mastery for summoner ID and champion ID.</returns>
        public async Task<ChampionMastery> GetChampionMasteryAsync(Platform platform,
            long summonerId, int championId)
        {
            var rootUrl = string.Format(ChampionMasteryRootUrl, platform, summonerId);
            var additionalUrl = string.Format(ChampionMasteryByChampionId, championId);

            var json = await requester.CreateGetRequestAsync(rootUrl + additionalUrl, platform.ConvertToRegion());
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ChampionMastery>(json)));
        }

        /// <summary>
        /// Gets all champions mastery by summoner ID synchronously.
        /// </summary>
        /// <param name="platform">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve champion mastery.</param>
        /// <returns>All champions mastery entries for the specified summoner ID.</returns>
        public List<ChampionMastery> GetChampionMasteries(Platform platform, long summonerId)
        {
            var rootUrl = string.Format(ChampionMasteryRootUrl, platform, summonerId);

            var json = requester.CreateGetRequest(rootUrl + ChampionMasteryAllChampions,
                platform.ConvertToRegion());
            return JsonConvert.DeserializeObject<List<ChampionMastery>>(json);
        }

        /// <summary>
        /// Gets all champions mastery by summoner ID asynchronously.
        /// </summary>
        /// <param name="platform">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve champion mastery.</param>
        /// <returns>All champions mastery entries for the specified summoner ID.</returns>
        public async Task<List<ChampionMastery>> GetChampionMasteriesAsync(Platform platform, long summonerId)
        {
            var rootUrl = string.Format(ChampionMasteryRootUrl, platform, summonerId);

            var json = await requester.CreateGetRequestAsync(rootUrl + ChampionMasteryAllChampions,
                platform.ConvertToRegion());
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<ChampionMastery>>(json)));
        }

        /// <summary>
        /// Get a player's total champion mastery score,
        /// which is the sum of individual champion mastery levels, by summoner ID synchronously.
        /// </summary>
        /// <param name="platform">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve champion mastery.</param>
        /// <returns>Total champion mastery score for summoner ID.</returns>
        public int GetTotalChampionMasteryScore(Platform platform, long summonerId)
        {
            var rootUrl = string.Format(ChampionMasteryRootUrl, platform, summonerId);

            var json = requester.CreateGetRequest(rootUrl + ChampionMasteryTotalScore,
                platform.ConvertToRegion());
            return JsonConvert.DeserializeObject<int>(json);
        }

        /// <summary>
        /// Get a player's total champion mastery score,
        /// which is the sum of individual champion mastery levels, by summoner ID asynchronously.
        /// </summary>
        /// <param name="platform">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve champion mastery.</param>
        /// <returns>Total champion mastery score for summoner ID.</returns>
        public async Task<int> GetTotalChampionMasteryScoreAsync(Platform platform, long summonerId)
        {
            var rootUrl = string.Format(ChampionMasteryRootUrl, platform, summonerId);

            var json = await requester.CreateGetRequestAsync(rootUrl + ChampionMasteryTotalScore,
                platform.ConvertToRegion());
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<int>(json)));
        }

        /// <summary>
        /// Gets specified number of top champion mastery entries,
        /// sorted by number of champion points descending, by summoner ID synchronously.
        /// </summary>
        /// <param name="platform">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve champion mastery.</param>
        /// <param name="count">Number of entries to retrieve, defaults to 3.</param>
        /// <returns>A list of the top champion mastery entries for the specified summoner ID.</returns>
        public List<ChampionMastery> GetTopChampionsMasteries(Platform platform, long summonerId,
            int count = 3)
        {
            var rootUrl = string.Format(ChampionMasteryRootUrl, platform, summonerId);

            var json = requester.CreateGetRequest(rootUrl + ChampionMasteryTopChampions,
                platform.ConvertToRegion(), new List<string> { string.Format("count={0}", count) });
            return JsonConvert.DeserializeObject<List<ChampionMastery>>(json);
        }

        /// <summary>
        /// Gets specified number of top champion mastery entries,
        /// sorted by number of champion points descending, by summoner ID asynchronously.
        /// </summary>
        /// <param name="platform">Region where to retrieve the data.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve champion mastery.</param>
        /// <param name="count">Number of entries to retrieve, defaults to 3.</param>
        /// <returns>A list of the top champion mastery entries for the specified summoner ID.</returns>
        public async Task<List<ChampionMastery>> GetTopChampionsMasteriesAsync(Platform platform,
            long summonerId, int count = 3)
        {
            var rootUrl = string.Format(ChampionMasteryRootUrl, platform, summonerId);

            var json = await requester.CreateGetRequestAsync(rootUrl + ChampionMasteryTopChampions,
                platform.ConvertToRegion(), new List<string> { string.Format("count={0}", count) });
            return (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<ChampionMastery>>(json)));
        }

        private List<List<T>> MakeGroups<T>(List<T> toSplit, int chunkSize)
        {
            return toSplit
                .Distinct()
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
