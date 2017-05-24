using Newtonsoft.Json;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using RiotSharp.Interfaces;
using RiotSharp.StaticDataEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiotSharp.Misc;
using RiotSharp.StaticDataEndpoint.Champion;
using RiotSharp.StaticDataEndpoint.Champion.Cache;
using RiotSharp.StaticDataEndpoint.Item;
using RiotSharp.StaticDataEndpoint.Item.Cache;
using RiotSharp.StaticDataEndpoint.LanguageStrings;
using RiotSharp.StaticDataEndpoint.LanguageStrings.Cache;
using RiotSharp.StaticDataEndpoint.Map;
using RiotSharp.StaticDataEndpoint.Map.Cache;
using RiotSharp.StaticDataEndpoint.Mastery;
using RiotSharp.StaticDataEndpoint.Mastery.Cache;
using RiotSharp.StaticDataEndpoint.Realm;
using RiotSharp.StaticDataEndpoint.Realm.Cache;
using RiotSharp.StaticDataEndpoint.Rune;
using RiotSharp.StaticDataEndpoint.Rune.Cache;
using RiotSharp.StaticDataEndpoint.SummonerSpell;
using RiotSharp.StaticDataEndpoint.SummonerSpell.Cache;

namespace RiotSharp
{
    public class StaticRiotApi : IStaticRiotApi
    {
        #region Private Fields     
        private const string StaticDataRootUrl = "/lol/static-data/v3/";

        private const string ChampionsUrl = "champions";
        private const string ChampionByIdUrl = "champions/{0}";
        private const string ChampionsCacheKey = "champions";
        private const string ChampionByIdCacheKey = "champion";

        private const string ItemsUrl = "items";
        private const string ItemByIdUrl = "items/{0}";
        private const string ItemsCacheKey = "items";
        private const string ItemByIdCacheKey = "item";

        private const string LanguageStringsUrl = "language-strings";
        private const string LanguageStringsCacheKey = "language-strings";

        private const string LanguagesUrl = "languages";
        private const string LanguagesCacheKey = "languages";

        private const string MapRootUrl = "/api/lol/static-data/{0}/v1.2/map";
        private const string MapCacheKey = "map";

        private const string MasteryRootUrl = "/api/lol/static-data/{0}/v1.2/mastery";
        private const string MasteriesCacheKey = "masteries";
        private const string MasteryCacheKey = "mastery";

        private const string RealmRootUrl = "/api/lol/static-data/{0}/v1.2/realm";
        private const string RealmCacheKey = "realm";

        private const string RuneRootUrl = "/api/lol/static-data/{0}/v1.2/rune";
        private const string RunesCacheKey = "runes";
        private const string RuneCacheKey = "rune";

        private const string SummonerSpellRootUrl = "/api/lol/static-data/{0}/v1.2/summoner-spell";
        private const string SummonerSpellsCacheKey = "spells";
        private const string SummonerSpellCacheKey = "spell";

        private const string VersionRootUrl = "/api/lol/static-data/{0}/v1.2/versions";
        private const string VersionCacheKey = "versions";

        private const string IdUrl = "/{0}";

        private const string RootDomain = "global.api.pvp.net";

        private IRequester requester;

        private ICache cache;
        private readonly TimeSpan DefaultSlidingExpiry = new TimeSpan(0, 30, 0);

        private static StaticRiotApi instance;
        #endregion      
      
        /// <summary>
        /// Get the instance of StaticRiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <returns>The instance of StaticRiotApi.</returns>
        public static StaticRiotApi GetInstance(string apiKey)
        {
            if (instance == null || 
                Requesters.StaticApiRequester == null ||
                apiKey != Requesters.StaticApiRequester.ApiKey)
            {
                instance = new StaticRiotApi(apiKey);
            }
            return instance;
        }

        private StaticRiotApi(string apiKey)
        {
            Requesters.StaticApiRequester = new Requester(apiKey);
            requester = Requesters.StaticApiRequester;
            cache = new Cache();
        }

