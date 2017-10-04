using Newtonsoft.Json;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using RiotSharp.Interfaces;
using RiotSharp.StaticDataEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using RiotSharp.StaticDataEndpoint.ProfileIcons.Cache;
using RiotSharp.StaticDataEndpoint.ProfileIcons;

namespace RiotSharp
{
    /// <summary>
    /// Implementation of IStaticRiotApi
    /// </summary>
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

        private const string MapsUrl = "maps";
        private const string MapsCacheKey = "maps";

        private const string MasteriesUrl = "masteries";
        private const string MasteryByIdUrl = "masteries/{0}";
        private const string MasteriesCacheKey = "masteries";
        private const string MasteryByIdCacheKey = "mastery";

        private const string ProfileIconsUrl = "profile-icons";
        private const string ProfileIconsCacheKey = "profile-icons";

        private const string RealmsUrl = "realms";
        private const string RealmsCacheKey = "realms";

        private const string RunesUrl = "runes";
        private const string RuneByIdUrl = "runes/{0}";
        private const string RunesCacheKey = "runes";
        private const string RuneByIdCacheKey = "rune";

        private const string SummonerSpellsUrl = "summoner-spells";
        private const string SummonerSpellsCacheKey = "summoner-spells";
        private const string SummonerSpellByIdUrl = "summoner-spells/{0}";
        private const string SummonerSpellByIdCacheKey = "summoner-spell";

        private const string VersionsUrl = "versions";
        private const string VersionsCacheKey = "versions";

        private const string IdUrl = "/{0}";
        private const string TagsParameter = "tags={0}";

        private readonly IRequester requester;

        private ICache cache;
        public readonly TimeSpan DefaultSlidingExpirationTime = new TimeSpan(1, 0, 0);
        internal TimeSpan SlidingExpirationTime;

        private static StaticRiotApi instance;
        private static string instanceApiKey;
        #endregion

        /// <summary>
        /// Get the instance of StaticRiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="useCache"></param>
        /// <param name="slidingExpirationTime"></param>
        /// <returns>The instance of StaticRiotApi.</returns>
        public static StaticRiotApi GetInstance(string apiKey, bool useCache = true, 
            TimeSpan? slidingExpirationTime = null)
        {
            if (instance == null  || instanceApiKey != apiKey)
            {
                instanceApiKey = apiKey;
                instance = new StaticRiotApi(apiKey, useCache, slidingExpirationTime);
            }
            return instance;
        }

        private StaticRiotApi(string apiKey, bool useCache = true, TimeSpan? slidingExpirationTime = null)
        {
            var rateLimits = new Dictionary<TimeSpan, int>{ {new TimeSpan(1, 0, 0), 10} };

            var serializer = new RequestContentSerializer();
            var deserializer = new ResponseDeserializer();
            var requestCreator = new RequestCreator(apiKey, serializer);
            var httpClient = new HttpClient();
            var failedRequestHandler = new FailedRequestHandler();
            var client = new RequestClient(httpClient, failedRequestHandler);
            var basicRequester = new Requester(client, requestCreator, deserializer);
            var rateLimitProvider = new RateLimitProvider(rateLimits);

            requester = new RateLimitedRequester(basicRequester, rateLimitProvider);
            Requesters.StaticApiRequester = (RateLimitedRequester)requester;

            cache = useCache ? (ICache) new Cache() : new PassThroughCache();
            SlidingExpirationTime = slidingExpirationTime ?? DefaultSlidingExpirationTime;
        }

