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

        public ChampionListStatic GetChampions(Region region, Language language = Language.en_US
            , DataRequested dataRequested = DataRequested.all)
        {
            var wrapper = Cache.Get<ChampionListStaticWrapper>(ChampionCacheKey);
            if (wrapper == null || language != wrapper.Language || dataRequested != wrapper.DataRequested)
            {
                var json = requester.CreateRequest(string.Format(ChampionRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                    , string.Format("champData={0}", dataRequested.ToString()) });
                var champs = JsonConvert.DeserializeObject<ChampionListStatic>(json);

                wrapper = new ChampionListStaticWrapper(champs, language, dataRequested);
                Cache.Add<ChampionListStaticWrapper>(ChampionCacheKey, wrapper);
            }
            return wrapper.ChampionListStatic;
        }

        public async Task<ChampionListStatic> GetChampionsAsync(Region region, Language language = Language.en_US
            , DataRequested dataRequested = DataRequested.all)
        {
            var wrapper = Cache.Get<ChampionListStaticWrapper>(ChampionCacheKey);
            if (wrapper == null || language != wrapper.Language || dataRequested != wrapper.DataRequested)
            {
                var json = await requester.CreateRequestAsync(string.Format(ChampionRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                    , string.Format("champData={0}", dataRequested.ToString()) });
                var champs = await JsonConvert.DeserializeObjectAsync<ChampionListStatic>(json);

                wrapper = new ChampionListStaticWrapper(champs, language, dataRequested);
                Cache.Add<ChampionListStaticWrapper>(ChampionCacheKey, wrapper);
            }
            return wrapper.ChampionListStatic;
        }
    }
}
