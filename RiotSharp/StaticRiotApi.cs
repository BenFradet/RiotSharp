using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    public class StaticRiotApi
    {
        private const string ChampionRootUrl = "/api/lol/static-data/{0}/v1/champion";
        private const string IdUrl = "/{0}";
        private const string ChampionCacheKey = "champions";

        private Requester requester;

        private static StaticRiotApi instance;
        public static StaticRiotApi GetInstance(string apiKey)
        {
            if (instance == null || apiKey != Requester.ApiKey)
            {
                instance = new StaticRiotApi(apiKey);
            }
            return instance;
        }

        private StaticRiotApi(string apiKey)
        {
            requester = Requester.Instance;
            Requester.RootDomain = "prod.api.pvp.net";
            Requester.ApiKey = apiKey;
        }

        public ChampionListStatic GetChampions(Region region, DataRequested dataRequested = DataRequested.all
            , Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ChampionListStaticWrapper>(ChampionCacheKey);
            if (wrapper == null || language != wrapper.Language || dataRequested != wrapper.DataRequested)
            {
                var json = requester.CreateRequest(string.Format(ChampionRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                        , dataRequested == DataRequested.none ? string.Empty 
                            : string.Format("champData={0}", dataRequested.ToString()) });
                var champs = JsonConvert.DeserializeObject<ChampionListStatic>(json);

                wrapper = new ChampionListStaticWrapper(champs, language, dataRequested);
                Cache.Add<ChampionListStaticWrapper>(ChampionCacheKey, wrapper);
            }
            return wrapper.ChampionListStatic;
        }

        public async Task<ChampionListStatic> GetChampionsAsync(Region region
            , DataRequested dataRequested = DataRequested.all, Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ChampionListStaticWrapper>(ChampionCacheKey);
            if (wrapper == null || language != wrapper.Language || dataRequested != wrapper.DataRequested)
            {
                var json = await requester.CreateRequestAsync(string.Format(ChampionRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                        , dataRequested == DataRequested.none ? string.Empty 
                            : string.Format("champData={0}", dataRequested.ToString()) });
                var champs = await JsonConvert.DeserializeObjectAsync<ChampionListStatic>(json);

                wrapper = new ChampionListStaticWrapper(champs, language, dataRequested);
                Cache.Add<ChampionListStaticWrapper>(ChampionCacheKey, wrapper);
            }
            return wrapper.ChampionListStatic;
        }

        public ChampionStatic GetChampion(Region region, int championId
            , DataRequested dataRequested = DataRequested.all, Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ChampionListStaticWrapper>(ChampionCacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.DataRequested == dataRequested)
            {
                var champ = wrapper.ChampionListStatic.Data.Values.Where((c) => c.Key == championId);
                if (champ.Count() >= 0)
                {
                    return champ.First();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                var json = requester.CreateRequest(string.Format(ChampionRootUrl, region.ToString())
                    + string.Format(IdUrl, championId)
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                        , dataRequested == DataRequested.none ? string.Empty 
                            : string.Format("champData={0}", dataRequested.ToString()) });
                return JsonConvert.DeserializeObject<ChampionStatic>(json);
            }
        }

        public async Task<ChampionStatic> GetChampionAsync(Region region, int championId
            , DataRequested dataRequested = DataRequested.all, Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ChampionListStaticWrapper>(ChampionCacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.DataRequested == dataRequested)
            {
                var champ = wrapper.ChampionListStatic.Data.Values.Where((c) => c.Key == championId);
                if (champ.Count() >= 0)
                {
                    return champ.First();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                var json = await requester.CreateRequestAsync(string.Format(ChampionRootUrl, region.ToString())
                    + string.Format(IdUrl, championId)
                    , new List<string>() { string.Format("local={0}", language.ToString())
                        , dataRequested == DataRequested.none ? string.Empty 
                            : string.Format("champData={0}", dataRequested.ToString()) });
                return await JsonConvert.DeserializeObjectAsync<ChampionStatic>(json);
            }
        }
    }
}