        public StaticRiotApi(IRequester requester, ICache cache)
        {
            if (requester == null)
                 throw new ArgumentNullException(nameof(requester));
            if (cache == null)
                throw new ArgumentNullException(nameof(cache));
            this.requester = requester;
            this.cache = cache;
        }

        #region Champions
        public ChampionListStatic GetChampions(Region region, ChampionData championData = ChampionData.basic,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ChampionListStaticWrapper>(ChampionsCacheKey);
            if (wrapper == null || language != wrapper.Language || championData != wrapper.ChampionData)
            {
                var json = requester.CreateGetRequest(StaticDataRootUrl + ChampionsUrl, region,
                    new List<string> {
                        string.Format("locale={0}", language.ToString()),
                        championData == ChampionData.basic ?
                        string.Empty :
                        string.Format("champData={0}", championData.ToString())
                    });
                var champs = JsonConvert.DeserializeObject<ChampionListStatic>(json);
                wrapper = new ChampionListStaticWrapper(champs, language, championData);
                cache.Add(ChampionsCacheKey, wrapper, DefaultSlidingExpiry);
            }
            return wrapper.ChampionListStatic;
        }
    
        public async Task<ChampionListStatic> GetChampionsAsync(Region region,
            ChampionData championData = ChampionData.basic, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ChampionListStaticWrapper>(ChampionsCacheKey);
            if (wrapper != null && language == wrapper.Language && championData == wrapper.ChampionData)
            {
                return wrapper.ChampionListStatic;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + ChampionsUrl, region,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    championData == ChampionData.basic ?
                        string.Empty :
                        string.Format("champData={0}", championData.ToString())
                });
            var champs = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<ChampionListStatic>(json));
            wrapper = new ChampionListStaticWrapper(champs, language, championData);
            cache.Add(ChampionsCacheKey, wrapper, DefaultSlidingExpiry);
            return wrapper.ChampionListStatic;
        }
     
        public ChampionStatic GetChampion(Region region, int championId,
            ChampionData championData = ChampionData.basic, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ChampionStaticWrapper>(ChampionByIdCacheKey + championId);
            if (wrapper != null && wrapper.Language == language && wrapper.ChampionData == championData)
            {
                return wrapper.ChampionStatic;
            }
            else
            {
                var listWrapper = cache.Get<string, ChampionListStaticWrapper>(ChampionsCacheKey);
                if (listWrapper != null && listWrapper.Language == language &&
                    listWrapper.ChampionData == championData)
                {
                    return listWrapper.ChampionListStatic.Champions.Values.FirstOrDefault(c => c.Id == championId);
                }
                else
                {
                    var json = requester.CreateGetRequest(StaticDataRootUrl + string.Format(ChampionByIdUrl, championId), region,
                        new List<string>
                        {
                            string.Format("locale={0}", language.ToString()),
                            championData == ChampionData.basic ?
                            string.Empty :
                            string.Format("champData={0}", championData.ToString())
                        });
                    var champ = JsonConvert.DeserializeObject<ChampionStatic>(json);
                    cache.Add(ChampionByIdCacheKey + championId, new ChampionStaticWrapper(champ, language, championData),
                        DefaultSlidingExpiry);
                    return champ;
                }
            }
        }
     
        public async Task<ChampionStatic> GetChampionAsync(Region region, int championId,
            ChampionData championData = ChampionData.basic, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ChampionStaticWrapper>(ChampionByIdCacheKey + championId);
            if (wrapper != null && wrapper.Language == language && wrapper.ChampionData == championData)
            {
                return wrapper.ChampionStatic;
            }
            var listWrapper = cache.Get<string, ChampionListStaticWrapper>(ChampionsCacheKey);
            if (listWrapper != null && listWrapper.Language == language &&
                listWrapper.ChampionData == championData)
            {
                return listWrapper.ChampionListStatic.Champions.Values.FirstOrDefault(c => c.Id == championId);
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + string.Format(ChampionByIdUrl, championId), region,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    championData == ChampionData.basic ?
                        string.Empty :
                        string.Format("champData={0}", championData.ToString())
                });
            var champ = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<ChampionStatic>(json));
            cache.Add(ChampionByIdCacheKey + championId, new ChampionStaticWrapper(champ, language, championData),
                DefaultSlidingExpiry);
            return champ;
        }
        #endregion

        #region Items
        public ItemListStatic GetItems(Region region, ItemData itemData = ItemData.basic,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ItemListStaticWrapper>(ItemsCacheKey);
            if (wrapper == null || language != wrapper.Language || itemData != wrapper.ItemData)
            {
                var json = requester.CreateGetRequest(StaticDataRootUrl + ItemsUrl, region,
                    new List<string>
                    {
                        string.Format("locale={0}", language.ToString()),
                        itemData == ItemData.basic ?
                        string.Empty :
                        string.Format("itemListData={0}", itemData.ToString())
                    });
                var items = JsonConvert.DeserializeObject<ItemListStatic>(json);
                wrapper = new ItemListStaticWrapper(items, language, itemData);
                cache.Add(ItemsCacheKey, wrapper, DefaultSlidingExpiry);
            }
            return wrapper.ItemListStatic;
        }
  
        public async Task<ItemListStatic> GetItemsAsync(Region region, ItemData itemData = ItemData.basic,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ItemListStaticWrapper>(ItemsCacheKey);
            if (wrapper != null && language == wrapper.Language && itemData == wrapper.ItemData)
            {
                return wrapper.ItemListStatic;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + ItemsUrl, region,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    itemData == ItemData.basic ?
                        string.Empty :
                        string.Format("itemListData={0}", itemData.ToString())
                });
            var items = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<ItemListStatic>(json));
            wrapper = new ItemListStaticWrapper(items, language, itemData);
            cache.Add(ItemsCacheKey, wrapper, DefaultSlidingExpiry);
            return wrapper.ItemListStatic;
        }
    
        public ItemStatic GetItem(Region region, int itemId, ItemData itemData = ItemData.basic,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ItemStaticWrapper>(ItemByIdCacheKey + itemId);
            if (wrapper != null && wrapper.Language == language && wrapper.ItemData == itemData)
            {
                return wrapper.ItemStatic;
            }
            else
            {
                var listWrapper = cache.Get<string, ItemListStaticWrapper>(ItemsCacheKey);
                if (listWrapper != null && listWrapper.Language == language && listWrapper.ItemData == itemData)
                {
                    if (listWrapper.ItemListStatic.Items.ContainsKey(itemId))
                    {
                        return listWrapper.ItemListStatic.Items[itemId];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var json = requester.CreateGetRequest(StaticDataRootUrl + string.Format(ItemByIdUrl, itemId), region,
                        new List<string>
                        {
                            string.Format("locale={0}", language.ToString()),
                            itemData == ItemData.basic ?
                            string.Empty :
                            string.Format("itemData={0}", itemData.ToString())
                        });
                    var item = JsonConvert.DeserializeObject<ItemStatic>(json);
                    cache.Add(ItemByIdCacheKey + itemId, new ItemStaticWrapper(item, language, itemData),
                        DefaultSlidingExpiry);
                    return item;
                }
            }
        }
  
        public async Task<ItemStatic> GetItemAsync(Region region, int itemId, ItemData itemData = ItemData.basic,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ItemStaticWrapper>(ItemByIdCacheKey + itemId);
            if (wrapper != null && wrapper.Language == language && wrapper.ItemData == itemData)
            {
                return wrapper.ItemStatic;
            }
            var listWrapper = cache.Get<String, ItemListStaticWrapper>(ItemsCacheKey);
            if (listWrapper != null && listWrapper.Language == language && listWrapper.ItemData == itemData)
            {
                return listWrapper.ItemListStatic.Items.ContainsKey(itemId) ?
                    listWrapper.ItemListStatic.Items[itemId] : null;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + string.Format(ItemByIdUrl, itemId), region,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    itemData == ItemData.basic ?
                        string.Empty :
                        string.Format("itemData={0}", itemData.ToString())
                });
            var item = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<ItemStatic>(json));
            cache.Add(ItemByIdCacheKey + itemId, new ItemStaticWrapper(item, language, itemData), DefaultSlidingExpiry);
            return item;
        }
        #endregion

        #region Language Strings       
        public LanguageStringsStatic GetLanguageStrings(Region region, Language language = Language.en_US,
            string version = "")
        {
            var wrapper = cache.Get<string, LanguageStringsStaticWrapper>(LanguageStringsCacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.Version == version)
            {
                return wrapper.LanguageStringsStatic;
            }

            var json = requester.CreateGetRequest(StaticDataRootUrl + LanguageStringsUrl, region,
                new List<string> {
                    string.Format("locale={0}", language.ToString()),
                    string.Format("version={0}", version)
                });
            var languageStrings = JsonConvert.DeserializeObject<LanguageStringsStatic>(json);

            cache.Add(LanguageStringsCacheKey, new LanguageStringsStaticWrapper(languageStrings,
                language, version), DefaultSlidingExpiry);

            return languageStrings;
        }
    
        public async Task<LanguageStringsStatic> GetLanguageStringsAsync(Region region,
            Language language = Language.en_US, string version = "")
        {
            var wrapper = cache.Get<string, LanguageStringsStaticWrapper>(LanguageStringsCacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.Version == version)
            {
                return wrapper.LanguageStringsStatic;
            }

            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + LanguageStringsUrl, region,
                new List<string> {
                    string.Format("locale={0}", language.ToString()),
                    string.Format("version={0}", version)
                });
            var languageStrings = await Task.Factory.StartNew(() 
                => JsonConvert.DeserializeObject<LanguageStringsStatic>(json));

            cache.Add(LanguageStringsCacheKey, new LanguageStringsStaticWrapper(languageStrings,
                language, version), DefaultSlidingExpiry);

            return languageStrings;
        }
        #endregion

        #region Languages
        public List<Language> GetLanguages(Region region)
        {
            var wrapper = cache.Get<string, List<Language>>(LanguagesCacheKey);
            if (wrapper != null)
            {
                return wrapper;
            }

            var json = requester.CreateGetRequest(StaticDataRootUrl + LanguagesUrl, region);
            var languages = JsonConvert.DeserializeObject<List<Language>>(json);

            cache.Add(LanguagesCacheKey, languages, DefaultSlidingExpiry);

            return languages;
        }
    
        public async Task<List<Language>> GetLanguagesAsync(Region region)
        {
            var wrapper = cache.Get<string, List<Language>>(LanguagesCacheKey);
            if (wrapper != null)
            {
                return wrapper;
            }

            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + LanguagesUrl, region);
            var languages = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<List<Language>>(json));

            cache.Add(LanguagesCacheKey, languages, DefaultSlidingExpiry);

            return languages;
        }
        #endregion

        public List<MapStatic> GetMaps(Region region, Language language = Language.en_US, string version = "")
        {
            var wrapper = cache.Get<string, MapsStaticWrapper>(MapCacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.Version == version)
            {
                return wrapper.MapsStatic.Data.Values.ToList();
            }

            var json = requester.CreateGetRequest(string.Format(MapRootUrl, region.ToString()), RootDomain,
                new List<string> {
                    string.Format("locale={0}", language.ToString()),
                    string.Format("version={0}", version)
                });
            var maps = JsonConvert.DeserializeObject<MapsStatic>(json);

            cache.Add(MapCacheKey, new MapsStaticWrapper(maps, language, version), DefaultSlidingExpiry);

            return maps.Data.Values.ToList();
        }
       
        public async Task<List<MapStatic>> GetMapsAsync(Region region, Language language = Language.en_US,
            string version = "")
        {
            var wrapper = cache.Get<string, MapsStaticWrapper>(MapCacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.Version == version)
            {
                return wrapper.MapsStatic.Data.Values.ToList();
            }

            var json = await requester.CreateGetRequestAsync(string.Format(MapRootUrl, region.ToString()), RootDomain,
                new List<string> {
                    string.Format("locale={0}", language.ToString()),
                    string.Format("version={0}", version)
                });
            var maps = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<MapsStatic>(json));

            cache.Add(MapCacheKey, new MapsStaticWrapper(maps, language, version), DefaultSlidingExpiry);

            return maps.Data.Values.ToList();
        }
   
        public MasteryListStatic GetMasteries(Region region, MasteryData masteryData = MasteryData.basic,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, MasteryListStaticWrapper>(MasteriesCacheKey);
            if (wrapper == null || language != wrapper.Language || masteryData != wrapper.MasteryData)
            {
                var json = requester.CreateGetRequest(
                    string.Format(MasteryRootUrl, region.ToString()),
                    RootDomain,
                    new List<string>
                    {
                        string.Format("locale={0}", language.ToString()),
                        masteryData == MasteryData.basic ?
                        string.Empty :
                        string.Format("masteryListData={0}", masteryData.ToString())
                    });
                var masteries = JsonConvert.DeserializeObject<MasteryListStatic>(json);
                wrapper = new MasteryListStaticWrapper(masteries, language, masteryData);
                cache.Add(MasteriesCacheKey, wrapper, DefaultSlidingExpiry);
            }
            return wrapper.MasteryListStatic;
        }
      
        public async Task<MasteryListStatic> GetMasteriesAsync(Region region,
            MasteryData masteryData = MasteryData.basic, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, MasteryListStaticWrapper>(MasteriesCacheKey);
            if (wrapper != null && language == wrapper.Language && masteryData == wrapper.MasteryData)
            {
                return wrapper.MasteryListStatic;
            }
            var json = await requester.CreateGetRequestAsync(
                string.Format(MasteryRootUrl, region.ToString()),
                RootDomain,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    masteryData == MasteryData.basic ?
                        string.Empty :
                        string.Format("masteryListData={0}", masteryData.ToString())
                });
            var masteries = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<MasteryListStatic>(json));
            wrapper = new MasteryListStaticWrapper(masteries, language, masteryData);
            cache.Add(MasteriesCacheKey, wrapper, DefaultSlidingExpiry);
            return wrapper.MasteryListStatic;
        }
      
        public MasteryStatic GetMastery(Region region, int masteryId, MasteryData masteryData = MasteryData.basic,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, MasteryStaticWrapper>(MasteryCacheKey + masteryId);
            if (wrapper != null && wrapper.Language == language && wrapper.MasteryData == masteryData)
            {
                return wrapper.MasteryStatic;
            }
            else
            {
                var listWrapper = cache.Get<string, MasteryListStaticWrapper>(MasteriesCacheKey);
                if (listWrapper != null && listWrapper.Language == language && listWrapper.MasteryData == masteryData)
                {
                    if (listWrapper.MasteryListStatic.Masteries.ContainsKey(masteryId))
                    {
                        return listWrapper.MasteryListStatic.Masteries[masteryId];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var json = requester.CreateGetRequest(
                        string.Format(MasteryRootUrl, region.ToString()) + string.Format(IdUrl, masteryId),
                        RootDomain,
                        new List<string>
                        {
                            string.Format("locale={0}", language.ToString()),
                            masteryData == MasteryData.basic ?
                            string.Empty :
                            string.Format("masteryData={0}", masteryData.ToString())
                        });
                    var mastery = JsonConvert.DeserializeObject<MasteryStatic>(json);
                    cache.Add(MasteryCacheKey + masteryId, new MasteryStaticWrapper(mastery, language, masteryData),
                        DefaultSlidingExpiry);
                    return mastery;
                }
            }
        }
  
        public async Task<MasteryStatic> GetMasteryAsync(Region region, int masteryId,
            MasteryData masteryData = MasteryData.basic, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, MasteryStaticWrapper>(MasteryCacheKey + masteryId);
            if (wrapper != null && wrapper.Language == language && wrapper.MasteryData == masteryData)
            {
                return wrapper.MasteryStatic;
            }
            var listWrapper = cache.Get<string, MasteryListStaticWrapper>(MasteriesCacheKey);
            if (listWrapper != null && listWrapper.Language == language && listWrapper.MasteryData == masteryData)
            {
                return listWrapper.MasteryListStatic.Masteries.ContainsKey(masteryId) ? listWrapper.MasteryListStatic.Masteries[masteryId] : null;
            }
            var json = await requester.CreateGetRequestAsync(
                string.Format(MasteryRootUrl, region.ToString()) + string.Format(IdUrl, masteryId.ToString()),
                RootDomain,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    masteryData == MasteryData.basic ?
                        string.Empty :
                        string.Format("masteryData={0}", masteryData.ToString())
                });
            var mastery = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<MasteryStatic>(json));
            cache.Add(MasteryCacheKey + masteryId, new MasteryStaticWrapper(mastery, language, masteryData),
                DefaultSlidingExpiry);
            return mastery;
        }
    
        public RealmStatic GetRealm(Region region)
        {
            var wrapper = cache.Get<string, RealmStaticWrapper>(RealmCacheKey);
            if (wrapper != null)
            {
                return wrapper.RealmStatic;
            }

            var json = requester.CreateGetRequest(string.Format(RealmRootUrl, region.ToString()), RootDomain);
            var realm = JsonConvert.DeserializeObject<RealmStatic>(json);

            cache.Add(RealmCacheKey, new RealmStaticWrapper(realm), DefaultSlidingExpiry);

            return realm;
        }
    
        public async Task<RealmStatic> GetRealmAsync(Region region)
        {
            var wrapper = cache.Get<string, RealmStaticWrapper>(RealmCacheKey);
            if (wrapper != null)
            {
                return wrapper.RealmStatic;
            }

            var json = await requester.CreateGetRequestAsync(string.Format(RealmRootUrl, region.ToString()), RootDomain);
            var realm = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<RealmStatic>(json));

            cache.Add(RealmCacheKey, new RealmStaticWrapper(realm), DefaultSlidingExpiry);

            return realm;
        }
    
        public RuneListStatic GetRunes(Region region, RuneData runeData = RuneData.basic
            , Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, RuneListStaticWrapper>(RunesCacheKey);
            if (wrapper == null || language != wrapper.Language || runeData != wrapper.RuneData)
            {
                var json = requester.CreateGetRequest(
                    string.Format(RuneRootUrl, region.ToString()),
                    RootDomain,
                    new List<string>
                    {
                        string.Format("locale={0}", language.ToString()),
                        runeData == RuneData.basic ?
                        string.Empty :
                        string.Format("runeListData={0}", runeData.ToString())
                    });
                var runes = JsonConvert.DeserializeObject<RuneListStatic>(json);
                wrapper = new RuneListStaticWrapper(runes, language, runeData);
                cache.Add(RunesCacheKey, wrapper, DefaultSlidingExpiry);
            }
            return wrapper.RuneListStatic;
        }
     
        public async Task<RuneListStatic> GetRunesAsync(Region region, RuneData runeData = RuneData.basic,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, RuneListStaticWrapper>(RunesCacheKey);
            if (wrapper != null && !(language != wrapper.Language | runeData != wrapper.RuneData))
            {
                return wrapper.RuneListStatic;
            }
            var json = await requester.CreateGetRequestAsync(
                string.Format(RuneRootUrl, region.ToString()),
                RootDomain,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    runeData == RuneData.basic ?
                        string.Empty :
                        string.Format("runeListData={0}", runeData.ToString())
                });
            var runes = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<RuneListStatic>(json));
            wrapper = new RuneListStaticWrapper(runes, language, runeData);
            cache.Add(RunesCacheKey, wrapper, DefaultSlidingExpiry);
            return wrapper.RuneListStatic;
        }
     
        public RuneStatic GetRune(Region region, int runeId, RuneData runeData = RuneData.basic,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, RuneStaticWrapper>(RuneCacheKey + runeId);
            if (wrapper != null && wrapper.Language == language && wrapper.RuneData == RuneData.all)
            {
                return wrapper.RuneStatic;
            }
            else
            {
                var listWrapper = cache.Get<string, RuneListStaticWrapper>(RunesCacheKey);
                if (listWrapper != null && listWrapper.Language == language && listWrapper.RuneData == runeData)
                {
                    if (listWrapper.RuneListStatic.Runes.ContainsKey(runeId))
                    {
                        return listWrapper.RuneListStatic.Runes[runeId];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var json = requester.CreateGetRequest(
                        string.Format(RuneRootUrl, region.ToString()) + string.Format(IdUrl, runeId),
                        RootDomain,
                        new List<string>
                        {
                            string.Format("locale={0}", language.ToString()),
                            runeData == RuneData.basic ?
                            string.Empty :
                            string.Format("runeData={0}", runeData.ToString())
                        });
                    var rune = JsonConvert.DeserializeObject<RuneStatic>(json);
                    cache.Add(RuneCacheKey + runeId, new RuneStaticWrapper(rune, language, runeData),
                        DefaultSlidingExpiry);
                    return rune;
                }
            }
        }

        public async Task<RuneStatic> GetRuneAsync(Region region, int runeId, RuneData runeData = RuneData.basic,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, RuneStaticWrapper>(RuneCacheKey + runeId);
            if (wrapper != null && wrapper.Language == language && wrapper.RuneData == RuneData.all)
            {
                return wrapper.RuneStatic;
            }
            var listWrapper = cache.Get<string, RuneListStaticWrapper>(RunesCacheKey);
            if (listWrapper != null && listWrapper.Language == language && listWrapper.RuneData == runeData)
            {
                return listWrapper.RuneListStatic.Runes.ContainsKey(runeId) ?
                    listWrapper.RuneListStatic.Runes[runeId] : null;
            }
            var json = await requester.CreateGetRequestAsync(
                string.Format(RuneRootUrl, region.ToString()) + string.Format(IdUrl, runeId),
                RootDomain,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    runeData == RuneData.basic ?
                        string.Empty :
                        string.Format("runeData={0}", runeData.ToString())
                });
            var rune = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<RuneStatic>(json));
            cache.Add(RuneCacheKey + runeId, new RuneStaticWrapper(rune, language, runeData), DefaultSlidingExpiry);
            return rune;
        }
     
        public SummonerSpellListStatic GetSummonerSpells(Region region,
            SummonerSpellData summonerSpellData = SummonerSpellData.basic, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
            if (wrapper == null || wrapper.Language != language || wrapper.SummonerSpellData != summonerSpellData)
            {
                var json = requester.CreateGetRequest(
                    string.Format(SummonerSpellRootUrl, region.ToString()),
                    RootDomain,
                    new List<string>
                    {
                        string.Format("locale={0}", language.ToString()),
                        summonerSpellData == SummonerSpellData.basic ?
                        string.Empty :
                        string.Format("spellData={0}", summonerSpellData.ToString())
                    });
                var spells = JsonConvert.DeserializeObject<SummonerSpellListStatic>(json);
                wrapper = new SummonerSpellListStaticWrapper(spells, language, summonerSpellData);
                cache.Add(SummonerSpellsCacheKey, wrapper, DefaultSlidingExpiry);
            }
            return wrapper.SummonerSpellListStatic;
        }
 
        public async Task<SummonerSpellListStatic> GetSummonerSpellsAsync(Region region,
            SummonerSpellData summonerSpellData = SummonerSpellData.basic, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.SummonerSpellData == summonerSpellData)
            {
                return wrapper.SummonerSpellListStatic;
            }
            var json = await requester.CreateGetRequestAsync(
                string.Format(SummonerSpellRootUrl, region.ToString()),
                RootDomain,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    summonerSpellData == SummonerSpellData.basic ?
                        string.Empty :
                        string.Format("spellData={0}", summonerSpellData.ToString())
                });
            var spells = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<SummonerSpellListStatic>(json));
            wrapper = new SummonerSpellListStaticWrapper(spells, language, summonerSpellData);
            cache.Add(SummonerSpellsCacheKey, wrapper, DefaultSlidingExpiry);
            return wrapper.SummonerSpellListStatic;
        }
    
        public SummonerSpellStatic GetSummonerSpell(Region region, SummonerSpell summonerSpell,
            SummonerSpellData summonerSpellData = SummonerSpellData.basic, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, SummonerSpellStaticWrapper>(
                SummonerSpellCacheKey + summonerSpell.ToCustomString());
            if (wrapper != null && wrapper.SummonerSpellData == summonerSpellData && wrapper.Language == language)
            {
                return wrapper.SummonerSpellStatic;
            }
            else
            {
                var listWrapper = cache.Get<string, SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
                if (listWrapper != null && listWrapper.SummonerSpellData == summonerSpellData
                    && listWrapper.Language == language)
                {
                    if (listWrapper.SummonerSpellListStatic.SummonerSpells.ContainsKey(summonerSpell.ToCustomString()))
                    {
                        return listWrapper.SummonerSpellListStatic.SummonerSpells[summonerSpell.ToCustomString()];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var json = requester.CreateGetRequest(
                        string.Format(SummonerSpellRootUrl, region.ToString()) +
                            string.Format(IdUrl, (int)summonerSpell),
                        RootDomain,
                        new List<string>
                        {
                            string.Format("locale={0}", language.ToString()),
                            summonerSpellData == SummonerSpellData.basic ?
                            string.Empty :
                            string.Format("spellData={0}", summonerSpellData.ToString())
                        });
                    var spell = JsonConvert.DeserializeObject<SummonerSpellStatic>(json);
                    cache.Add(SummonerSpellCacheKey + summonerSpell.ToCustomString(),
                        new SummonerSpellStaticWrapper(spell, language, summonerSpellData), DefaultSlidingExpiry);
                    return spell;
                }
            }
        }
      
        public async Task<SummonerSpellStatic> GetSummonerSpellAsync(Region region, SummonerSpell summonerSpell,
            SummonerSpellData summonerSpellData = SummonerSpellData.basic, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, SummonerSpellStaticWrapper>(
                SummonerSpellCacheKey + summonerSpell.ToCustomString());
            if (wrapper != null && wrapper.SummonerSpellData == summonerSpellData && wrapper.Language == language)
            {
                return wrapper.SummonerSpellStatic;
            }
            var listWrapper = cache.Get<string, SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
            if (listWrapper != null && listWrapper.SummonerSpellData == summonerSpellData
                && listWrapper.Language == language)
            {
                return listWrapper.SummonerSpellListStatic.SummonerSpells.ContainsKey(summonerSpell.ToCustomString()) ?
                    listWrapper.SummonerSpellListStatic.SummonerSpells[summonerSpell.ToCustomString()] : null;
            }
            var json = await requester.CreateGetRequestAsync(
                string.Format(SummonerSpellRootUrl, region.ToString()) +
                string.Format(IdUrl, (int)summonerSpell),
                RootDomain,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    summonerSpellData == SummonerSpellData.basic ?
                        string.Empty :
                        string.Format("spellData={0}", summonerSpellData.ToString())
                });
            var spell = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<SummonerSpellStatic>(json));
            cache.Add(SummonerSpellCacheKey + summonerSpell.ToCustomString(),
                new SummonerSpellStaticWrapper(spell, language, summonerSpellData), DefaultSlidingExpiry);
            return spell;
        }
      
        public List<string> GetVersions(Region region)
        {
            var wrapper = cache.Get<string, List<string>>(VersionCacheKey);
            if (wrapper != null)
            {
                return wrapper;
            }

            var json = requester.CreateGetRequest(string.Format(VersionRootUrl, region.ToString()), RootDomain);
            var version = JsonConvert.DeserializeObject<List<string>>(json);

            cache.Add(VersionCacheKey, version, DefaultSlidingExpiry);

            return version;
        }
      
        public async Task<List<string>> GetVersionsAsync(Region region)
        {
            var wrapper = cache.Get<string, List<string>>(VersionCacheKey);
            if (wrapper != null)
            {
                return wrapper;
            }

            var json =
                await requester.CreateGetRequestAsync(string.Format(VersionRootUrl, region.ToString()), RootDomain);
            var version = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<string>>(json));

            cache.Add(VersionCacheKey, version, DefaultSlidingExpiry);

            return version;
        }
    }
}
