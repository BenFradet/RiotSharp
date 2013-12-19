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
    public class RiotApi
    {
        private const string SummonerRootUrl = "/api/lol/{0}/v1.1/summoner";
        private const string NameUrl = "/by-name/{0}";
        private const string IdUrl = "/{0}";
        private const string NamesUrl = "/{0}/name";

        private const string ChampionRootUrl = "/api/lol/{0}/v1.1/champion";

        private Requester requester;

        internal static JsonSerializerSettings JsonSerializerSettings { get; set; }

        private static RiotApi instance;
        /// <summary>
        /// Get an instance of RiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="isProdApi">Indicates if this is a production api or not.</param>
        /// <returns>An instance of RiotApi.</returns>
        public static RiotApi GetInstance(string apiKey, bool isProdApi)
        {
            if (instance == null || apiKey != Requester.ApiKey || isProdApi != Requester.IsProdApi)
            {
                instance = new RiotApi(apiKey, isProdApi);
            }
            return instance;
        }
        
        static RiotApi()
        {
            Requester.RootDomain = "prod.api.pvp.net";

            JsonSerializerSettings = new JsonSerializerSettings();
            JsonSerializerSettings.CheckAdditionalContent = false;
            JsonSerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
        }

        private RiotApi(string apiKey, bool isProdApi)
        {
            requester = Requester.Instance;
            Requester.ApiKey = apiKey;
            Requester.IsProdApi = isProdApi;
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
            return new Summoner(json, requester, region);
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
            return new Summoner(json, requester, region);
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
                + string.Format(NameUrl, Uri.EscapeDataString(summonerName)));
            return new Summoner(json, requester, region);
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
                + string.Format(NameUrl, Uri.EscapeDataString(summonerName)));
            return new Summoner(json, requester, region);
        }

        /// <summary>
        /// Get a list of summoner's name and id by their id synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerIds">List of ids of the summoners you're looking for.</param>
        /// <returns>A collection of ids and names of summoners.</returns>
        public Collection<SummonerBase> GetSummoners(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(NamesUrl, BuildIdsString(summonerIds)));
            return new Collection<SummonerBase>(json, requester, region, "summoners");
        }

        /// <summary>
        /// Get a list of summoner's name and id by their id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerIds">List of ids of the summoners you're looking for.</param>
        /// <returns>A collection of ids and names of summoners.</returns>
        public async Task<Collection<SummonerBase>> GetSummonersAsync(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(string.Format(SummonerRootUrl, region.ToString())
                + string.Format(NamesUrl, BuildIdsString(summonerIds)));
            return new Collection<SummonerBase>(json, requester, region, "summoners");
        }

        /// <summary>
        /// Get the list of champions by region synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for champions.</param>
        /// <returns>A collection of champions.</returns>
        public Collection<Champion> GetChampions(Region region)
        {
            var json = requester.CreateRequest(string.Format(ChampionRootUrl, region.ToString()));
            return new Collection<Champion>(json, requester, region, "champions");
        }

        /// <summary>
        /// Get the list of champions by region asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for champions.</param>
        /// <returns>A collection of champions.</returns>
        public async Task<Collection<Champion>> GetChampionsAsync(Region region)
        {
            var json = await requester.CreateRequestAsync(string.Format(ChampionRootUrl, region.ToString()));
            return new Collection<Champion>(json, requester, region, "champions");
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
    }
}