        /// <summary>
        /// Default dependency injection constructor
        /// </summary>
        /// <param name="requester"></param>
        /// <param name="cache"></param>
        /// <param name="slidingExpirationTime"></param>
        public StaticRiotApi(IRequester requester, ICache cache, TimeSpan? slidingExpirationTime = null)
        {
            this.requester = requester ?? throw new ArgumentNullException(nameof(requester));
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));
            SlidingExpirationTime = slidingExpirationTime ?? DefaultSlidingExpirationTime;
        }

        #pragma warning disable CS1691
        #region Champions
        public ChampionListStatic GetChampions(Region region, ChampionData championData = ChampionData.All,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ChampionListStaticWrapper>(ChampionsCacheKey);
            if (wrapper == null || language != wrapper.Language || championData != wrapper.ChampionData)
            {
                var url = StaticDataRootUrl + ChampionsUrl;
                var champs = requester.Get<ChampionListStatic>(url, region,
                    new List<string> {
                        string.Format("locale={0}", language.ToString()),
                        championData == ChampionData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, championData.ToString().ToLower())
                    });
                wrapper = new ChampionListStaticWrapper(champs, language, championData);
                cache.Add(ChampionsCacheKey, wrapper, SlidingExpirationTime);
            }
            return wrapper.ChampionListStatic;
        }
    
        public async Task<ChampionListStatic> GetChampionsAsync(Region region,
            ChampionData championData = ChampionData.All, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ChampionListStaticWrapper>(ChampionsCacheKey);
            if (wrapper != null && language == wrapper.Language && championData == wrapper.ChampionData)
            {
                return wrapper.ChampionListStatic;
            }
            var champs = await requester.GetAsync<ChampionListStatic>(StaticDataRootUrl + ChampionsUrl, region,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    championData == ChampionData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, championData.ToString().ToLower())
                });
            wrapper = new ChampionListStaticWrapper(champs, language, championData);
            cache.Add(ChampionsCacheKey, wrapper, SlidingExpirationTime);
            return wrapper.ChampionListStatic;
        }
     
        public ChampionStatic GetChampion(Region region, int championId,
            ChampionData championData = ChampionData.All, Language language = Language.en_US)
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
                    var champ = requester.Get<ChampionStatic>(
                        StaticDataRootUrl + string.Format(ChampionByIdUrl, championId), region,
                        new List<string>
                        {
                            string.Format("locale={0}", language.ToString()),
                            championData == ChampionData.Basic ?
                            string.Empty :
                            string.Format(TagsParameter, championData.ToString().ToLower())
                        });
                    cache.Add(ChampionByIdCacheKey + championId, new ChampionStaticWrapper(champ, language, championData),
                        SlidingExpirationTime);
                    return champ;
                }
            }
        }
     
        public async Task<ChampionStatic> GetChampionAsync(Region region, int championId,
            ChampionData championData = ChampionData.All, Language language = Language.en_US)
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
            var champ = await requester.GetAsync<ChampionStatic>(
                StaticDataRootUrl + string.Format(ChampionByIdUrl, championId), region,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    championData == ChampionData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, championData.ToString().ToLower())
                });
            cache.Add(ChampionByIdCacheKey + championId, new ChampionStaticWrapper(champ, language, championData),
                SlidingExpirationTime);
            return champ;
        }
        #endregion

        #region Items
        public ItemListStatic GetItems(Region region, ItemData itemData = ItemData.All,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ItemListStaticWrapper>(ItemsCacheKey);
            if (wrapper == null || language != wrapper.Language || itemData != wrapper.ItemData)
            {
                var items = requester.Get<ItemListStatic>(StaticDataRootUrl + ItemsUrl, region,
                    new List<string>
                    {
                        string.Format("locale={0}", language.ToString()),
                        itemData == ItemData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, itemData.ToString().ToLower())
                    });
                wrapper = new ItemListStaticWrapper(items, language, itemData);
                cache.Add(ItemsCacheKey, wrapper, SlidingExpirationTime);
            }
            return wrapper.ItemListStatic;
        }
  
        public async Task<ItemListStatic> GetItemsAsync(Region region, ItemData itemData = ItemData.All,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ItemListStaticWrapper>(ItemsCacheKey);
            if (wrapper != null && language == wrapper.Language && itemData == wrapper.ItemData)
            {
                return wrapper.ItemListStatic;
            }
            var items = await requester.GetAsync<ItemListStatic>(StaticDataRootUrl + ItemsUrl, region,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    itemData == ItemData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, itemData.ToString().ToLower())
                });
            wrapper = new ItemListStaticWrapper(items, language, itemData);
            cache.Add(ItemsCacheKey, wrapper, SlidingExpirationTime);
            return wrapper.ItemListStatic;
        }
    
        public ItemStatic GetItem(Region region, int itemId, ItemData itemData = ItemData.All,
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
                    var item = requester.Get<ItemStatic>(
                        StaticDataRootUrl + string.Format(ItemByIdUrl, itemId), region,
                        new List<string>
                        {
                            string.Format("locale={0}", language.ToString()),
                            itemData == ItemData.Basic ?
                            string.Empty :
                            string.Format(TagsParameter, itemData.ToString().ToLower())
                        });
                    cache.Add(ItemByIdCacheKey + itemId, new ItemStaticWrapper(item, language, itemData),
                        SlidingExpirationTime);
                    return item;
                }
            }
        }
  
        public async Task<ItemStatic> GetItemAsync(Region region, int itemId, ItemData itemData = ItemData.All,
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
            var item = await requester.GetAsync<ItemStatic>(
                StaticDataRootUrl + string.Format(ItemByIdUrl, itemId), region,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    itemData == ItemData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, itemData.ToString().ToLower())
                });
            cache.Add(ItemByIdCacheKey + itemId, new ItemStaticWrapper(item, language, itemData), SlidingExpirationTime);
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

            var languageStrings = requester.Get<LanguageStringsStatic>(StaticDataRootUrl + LanguageStringsUrl, region,
                new List<string> {
                    string.Format("locale={0}", language.ToString()),
                    string.Format("version={0}", version)
                });

            cache.Add(LanguageStringsCacheKey, new LanguageStringsStaticWrapper(languageStrings,
                language, version), SlidingExpirationTime);

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

            var languageStrings = await requester.GetAsync<LanguageStringsStatic>(StaticDataRootUrl + LanguageStringsUrl, region,
                new List<string> {
                    string.Format("locale={0}", language.ToString()),
                    string.Format("version={0}", version)
                });

            cache.Add(LanguageStringsCacheKey, new LanguageStringsStaticWrapper(languageStrings,
                language, version), SlidingExpirationTime);

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

            var languages = requester.Get<List<Language>>(StaticDataRootUrl + LanguagesUrl, region);

            cache.Add(LanguagesCacheKey, languages, SlidingExpirationTime);

            return languages;
        }
    
        public async Task<List<Language>> GetLanguagesAsync(Region region)
        {
            var wrapper = cache.Get<string, List<Language>>(LanguagesCacheKey);
            if (wrapper != null)
            {
                return wrapper;
            }

            var languages = await requester.GetAsync<List<Language>>(StaticDataRootUrl + LanguagesUrl, region);

            cache.Add(LanguagesCacheKey, languages, SlidingExpirationTime);

            return languages;
        }
        #endregion

        #region Maps
        public List<MapStatic> GetMaps(Region region, Language language = Language.en_US, string version = "")
        {
            var wrapper = cache.Get<string, MapsStaticWrapper>(MapsCacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.Version == version)
            {
                return wrapper.MapsStatic.Data.Values.ToList();
            }

            var maps = requester.Get<MapsStatic>(StaticDataRootUrl + MapsUrl, region,
                new List<string> {
                    string.Format("locale={0}", language.ToString()),
                    string.Format("version={0}", version)
                });

            cache.Add(MapsCacheKey, new MapsStaticWrapper(maps, language, version), SlidingExpirationTime);

            return maps.Data.Values.ToList();
        }
       
        public async Task<List<MapStatic>> GetMapsAsync(Region region, Language language = Language.en_US,
            string version = "")
        {
            var wrapper = cache.Get<string, MapsStaticWrapper>(MapsCacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.Version == version)
            {
                return wrapper.MapsStatic.Data.Values.ToList();
            }

            var maps = await requester.GetAsync<MapsStatic>(StaticDataRootUrl + MapsUrl, region,
                new List<string> {
                    string.Format("locale={0}", language.ToString()),
                    string.Format("version={0}", version)
                });

            cache.Add(MapsCacheKey, new MapsStaticWrapper(maps, language, version), SlidingExpirationTime);

            return maps.Data.Values.ToList();
        }
        #endregion

        #region Masteries
        public MasteryListStatic GetMasteries(Region region, MasteryData masteryData = MasteryData.All,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, MasteryListStaticWrapper>(MasteriesCacheKey);
            if (wrapper == null || language != wrapper.Language || masteryData != wrapper.MasteryData)
            {
                var masteries = requester.Get<MasteryListStatic>(StaticDataRootUrl + MasteriesUrl, region,
                    new List<string>
                    {
                        string.Format("locale={0}", language.ToString()),
                        masteryData == MasteryData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, masteryData.ToString().ToLower())
                    });
                wrapper = new MasteryListStaticWrapper(masteries, language, masteryData);
                cache.Add(MasteriesCacheKey, wrapper, SlidingExpirationTime);
            }
            return wrapper.MasteryListStatic;
        }
      
        public async Task<MasteryListStatic> GetMasteriesAsync(Region region,
            MasteryData masteryData = MasteryData.All, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, MasteryListStaticWrapper>(MasteriesCacheKey);
            if (wrapper != null && language == wrapper.Language && masteryData == wrapper.MasteryData)
            {
                return wrapper.MasteryListStatic;
            }
            var masteries = await requester.GetAsync<MasteryListStatic>(StaticDataRootUrl + MasteriesUrl, region,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    masteryData == MasteryData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, masteryData.ToString().ToLower())
                });
            wrapper = new MasteryListStaticWrapper(masteries, language, masteryData);
            cache.Add(MasteriesCacheKey, wrapper, SlidingExpirationTime);
            return wrapper.MasteryListStatic;
        }
      
        public MasteryStatic GetMastery(Region region, int masteryId, MasteryData masteryData = MasteryData.All,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, MasteryStaticWrapper>(MasteryByIdCacheKey + masteryId);
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
                    var mastery = requester.Get<MasteryStatic>(
                        StaticDataRootUrl + string.Format(MasteryByIdUrl, masteryId), region,
                        new List<string>
                        {
                            string.Format("locale={0}", language.ToString()),
                            masteryData == MasteryData.Basic ?
                            string.Empty : string.Format(TagsParameter, masteryData.ToString().ToLower())
                        });
                    cache.Add(MasteryByIdCacheKey + masteryId, new MasteryStaticWrapper(mastery, language, masteryData),
                        SlidingExpirationTime);
                    return mastery;
                }
            }
        }
  
        public async Task<MasteryStatic> GetMasteryAsync(Region region, int masteryId,
            MasteryData masteryData = MasteryData.All, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, MasteryStaticWrapper>(MasteryByIdCacheKey + masteryId);
            if (wrapper != null && wrapper.Language == language && wrapper.MasteryData == masteryData)
            {
                return wrapper.MasteryStatic;
            }
            var listWrapper = cache.Get<string, MasteryListStaticWrapper>(MasteriesCacheKey);
            if (listWrapper != null && listWrapper.Language == language && listWrapper.MasteryData == masteryData)
            {
                return listWrapper.MasteryListStatic.Masteries.ContainsKey(masteryId)
                    ? listWrapper.MasteryListStatic.Masteries[masteryId] : null;
            }
            var mastery = await requester.GetAsync<MasteryStatic>(
                StaticDataRootUrl + string.Format(MasteryByIdUrl, masteryId), region,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    masteryData == MasteryData.Basic ?
                        string.Empty : string.Format(TagsParameter, masteryData.ToString().ToLower())
                });
            cache.Add(MasteryByIdCacheKey + masteryId, new MasteryStaticWrapper(mastery, language, masteryData),
                SlidingExpirationTime);
            return mastery;
        }
        #endregion

        #region Profile Icons
        public ProfileIconListStatic GetProfileIcons(Region region, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ProfileIconsStaticWrapper>(ProfileIconsCacheKey);
            if (wrapper == null || language != wrapper.Language)
            {
                var profileIcons = requester.Get<ProfileIconListStatic>(StaticDataRootUrl + ProfileIconsUrl, region,
                    new List<string> {
                        string.Format("locale={0}", language.ToString())
                    });
                wrapper = new ProfileIconsStaticWrapper(profileIcons, language);
                cache.Add(ProfileIconsCacheKey, wrapper, SlidingExpirationTime);
            }
            return wrapper.ProfileIconListStatic;
        }

        public async Task<ProfileIconListStatic> GetProfileIconsAsync(Region region, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ProfileIconsStaticWrapper>(ProfileIconsCacheKey);
            if (wrapper != null && language == wrapper.Language)
            {
                return wrapper.ProfileIconListStatic;
            }
            var profileIcons = await requester.GetAsync<ProfileIconListStatic>(StaticDataRootUrl + ProfileIconsUrl, region,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString())
                });
            wrapper = new ProfileIconsStaticWrapper(profileIcons, language);
            cache.Add(ProfileIconsCacheKey, wrapper, SlidingExpirationTime);
            return wrapper.ProfileIconListStatic;
        }
        #endregion

        #region Realms
        public RealmStatic GetRealm(Region region)
        {
            var wrapper = cache.Get<string, RealmStaticWrapper>(RealmsCacheKey);
            if (wrapper != null)
            {
                return wrapper.RealmStatic;
            }

            var realm = requester.Get<RealmStatic>(StaticDataRootUrl + RealmsUrl, region);

            cache.Add(RealmsCacheKey, new RealmStaticWrapper(realm), SlidingExpirationTime);

            return realm;
        }
    
        public async Task<RealmStatic> GetRealmAsync(Region region)
        {
            var wrapper = cache.Get<string, RealmStaticWrapper>(RealmsCacheKey);
            if (wrapper != null)
            {
                return wrapper.RealmStatic;
            }

            var realm = await requester.GetAsync<RealmStatic>(StaticDataRootUrl + RealmsUrl, region);

            cache.Add(RealmsCacheKey, new RealmStaticWrapper(realm), SlidingExpirationTime);

            return realm;
        }
        #endregion

        #region Runes
        public RuneListStatic GetRunes(Region region, RuneData runeData = RuneData.All
            , Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, RuneListStaticWrapper>(RunesCacheKey);
            if (wrapper == null || language != wrapper.Language || runeData != wrapper.RuneData)
            {
                var runes = requester.Get<RuneListStatic>(StaticDataRootUrl + RunesUrl, region,
                    new List<string>
                    {
                        string.Format("locale={0}", language.ToString()),
                        runeData == RuneData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, runeData.ToString().ToLower())
                    });
                wrapper = new RuneListStaticWrapper(runes, language, runeData);
                cache.Add(RunesCacheKey, wrapper, SlidingExpirationTime);
            }
            return wrapper.RuneListStatic;
        }
     
        public async Task<RuneListStatic> GetRunesAsync(Region region, RuneData runeData = RuneData.All,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, RuneListStaticWrapper>(RunesCacheKey);
            if (wrapper != null && !(language != wrapper.Language | runeData != wrapper.RuneData))
            {
                return wrapper.RuneListStatic;
            }
            var runes = await requester.GetAsync<RuneListStatic>(StaticDataRootUrl + RunesUrl, region,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    runeData == RuneData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, runeData.ToString().ToLower())
                });
            wrapper = new RuneListStaticWrapper(runes, language, runeData);
            cache.Add(RunesCacheKey, wrapper, SlidingExpirationTime);
            return wrapper.RuneListStatic;
        }
     
        public RuneStatic GetRune(Region region, int runeId, RuneData runeData = RuneData.All,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, RuneStaticWrapper>(RuneByIdCacheKey + runeId);
            if (wrapper != null && wrapper.Language == language && wrapper.RuneData == RuneData.All)
            {
                return wrapper.RuneStatic;
            }
            else
            {
                var listWrapper = cache.Get<string, RuneListStaticWrapper>(RunesCacheKey);
                if (listWrapper != null && listWrapper.Language == language && listWrapper.RuneData == runeData)
                {
                    return listWrapper.RuneListStatic.Runes.ContainsKey(runeId) ? listWrapper.RuneListStatic.Runes[runeId] : null;
                }
                else
                {
                    var rune = requester.Get<RuneStatic>(
                        StaticDataRootUrl + string.Format(RuneByIdUrl, runeId), region,
                        new List<string>
                        {
                            string.Format("locale={0}", language.ToString()),
                            runeData == RuneData.Basic ?
                            string.Empty :
                            string.Format(TagsParameter, runeData.ToString().ToLower())
                        });
                    cache.Add(RuneByIdCacheKey + runeId, new RuneStaticWrapper(rune, language, runeData),
                        SlidingExpirationTime);
                    return rune;
                }
            }
        }

        public async Task<RuneStatic> GetRuneAsync(Region region, int runeId, RuneData runeData = RuneData.All,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, RuneStaticWrapper>(RuneByIdCacheKey + runeId);
            if (wrapper != null && wrapper.Language == language && wrapper.RuneData == RuneData.All)
            {
                return wrapper.RuneStatic;
            }
            var listWrapper = cache.Get<string, RuneListStaticWrapper>(RunesCacheKey);
            if (listWrapper != null && listWrapper.Language == language && listWrapper.RuneData == runeData)
            {
                return listWrapper.RuneListStatic.Runes.ContainsKey(runeId) ?
                    listWrapper.RuneListStatic.Runes[runeId] : null;
            }
            var rune = await requester.GetAsync<RuneStatic>(
                StaticDataRootUrl + string.Format(RuneByIdUrl, runeId), region,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    runeData == RuneData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, runeData.ToString().ToLower())
                });
            cache.Add(RuneByIdCacheKey + runeId, new RuneStaticWrapper(rune, language, runeData), SlidingExpirationTime);
            return rune;
        }
        #endregion

        #region Summoner Spells
        public SummonerSpellListStatic GetSummonerSpells(Region region,
            SummonerSpellData summonerSpellData = SummonerSpellData.All, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
            if (wrapper == null || wrapper.Language != language || wrapper.SummonerSpellData != summonerSpellData)
            {
                var spells = requester.Get<SummonerSpellListStatic>(StaticDataRootUrl + SummonerSpellsUrl, region,
                    new List<string>
                    {
                        string.Format("locale={0}", language.ToString()),
                        summonerSpellData == SummonerSpellData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, summonerSpellData.ToString().ToLower())
                    });
                wrapper = new SummonerSpellListStaticWrapper(spells, language, summonerSpellData);
                cache.Add(SummonerSpellsCacheKey, wrapper, SlidingExpirationTime);
            }
            return wrapper.SummonerSpellListStatic;
        }
 
        public async Task<SummonerSpellListStatic> GetSummonerSpellsAsync(Region region,
            SummonerSpellData summonerSpellData = SummonerSpellData.All, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.SummonerSpellData == summonerSpellData)
            {
                return wrapper.SummonerSpellListStatic;
            }
            var spells = await requester.GetAsync<SummonerSpellListStatic>(StaticDataRootUrl + SummonerSpellsUrl, region,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    summonerSpellData == SummonerSpellData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, summonerSpellData.ToString().ToLower())
                });
            wrapper = new SummonerSpellListStaticWrapper(spells, language, summonerSpellData);
            cache.Add(SummonerSpellsCacheKey, wrapper, SlidingExpirationTime);
            return wrapper.SummonerSpellListStatic;
        }
    
        public SummonerSpellStatic GetSummonerSpell(Region region, int summonerSpellId,
            SummonerSpellData summonerSpellData = SummonerSpellData.All, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, SummonerSpellStaticWrapper>(
                SummonerSpellByIdCacheKey + summonerSpellId);
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
                    if (listWrapper.SummonerSpellListStatic.SummonerSpells.ContainsKey(summonerSpellId.ToString()))
                    {
                        return listWrapper.SummonerSpellListStatic.SummonerSpells[summonerSpellId.ToString()];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var spell = requester.Get<SummonerSpellStatic>(
                        StaticDataRootUrl + string.Format(SummonerSpellByIdUrl, summonerSpellId), region,
                        new List<string>
                        {
                            string.Format("locale={0}", language.ToString()),
                            summonerSpellData == SummonerSpellData.Basic ?
                            string.Empty :
                            string.Format(TagsParameter, summonerSpellData.ToString().ToLower())
                        });
                    cache.Add(SummonerSpellByIdCacheKey + summonerSpellId,
                        new SummonerSpellStaticWrapper(spell, language, summonerSpellData), SlidingExpirationTime);
                    return spell;
                }
            }
        }
      
        public async Task<SummonerSpellStatic> GetSummonerSpellAsync(Region region, int summonerSpellId,
            SummonerSpellData summonerSpellData = SummonerSpellData.All, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, SummonerSpellStaticWrapper>(
                SummonerSpellByIdCacheKey + summonerSpellId);
            if (wrapper != null && wrapper.SummonerSpellData == summonerSpellData && wrapper.Language == language)
            {
                return wrapper.SummonerSpellStatic;
            }
            var listWrapper = cache.Get<string, SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
            if (listWrapper != null && listWrapper.SummonerSpellData == summonerSpellData
                && listWrapper.Language == language)
            {
                return listWrapper.SummonerSpellListStatic.SummonerSpells.ContainsKey(summonerSpellId.ToString()) ?
                    listWrapper.SummonerSpellListStatic.SummonerSpells[summonerSpellId.ToString()] : null;
            }
            var spell = await requester.GetAsync<SummonerSpellStatic>(
                StaticDataRootUrl + string.Format(SummonerSpellByIdUrl, summonerSpellId), region,
                new List<string>
                {
                    string.Format("locale={0}", language.ToString()),
                    summonerSpellData == SummonerSpellData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, summonerSpellData.ToString().ToLower())
                });
            cache.Add(SummonerSpellByIdCacheKey + summonerSpellId,
                new SummonerSpellStaticWrapper(spell, language, summonerSpellData), SlidingExpirationTime);
            return spell;
        }
        #endregion

        #region Versions
        public List<string> GetVersions(Region region)
        {
            var wrapper = cache.Get<string, List<string>>(VersionsCacheKey);
            if (wrapper != null)
            {
                return wrapper;
            }

            var version = requester.Get<List<string>>(StaticDataRootUrl + VersionsUrl, region);

            cache.Add(VersionsCacheKey, version, SlidingExpirationTime);

            return version;
        }
      
        public async Task<List<string>> GetVersionsAsync(Region region)
        {
            var wrapper = cache.Get<string, List<string>>(VersionsCacheKey);
            if (wrapper != null)
            {
                return wrapper;
            }

            var version = await requester.GetAsync<List<string>>(StaticDataRootUrl + VersionsUrl, region);

            cache.Add(VersionsCacheKey, version, SlidingExpirationTime);

            return version;
        }
        #endregion
        #pragma warning restore CS1591
    }
}
