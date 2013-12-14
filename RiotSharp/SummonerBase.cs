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
    public class SummonerBase : Thing
    {
        private const String RootUrl = "/api/lol/{0}/v1.1/summoner";
        private const String MasteriesUrl = "/{0}/masteries";
        private const String RunesUrl = "/{0}/runes";

        private const String GameRootUrl = "/api/lol/{0}/v1.1/game";
        private const String RecentGamesUrl = "/by-summoner/{0}/recent";

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

        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }

        public Collection<RunePage> GetRunePages()
        {
            var request = requester.CreateRequest(String.Format(RootUrl, region)
                + String.Format(RunesUrl, Id));
            var response = (HttpWebResponse)request.GetResponse();
            var result = requester.GetResponseString(response.GetResponseStream());
            var json = JObject.Parse(result);

            return new Collection<RunePage>(api, json, requester, "pages", region);
        }

        public Collection<MasteryPage> GetMasteryPages()
        {
            var request = requester.CreateRequest(String.Format(RootUrl, region)
                + String.Format(MasteriesUrl, Id));
            var response = (HttpWebResponse)request.GetResponse();
            var result = requester.GetResponseString(response.GetResponseStream());
            var json = JObject.Parse(result);

            return new Collection<MasteryPage>(api, json, requester, "pages", region);
        }

        public Collection<Game> GetRecentGames()
        {
            var request = requester.CreateRequest(String.Format(GameRootUrl, region)
                + String.Format(RecentGamesUrl, Id));
            var response = (HttpWebResponse)request.GetResponse();
            var result = requester.GetResponseString(response.GetResponseStream());
            var json = JObject.Parse(result);

            return new Collection<Game>(api, json, requester, "games", region);
        }
    }
}
