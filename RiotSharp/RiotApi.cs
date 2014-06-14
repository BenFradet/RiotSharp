using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class RiotApi
    {
        private const string SummonerRootV13Url = "/api/lol/{0}/v1.3/summoner";
        private const string SummonerRootUrl = "/api/lol/{0}/v1.4/summoner";
        private const string ByNameUrl = "/by-name/{0}";
        private const string IdUrl = "/{0}";
        private const string NamesUrl = "/{0}/name";
        private const string MasteriesUrl = "/{0}/masteries";
        private const string RunesUrl = "/{0}/runes";

        private const string ChampionRootV11Url = "/api/lol/{0}/v1.1/champion";
        private const string ChampionRootUrl = "/api/lol/{0}/v1.2/champion";

        private const string LeagueRootV23Url = "/api/lol/{0}/v2.3/league";
        private const string LeagueRootUrl = "/api/lol/{0}/v2.4/league";
        private const string LeagueChallengerUrl = "/challenger";
        private const string LeagueByTeamUrl = "/by-team/{0}";
        private const string LeagueBySummonerUrl = "/by-summoner/{0}";
        private const string LeagueEntryUrl = "/entry";

        private const string TeamRootV22Url = "/api/lol/{0}/v2.2/team";
        private const string TeamRootUrl = "/api/lol/{0}/v2.3/team";
        private const string TeamBySummonerURL = "/by-summoner/{0}";

        private RateLimitedRequester requester;

        private static RiotApi instance;
        /// <summary>
        /// Get the instance of RiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="isProdApi">Indicates if this is a production api or not.</param>
        /// <returns>The instance of RiotApi.</returns>
        public static RiotApi GetInstance(string apiKey, bool isProdApi)
        {
            if (instance == null || apiKey != RateLimitedRequester.ApiKey || isProdApi != RateLimitedRequester.IsProdApi)
            {
                instance = new RiotApi(apiKey, isProdApi);
            }
            return instance;
        }
        
        private RiotApi(string apiKey, bool isProdApi)
        {
            requester = RateLimitedRequester.Instance;
            RateLimitedRequester.RootDomain = "euw.api.pvp.net";
            RateLimitedRequester.ApiKey = apiKey;
            RateLimitedRequester.IsProdApi = isProdApi;
        }

        /// <summary>
        /// Get a summoner by id synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        public Summoner GetSummoner(Region region, int summonerId)
        {
            var json = requester.CreateRequest(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(IdUrl, summonerId));
            var obj = JsonConvert.DeserializeObject<Dictionary<long, Summoner>>(json).Values.FirstOrDefault();
            obj.Region = region;
            return obj;
        }

        /// <summary>
        /// Get a summoner by id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        public async Task<Summoner> GetSummonerAsync(Region region, int summonerId)
        {
            var json = await requester.CreateRequestAsync(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(IdUrl, summonerId));
            var obj = (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Dictionary<long, Summoner>>(json))).Values.FirstOrDefault();
            obj.Region = region;
            return obj;
        }

        /// <summary>
        /// Get summoners by ids synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerIds">List of ids of the summoners you're looking for.</param>
        /// <returns>A list of summoners.</returns>
        public List<Summoner> GetSummoners(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(IdUrl, BuildIdsString(summonerIds)));
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
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerIds">List of ids of the summoners you're looking for.</param>
        /// <returns>A list of summoners.</returns>
        public async Task<List<Summoner>> GetSummonersAsync(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(IdUrl, BuildIdsString(summonerIds)));
            var list = (await Task.Factory.StartNew<Dictionary<long, Summoner>>(() => JsonConvert.DeserializeObject<Dictionary<long, Summoner>>(json))).Values.ToList();
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
            var json = requester.CreateRequest(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(ByNameUrl, Uri.EscapeDataString(summonerName)));
            var obj = JsonConvert.DeserializeObject<Dictionary<string, Summoner>>(json).Values.FirstOrDefault();
            obj.Region = region;
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
            var json = await requester.CreateRequestAsync(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(ByNameUrl, Uri.EscapeDataString(summonerName)));
            var obj = 
                (await Task.Factory.StartNew<Dictionary<string, Summoner>>(() => JsonConvert.DeserializeObject<Dictionary<string, Summoner>>(json))).Values.FirstOrDefault();
            obj.Region = region;
            return obj;
        }

        /// <summary>
        /// Get summoners by names synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerNames">List of names of the summoners you're looking for.</param>
        /// <returns>A list of summoners.</returns>
        public List<Summoner> GetSummoners(Region region, List<string> summonerNames)
        {
            var json = requester.CreateRequest(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(ByNameUrl, BuildNamesString(summonerNames)));
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
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerNames">List of names of the summoners you're looking for.</param>
        /// <returns>A list of summoners.</returns>
        public async Task<List<Summoner>> GetSummonersAsync(Region region, List<string> summonerNames)
        {
            var json = await requester.CreateRequestAsync(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(ByNameUrl, BuildNamesString(summonerNames)));
            var list = (await Task.Factory.StartNew<Dictionary<string, Summoner>>(() => JsonConvert.DeserializeObject<Dictionary<string, Summoner>>(json))).Values.ToList();
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
        public SummonerBase GetSummonerName(Region region, int summonerId)
        {
            var json = requester.CreateRequest(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(NamesUrl, summonerId));
            var child = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return new SummonerBase(child.Keys.FirstOrDefault(), child.Values.FirstOrDefault(), requester, region);
        }

        /// <summary>
        /// Get a  summoner's name and id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A summoner (id and name).</returns>
        public async Task<SummonerBase> GetSummonerNameAsync(Region region, int summonerId)
        {
            var json = await requester.CreateRequestAsync(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(NamesUrl, summonerId));
            var child = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return new SummonerBase(child.Keys.FirstOrDefault(), child.Values.FirstOrDefault(), requester, region);
        }

        /// <summary>
        /// Get a list of summoner's names and ids synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerIds">List of ids of the summoners you're looking for.</param>
        /// <returns>A list of ids and names of summoners.</returns>
        public List<SummonerBase> GetSummonersNames(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(NamesUrl, BuildIdsString(summonerIds)));
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
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerIds">List of ids of the summoners you're looking for.</param>
        /// <returns>A list of ids and names of summoners.</returns>
        public async Task<List<SummonerBase>> GetSummonersNamesAsync(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(NamesUrl, BuildIdsString(summonerIds)));
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
        /// <param name="region">Region in which you wish to look for champions.</param>
        /// <returns>A list of champions.</returns>
        public List<Champion> GetChampions(Region region)
        {
            var json = requester.CreateRequest(string.Format(ChampionRootUrl, region.ToString()));
            return JsonConvert.DeserializeObject<ChampionList>(json).Champions;
        }

        /// <summary>
        /// Get the list of champions by region asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for champions.</param>
        /// <returns>A list of champions.</returns>
        public async Task<List<Champion>> GetChampionsAsync(Region region)
        {
            var json = await requester.CreateRequestAsync(string.Format(ChampionRootUrl, region.ToString()));
            return (await Task.Factory.StartNew<ChampionList>(() => JsonConvert.DeserializeObject<ChampionList>(json))).Champions;
        }

        /// <summary>
        /// Get a champion from its id synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a champion.</param>
        /// <param name="championId">Id of the champion you're looking for.</param>
        /// <returns>A champion.</returns>
        public Champion GetChampion(Region region, int championId)
        {
            var json = requester.CreateRequest(string.Format(ChampionRootUrl, region.ToString())
                + string.Format(IdUrl, championId));
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
            var json = await requester.CreateRequestAsync(string.Format(ChampionRootUrl, region.ToString())
                + string.Format(IdUrl, championId));
            return await Task.Factory.StartNew<Champion>(() => JsonConvert.DeserializeObject<Champion>(json));
        }

        /// <summary>
        /// Get mastery pages for a list summoners' ids synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for mastery pages for a list of summoners.</param>
        /// <param name="summonerIds">A list of summoners' ids for which you wish to retrieve the masteries.</param>
        /// <returns>A dictionary where the keys are the summoners' ids and the values are lists of mastery pages.
        /// </returns>
        public Dictionary<long, List<MasteryPage>> GetMasteryPages(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(MasteriesUrl, BuildIdsString(summonerIds)));
            return ConstructMasteryDict(JsonConvert.DeserializeObject<Dictionary<string, MasteryPages>>(json));
        }

        /// <summary>
        /// Get mastery pages for a list summoners' ids asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for mastery pages for a list of summoners.</param>
        /// <param name="summonerIds">A list of summoners' ids for which you wish to retrieve the masteries.</param>
        /// <returns>A dictionary where the keys are the summoners' ids and the values are lists of mastery pages.
        /// </returns>
        public async Task<Dictionary<long, List<MasteryPage>>> GetMasteryPagesAsync(Region region
            , List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(MasteriesUrl, BuildIdsString(summonerIds)));
            return ConstructMasteryDict(
                await Task.Factory.StartNew<Dictionary<string, MasteryPages>>(() => JsonConvert.DeserializeObject<Dictionary<string, MasteryPages>>(json)));
        }

        /// <summary>
        /// Get rune pages for a list summoners' ids synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for mastery pages for a list of summoners.</param>
        /// <param name="summonerIds">A list of summoners' ids for which you wish to retrieve the masteries.</param>
        /// <returns>A dictionary where the keys are the summoners' ids and the values are lists of rune pages.
        /// </returns>
        public Dictionary<long, List<RunePage>> GetRunePages(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(RunesUrl, BuildIdsString(summonerIds)));
            return ConstructRuneDict(JsonConvert.DeserializeObject<Dictionary<string, RunePages>>(json));
        }

        /// <summary>
        /// Get rune pages for a list summoners' ids asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for mastery pages for a list of summoners.</param>
        /// <param name="summonerIds">A list of summoners' ids for which you wish to retrieve the masteries.</param>
        /// <returns>A dictionary where the keys are the summoners' ids and the values are lists of rune pages.
        /// </returns>
        public async Task<Dictionary<long, List<RunePage>>> GetRunePagesAsync(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(RunesUrl, BuildIdsString(summonerIds)));
            return ConstructRuneDict(await Task.Factory.StartNew<Dictionary<string, RunePages>>(() => JsonConvert.DeserializeObject<Dictionary<string, RunePages>>(json)));
        }

        /// <summary>
        /// Retrieves the league entries for the specified summoners.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the leagues of summoners.</param>
        /// <param name="summonerIds">The summoner ids.</param>
        /// <returns>A map of list of league entries indexed by the summoner id.</returns>
        public Dictionary<long, List<League>> GetLeagues(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(string.Format(LeagueRootUrl, region.ToString())
                + string.Format(LeagueBySummonerUrl, BuildIdsString(summonerIds)) + LeagueEntryUrl);
            return JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json);
        }

        /// <summary>
        /// Retrieves the league entries for the specified summoners asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the leagues of summoners.</param>
        /// <param name="summonerIds">The summoner ids.</param>
        /// <returns>A map of list of league entries indexed by the summoner id.</returns>
        public async Task<Dictionary<long, List<League>>> GetLeaguesAsync(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(string.Format(LeagueRootUrl, region.ToString())
                + string.Format(LeagueBySummonerUrl, BuildIdsString(summonerIds)) + LeagueEntryUrl);
            return await Task.Factory.StartNew<Dictionary<long, List<League>>>(() => JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json));
        }

        /// <summary>
        /// Retrieves the entire leagues for the specified summoners.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the leagues of summoners.</param>
        /// <param name="summonerIds">The summoner ids.</param>
        /// <returns>A map of list of leagues indexed by the summoner id.</returns>
        public Dictionary<long, List<League>> GetEntireLeagues(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(string.Format(LeagueRootUrl, region.ToString())
                + string.Format(LeagueBySummonerUrl, BuildIdsString(summonerIds)));
            return JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json);
        }

        /// <summary>
        /// Retrieves the entire leagues for the specified summoners asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the leagues of summoners.</param>
        /// <param name="summonerIds">The summoner ids.</param>
        /// <returns>A map of list of leagues indexed by the summoner id.</returns>
        public async Task<Dictionary<long, List<League>>> GetEntireLeaguesAsync(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(string.Format(LeagueRootUrl, region.ToString())
                + string.Format(LeagueBySummonerUrl, BuildIdsString(summonerIds)));
            return await Task.Factory.StartNew<Dictionary<long, List<League>>>(() => JsonConvert.DeserializeObject<Dictionary<long, List<League>>>(json));
        }

        /// <summary>
        /// Retrieves the league entries for the specified teams.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the leagues of teams.</param>
        /// <param name="teamIds">The team ids.</param>
        /// <returns>A map of list of leagues indexed by the team id.</returns>
        public Dictionary<string, List<League>> GetLeagues(Region region, List<string> teamIds)
        {
            var json = requester.CreateRequest(string.Format(LeagueRootUrl, region.ToString())
                + string.Format(LeagueByTeamUrl, BuildNamesString(teamIds)) + LeagueEntryUrl);
            return JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(json);
        }

        /// <summary>
        /// Retrieves the league entries for the specified teams asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the leagues of teams.</param>
        /// <param name="teamIds">The team ids.</param>
        /// <returns>A map of list of league entries indexed by the team id.</returns>
        public async Task<Dictionary<string, List<League>>> GetLeaguesAsync(Region region, List<string> teamIds)
        {
            var json = await requester.CreateRequestAsync(string.Format(LeagueRootUrl, region.ToString())
                + string.Format(LeagueByTeamUrl, BuildNamesString(teamIds)) + LeagueEntryUrl);
            return await Task.Factory.StartNew<Dictionary<string, List<League>>>(() => JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(json));
        }

        /// <summary>
        /// Retrieves the entire leagues for the specified teams.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the leagues of teams.</param>
        /// <param name="teamIds">The team ids.</param>
        /// <returns>A map of list of entire leagues indexed by the team id.</returns>
        public Dictionary<string, List<League>> GetEntireLeagues(Region region, List<string> teamIds)
        {
            var json = requester.CreateRequest(string.Format(LeagueRootUrl, region.ToString()) 
                + string.Format(LeagueByTeamUrl, BuildNamesString(teamIds)));
            return JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(json);
        }

        /// <summary>
        /// Retrieves the entire leagues for the specified teams asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the leagues of teams.</param>
        /// <param name="teamIds">The team ids.</param>
        /// <returns>A map of list of entire leagues indexed by the team id.</returns>
        public async Task<Dictionary<string, List<League>>> GetEntireLeaguesAsync(Region region, List<string> teamIds)
        {
            var json = await requester.CreateRequestAsync(string.Format(LeagueRootUrl, region.ToString()) 
                + string.Format(LeagueByTeamUrl, BuildNamesString(teamIds)));
            return await Task.Factory.StartNew<Dictionary<string, List<League>>>(() => JsonConvert.DeserializeObject<Dictionary<string, List<League>>>(json));
        }

        /// <summary>
        /// Get the challenger league for a particular queue.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a challenger league.</param>
        /// <param name="queue">Queue in which you wish to look for a challenger league.</param>
        /// <returns>A league which contains all the challengers for this specific region and queue.</returns>
        public League GetChallengerLeague(Region region, Queue queue)
        {
            var json = requester.CreateRequest(string.Format(LeagueRootUrl, region.ToString()) + LeagueChallengerUrl
                , new List<string>() { string.Format("type={0}", queue.ToCustomString()) });
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
            var json = await requester.CreateRequestAsync(
                string.Format(LeagueRootUrl, region.ToString()) + LeagueChallengerUrl
                , new List<string>() { string.Format("type={0}", queue.ToCustomString()) });
            return await Task.Factory.StartNew<League>(() => JsonConvert.DeserializeObject<League>(json));
        }

        /// <summary>
        /// Retrieves the league items for this specific team and not the entire league.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the league of a team.</param>
        /// <param name="teamId">The team id.</param>
        /// <returns>A list of league item for the team specified in teamId.</returns>
        [Obsolete("The league api v2.3 is deprecated, please use GetLeagues() instead.")]
        public List<LeagueItemV23> GetLeaguesV23(Region region, string teamId)
        {
            var json = requester.CreateRequest(string.Format(LeagueRootV23Url, region.ToString()) 
                + string.Format(LeagueByTeamUrl, teamId) + LeagueEntryUrl);
            return JsonConvert.DeserializeObject<List<LeagueItemV23>>(json);
        }

        /// <summary>
        /// Retrieves the league items for this specific team and not the entire league asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the league of a team.</param>
        /// <param name="teamId">The team id.</param>
        /// <returns>A list of league item for the team specified in teamId.</returns>
        [Obsolete("The league api v2.3 is deprecated, please use GetLeaguesAsync() instead.")]
        public async Task<List<LeagueItemV23>> GetLeaguesV23Async(Region region, string teamId)
        {
            var json = await requester.CreateRequestAsync(string.Format(LeagueRootV23Url, region.ToString()) 
                + string.Format(LeagueByTeamUrl, teamId) + LeagueEntryUrl);
            return await JsonConvert.DeserializeObjectAsync<List<LeagueItemV23>>(json);
        }

        /// <summary>
        /// Retrieves the entire leagues this specific team is in.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the league of a team.</param>
        /// <param name="teamId">The team id.</param>
        /// <returns>A list of leagues for the team specified in teamId.</returns>
        [Obsolete("The league api v2.3 is deprecated, please use GetEntireLeagues() instead.")]
        public List<LeagueV23> GetEntireLeaguesV23(Region region, string teamId)
        {
            var json = requester.CreateRequest(
                string.Format(LeagueRootV23Url, region.ToString()) + string.Format(LeagueByTeamUrl, teamId));
            return JsonConvert.DeserializeObject<List<LeagueV23>>(json);
        }

        /// <summary>
        /// Retrieves the entire leagues this specific team is in asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for the league of a team.</param>
        /// <param name="teamId">The team id.</param>
        /// <returns>A list of leagues for the team specified in teamId.</returns>
        [Obsolete("The league api v2.3 is deprecated, please use GetEntireLeaguesAsync() instead.")]
        public async Task<List<LeagueV23>> GetEntireLeaguesV23Async(Region region, string teamId)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(LeagueRootV23Url, region.ToString()) + string.Format(LeagueByTeamUrl, teamId));
            return await JsonConvert.DeserializeObjectAsync<List<LeagueV23>>(json);
        }

        /// <summary>
        /// Get the challenger league for a particular queue.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a challenger league.</param>
        /// <param name="queue">Queue in which you wish to look for a challenger league.</param>
        /// <returns>A league which contains all the challengers for this specific region and queue.</returns>
        [Obsolete("The league api v2.3 is deprecated, please use GetChallengerLeague() instead.")]
        public LeagueV23 GetChallengerLeagueV23(Region region, Queue queue)
        {
            var json = requester.CreateRequest(string.Format(LeagueRootV23Url, region.ToString()) + LeagueChallengerUrl
                , new List<string>() { string.Format("type={0}", queue.ToCustomString()) });
            return JsonConvert.DeserializeObject<LeagueV23>(json);
        }

        /// <summary>
        /// Get the challenger league for a particular queue asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a challenger league.</param>
        /// <param name="queue">Queue in which you wish to look for a challenger league.</param>
        /// <returns>A league which contains all the challengers for this specific region and queue.</returns>
        [Obsolete("The league api v2.3 is deprecated, please use GetChallengerLeagueAsync() instead.")]
        public async Task<LeagueV23> GetChallengerLeagueV23Async(Region region, Queue queue)
        {
            var json = await requester.CreateRequestAsync(
                string.Format(LeagueRootV23Url, region.ToString()) + LeagueChallengerUrl
                , new List<string>() { string.Format("type={0}", queue.ToCustomString()) });
            return await JsonConvert.DeserializeObjectAsync<LeagueV23>(json);
        }

        /// <summary>
        /// Get the teams for the specified ids synchronously.
        /// </summary>
        /// <param name="region">Region in which the teams are located.</param>
        /// <param name="summonerIds">List of summoner ids</param>
        /// <returns>A map of teams indexed by the summoner's id.</returns>
        public Dictionary<long, List<Team>> GetTeams(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(string.Format(TeamRootUrl, region.ToString())
                + string.Format(TeamBySummonerURL, BuildIdsString(summonerIds)));
            return JsonConvert.DeserializeObject<Dictionary<long, List<Team>>>(json);
        }

        /// <summary>
        /// Get the teams for the specified ids asynchronously.
        /// </summary>
        /// <param name="region">Region in which the teams are located.</param>
        /// <param name="summonerIds">List of summoner ids.</param>
        /// <returns>A map of teams indexed by their id.</returns>
        public async Task<Dictionary<long, List<Team>>> GetTeamsAsync(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(string.Format(TeamRootUrl, region.ToString())
                + string.Format(TeamBySummonerURL, BuildIdsString(summonerIds)));
            return await Task.Factory.StartNew<Dictionary<long, List<Team>>>(() => JsonConvert.DeserializeObject<Dictionary<long, List<Team>>>(json));
        }

        /// <summary>
        /// Get the teams for the specified ids synchronously.
        /// </summary>
        /// <param name="region">Region in which the teams are located.</param>
        /// <param name="teamIds">List of string of the teams' ids.</param>
        /// <returns>A map of teams indexed by their id.</returns>
        public Dictionary<string, Team> GetTeams(Region region, List<string> teamIds)
        {
            var json = requester.CreateRequest(string.Format(TeamRootUrl, region.ToString())
                + string.Format(IdUrl, BuildNamesString(teamIds)));
            return JsonConvert.DeserializeObject<Dictionary<string, Team>>(json);
        }

        /// <summary>
        /// Get the teams for the specified ids asynchronously.
        /// </summary>
        /// <param name="region">Region in which the teams are located.</param>
        /// <param name="teamIds">List of string of the teams' ids.</param>
        /// <returns>A map of teams indexed by their id.</returns>
        public async Task<Dictionary<string, Team>> GetTeamsAsync(Region region, List<string> teamIds)
        {
            var json = await requester.CreateRequestAsync(string.Format(TeamRootUrl, region.ToString())
                + string.Format(IdUrl, BuildNamesString(teamIds)));
            return await Task.Factory.StartNew<Dictionary<string, Team>>(() => JsonConvert.DeserializeObject<Dictionary<string, Team>>(json));
        }

        /// <summary>
        /// Get the teams for the specified ids synchronously.
        /// </summary>
        /// <param name="region">Region in which the teams are located.</param>
        /// <param name="teamIds">List of string of the teams' ids.</param>
        /// <returns>A map of teams indexed by their id.</returns>
        [Obsolete("The teams api v2.2 is deprecated, please use GetTeams() instead.")]
        public Dictionary<string, TeamV22> GetTeamsV22(Region region, List<string> teamIds)
        {
            var json = requester.CreateRequest(string.Format(TeamRootV22Url, region.ToString())
                + string.Format(IdUrl, BuildNamesString(teamIds)));
            return JsonConvert.DeserializeObject<Dictionary<string, TeamV22>>(json);
        }

        /// <summary>
        /// Get the teams for the specified ids asynchronously.
        /// </summary>
        /// <param name="region">Region in which the teams are located.</param>
        /// <param name="teamIds">List of string of the teams' ids.</param>
        /// <returns>A map of teams indexed by their id.</returns>
        [Obsolete("The teams api v2.2 is deprecated, please use GetTeams() instead.")]
        public async Task<Dictionary<string, TeamV22>> GetTeamsV22Async(Region region, List<string> teamIds)
        {
            var json = await requester.CreateRequestAsync(string.Format(TeamRootV22Url, region.ToString())
                + string.Format(IdUrl, BuildNamesString(teamIds)));
            return await JsonConvert.DeserializeObjectAsync<Dictionary<string, TeamV22>>(json);
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

        private string BuildIdsString(List<int> ids)
        {
            string concatenatedIds = string.Empty;
            for (int i = 0; i < ids.Count; i++)
            {
                if (i < ids.Count - 1)
                {
                    concatenatedIds += ids[i].ToString() + ",";
                }
                else
                {
                    concatenatedIds += ids[i];
                }
            }
            return concatenatedIds;
        }

        private string BuildNamesString(List<string> names)
        {
            string concatenatedNames = string.Empty;
            for (int i = 0; i < names.Count; i++)
            {
                if (i < names.Count - 1)
                {
                    concatenatedNames += Uri.EscapeDataString(names[i]) + ",";
                }
                else
                {
                    concatenatedNames += Uri.EscapeDataString(names[i]);
                }
            }
            return concatenatedNames;
        }
    }
}
