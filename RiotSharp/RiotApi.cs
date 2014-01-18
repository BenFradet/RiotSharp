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
        private const string SummonerRootV11Url = "/api/lol/{0}/v1.1/summoner";
        private const string SummonerRootV12Url = "/api/lol/{0}/v1.2/summoner";
        private const string SummonerRootUrl = "/api/lol/{0}/v1.3/summoner";
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
            return new Summoner(
                JObject.Parse(json).Children().FirstOrDefault().Children().FirstOrDefault().ToString()
                , requester, region);
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
            return new Summoner(
                JObject.Parse(json).Children().FirstOrDefault().Children().FirstOrDefault().ToString()
                , requester, region);
        }

        /// <summary>
        /// Get a summoner by id synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        [Obsolete("The summoner api v1.2 is deprecated, please use GetSummoner() instead.")]
        public Summoner GetSummonerV12(Region region, int summonerId)
        {
            var json = requester.CreateRequest(string.Format(SummonerRootV12Url, region.ToString())
                + string.Format(IdUrl, summonerId));
            return new Summoner(json, requester, region);
        }

        /// <summary>
        /// Get a summoner by id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        [Obsolete("The summoner api v1.2 is deprecated, please use GetSummonerAsync() instead.")]
        public async Task<Summoner> GetSummonerV12Async(Region region, int summonerId)
        {
            var json = await requester.CreateRequestAsync(string.Format(SummonerRootV12Url, region.ToString())
                + string.Format(IdUrl, summonerId));
            return new Summoner(json, requester, region);
        }

        /// <summary>
        /// Get a summoner by id synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        [Obsolete("The summoner api v1.1 is deprecated, please use GetSummoner() instead.")]
        public SummonerV11 GetSummonerV11(Region region, int summonerId)
        {
            var json = requester.CreateRequest(string.Format(SummonerRootV11Url, region.ToString())
                + string.Format(IdUrl, summonerId));
            return new SummonerV11(json, requester, region);
        }

        /// <summary>
        /// Get a summoner by id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        [Obsolete("The summoner api v1.1 is deprecated, please use GetSummonerAsync() instead.")]
        public async Task<SummonerV11> GetSummonerV11Async(Region region, int summonerId)
        {
            var json = await requester.CreateRequestAsync(string.Format(SummonerRootV11Url, region.ToString())
                + string.Format(IdUrl, summonerId));
            return new SummonerV11(json, requester, region);
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

            var summoners = new List<Summoner>();
            foreach(var child in JObject.Parse(json).Children())
            {
                summoners.Add(new Summoner(child.Children().FirstOrDefault().ToString(), requester, region));
            }
            return summoners;
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

            var summoners = new List<Summoner>();
            foreach (var child in JObject.Parse(json).Children())
            {
                summoners.Add(new Summoner(child.Children().FirstOrDefault().ToString(), requester, region));
            }
            return summoners;
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
            return new Summoner(
                JObject.Parse(json).Children().FirstOrDefault().Children().FirstOrDefault().ToString()
                , requester, region);
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
            return new Summoner(
                JObject.Parse(json).Children().FirstOrDefault().Children().FirstOrDefault().ToString()
                , requester, region);
        }

        /// <summary>
        /// Get a summoner by name synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerName">Name of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        [Obsolete("The summoner api v1.2 is deprecated, please use GetSummoner() instead.")]
        public Summoner GetSummonerV12(Region region, string summonerName)
        {
            var json = requester.CreateRequest(string.Format(SummonerRootV12Url, region.ToString())
                + string.Format(NameUrl, Uri.EscapeDataString(summonerName)));
            return new Summoner(json, requester, region);
        }

        /// <summary>
        /// Get a summoner by name asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerName">Name of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        [Obsolete("The summoner api v1.1 is deprecated, please use GetSummonerAsync() instead.")]
        public async Task<Summoner> GetSummonerV12Async(Region region, string summonerName)
        {
            var json = await requester.CreateRequestAsync(string.Format(SummonerRootV12Url, region.ToString())
                + string.Format(NameUrl, Uri.EscapeDataString(summonerName)));
            return new Summoner(json, requester, region);
        }

        /// <summary>
        /// Get a summoner by name synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerName">Name of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        [Obsolete("The summoner api v1.1 is deprecated, please use GetSummoner() instead.")]
        public SummonerV11 GetSummonerV11(Region region, string summonerName)
        {
            var json = requester.CreateRequest(string.Format(SummonerRootV11Url, region.ToString()) 
                + string.Format(NameUrl, Uri.EscapeDataString(summonerName)));
            return new SummonerV11(json, requester, region);
        }

        /// <summary>
        /// Get a summoner by name asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerName">Name of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        [Obsolete("The summoner api v1.1 is deprecated, please use GetSummonerAsync() instead.")]
        public async Task<SummonerV11> GetSummonerV11Async(Region region, string summonerName)
        {
            var json = await requester.CreateRequestAsync(string.Format(SummonerRootV11Url, region.ToString())
                + string.Format(NameUrl, Uri.EscapeDataString(summonerName)));
            return new SummonerV11(json, requester, region);
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
                + string.Format(NameUrl, BuildNamesString(summonerNames)));

            var summoners = new List<Summoner>();
            foreach (var child in JObject.Parse(json).Children())
            {
                summoners.Add(new Summoner(child.Children().FirstOrDefault().ToString(), requester, region));
            }
            return summoners;
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
                + string.Format(NameUrl, BuildNamesString(summonerNames)));

            var summoners = new List<Summoner>();
            foreach (var child in JObject.Parse(json).Children())
            {
                summoners.Add(new Summoner(child.Children().FirstOrDefault().ToString(), requester, region));
            }
            return summoners;
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
        /// Get a list of summoner's names and ids synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerIds">List of ids of the summoners you're looking for.</param>
        /// <returns>A collection of ids and names of summoners.</returns>
        [Obsolete("The summoner api v1.2 is deprecated, please use GetSummonersNames() instead.")]
        public Collection<SummonerBase> GetSummonersNamesV12(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(string.Format(SummonerRootV12Url, region.ToString())
                + string.Format(NamesUrl, BuildIdsString(summonerIds)));
            return new Collection<SummonerBase>(json, requester, region, "summoners");
        }

        /// <summary>
        /// Get a list of summoner's names and ids asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerIds">List of ids of the summoners you're looking for.</param>
        /// <returns>A collection of ids and names of summoners.</returns>
        [Obsolete("The summoner api v1.2 is deprecated, please use GetSummonersNamesAsync() instead.")]
        public async Task<Collection<SummonerBase>> GetSummonersNamesV12Async(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(string.Format(SummonerRootV12Url, region.ToString())
                + string.Format(NamesUrl, BuildIdsString(summonerIds)));
            return new Collection<SummonerBase>(json, requester, region, "summoners");
        }

        /// <summary>
        /// Get a list of summoner's names and ids synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerIds">List of ids of the summoners you're looking for.</param>
        /// <returns>A collection of ids and names of summoners.</returns>
        [Obsolete("The summoner api v1.1 is deprecated, please use GetSummonersNames() instead.")]
        public Collection<SummonerBase> GetSummonersNamesV11(Region region, List<int> summonerIds)
        {
            var json = requester.CreateRequest(string.Format(SummonerRootV11Url, region.ToString())
                + string.Format(NamesUrl, BuildIdsString(summonerIds)));
            return new Collection<SummonerBase>(json, requester, region, "summoners");
        }

        /// <summary>
        /// Get a list of summoner's names and ids asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for summoners.</param>
        /// <param name="summonerIds">List of ids of the summoners you're looking for.</param>
        /// <returns>A collection of ids and names of summoners.</returns>
        [Obsolete("The summoner api v1.1 is deprecated, please use GetSummonersNamesAsync() instead.")]
        public async Task<Collection<SummonerBase>> GetSummonersNamesV11Async(Region region, List<int> summonerIds)
        {
            var json = await requester.CreateRequestAsync(string.Format(SummonerRootV11Url, region.ToString())
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
