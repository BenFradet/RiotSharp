using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotSharp
{
    /// <summary>
    /// Class representing the name and id of a Summoner in the API.
    /// </summary>
    public class SummonerBase : Thing
    {
        private const string RootUrl = "/api/lol/{0}/v1.1/summoner";
        private const string MasteriesUrl = "/{0}/masteries";
        private const string RunesUrl = "/{0}/runes";

        private const string GameRootUrl = "/api/lol/{0}/v1.1/game";
        private const string RecentGamesUrl = "/by-summoner/{0}/recent";

        private const string LeagueRootUrl = "/api/{0}/v2.1/league";
        private const string LeagueBySummonerUrl = "/by-summoner/{0}";

        private const string StatsRootUrl = "/api/lol/{0}/v1.1/stats";
        private const string StatsSummaryUrl = "/by-summoner/{0}/summary";
        private const string StatsRankedUrl = "/by-summoner/{0}/ranked";

        protected RiotApi api;
        protected IRequester requester;
        protected Region region;

        public SummonerBase(RiotApi api, JToken json, IRequester requester, Region region)
        {
            this.api = api;
            this.requester = requester;
            this.region = region;
            JsonConvert.PopulateObject(json.ToString(), this, RiotApi.JsonSerializerSettings);
        }

        /// <summary>
        /// Summoner ID.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }
        /// <summary>
        /// Summoner name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        public Collection<RunePage> GetRunePages()
        {
            var request = requester.CreateRequest(string.Format(RootUrl, region)
                + string.Format(RunesUrl, Id));
            var response = (HttpWebResponse)request.GetResponse();
            var result = requester.GetResponseString(response.GetResponseStream());
            var json = JObject.Parse(result);

            return new Collection<RunePage>(api, json, requester, region, "pages");
        }

        public Collection<MasteryPage> GetMasteryPages()
        {
            var request = requester.CreateRequest(string.Format(RootUrl, region)
                + string.Format(MasteriesUrl, Id));
            var response = (HttpWebResponse)request.GetResponse();
            var result = requester.GetResponseString(response.GetResponseStream());
            var json = JObject.Parse(result);

            return new Collection<MasteryPage>(api, json, requester, region, "pages");
        }

        public Collection<Game> GetRecentGames()
        {
            var request = requester.CreateRequest(string.Format(GameRootUrl, region)
                + string.Format(RecentGamesUrl, Id));
            var response = (HttpWebResponse)request.GetResponse();
            var result = requester.GetResponseString(response.GetResponseStream());
            var json = JObject.Parse(result);

            return new Collection<Game>(api, json, requester, region, "games");
        }

        public Collection<League> GetLeagues()
        {
            var request = requester.CreateRequest(string.Format(LeagueRootUrl, region)
                + string.Format(LeagueBySummonerUrl, Id));
            var response = (HttpWebResponse)request.GetResponse();
            var result = requester.GetResponseString(response.GetResponseStream());
            var json = JObject.Parse(result);

            return new Collection<League>(api, json, requester, region);
        }

        public Collection<PlayerStatsSummary> GetStatsSummaries(Season season)
        {
            var request = requester.CreateRequest(string.Format(StatsRootUrl, region)
                + string.Format(StatsSummaryUrl, Id), string.Format("season={0}", season.ToString().ToUpper()));
            var response = (HttpWebResponse)request.GetResponse();
            var result = requester.GetResponseString(response.GetResponseStream());
            var json = JObject.Parse(result);

            return new Collection<PlayerStatsSummary>(api, json, requester, region, "playerStatSummaries");
        }

        public Collection<ChampionStats> GetStatsRanked(Season season)
        {
            var request = requester.CreateRequest(string.Format(StatsRootUrl, region)
                + string.Format(StatsRankedUrl, Id), string.Format("season={0}", season.ToString().ToUpper()));
            var response = (HttpWebResponse)request.GetResponse();
            var result = requester.GetResponseString(response.GetResponseStream());
            var json = JObject.Parse(result);

            return new Collection<ChampionStats>(api, json, requester, region, "champions");
        }
    }
}
