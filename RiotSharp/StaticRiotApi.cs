using Newtonsoft.Json;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using RiotSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiotSharp.Caching;
using RiotSharp.Endpoints.StaticDataEndpoint;
using RiotSharp.Endpoints.StaticDataEndpoint.Champion;
using RiotSharp.Endpoints.StaticDataEndpoint.Champion.Cache;
using RiotSharp.Endpoints.StaticDataEndpoint.Item;
using RiotSharp.Endpoints.StaticDataEndpoint.Item.Cache;
using RiotSharp.Endpoints.StaticDataEndpoint.LanguageStrings;
using RiotSharp.Endpoints.StaticDataEndpoint.LanguageStrings.Cache;
using RiotSharp.Endpoints.StaticDataEndpoint.Map;
using RiotSharp.Endpoints.StaticDataEndpoint.Map.Cache;
using RiotSharp.Endpoints.StaticDataEndpoint.Mastery;
using RiotSharp.Endpoints.StaticDataEndpoint.Mastery.Cache;
using RiotSharp.Endpoints.StaticDataEndpoint.ProfileIcons;
using RiotSharp.Endpoints.StaticDataEndpoint.ProfileIcons.Cache;
using RiotSharp.Endpoints.StaticDataEndpoint.Realm;
using RiotSharp.Endpoints.StaticDataEndpoint.Realm.Cache;
using RiotSharp.Endpoints.StaticDataEndpoint.Rune;
using RiotSharp.Endpoints.StaticDataEndpoint.Rune.Cache;
using RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell;
using RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell.Cache;
using RiotSharp.Misc;

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

        private IRateLimitedRequester requester;

        private ICache cache;
        public readonly TimeSpan DefaultSlidingExpirationTime = new TimeSpan(1, 0, 0);
        internal TimeSpan SlidingExpirationTime;

        private static StaticRiotApi instance;
        #endregion      
      
        /// <summary>
        /// Get the instance of StaticRiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <returns>The instance of StaticRiotApi.</returns>
        public static StaticRiotApi GetInstance(string apiKey, bool useCache = true, 
            TimeSpan? slidingExpirationTime = null)
        {
            if (instance == null || 
                Requesters.StaticApiRequester == null ||
                apiKey != Requesters.StaticApiRequester.ApiKey)
            {
                instance = new StaticRiotApi(apiKey, useCache, slidingExpirationTime);
            }
            return instance;
        }

        private StaticRiotApi(string apiKey, bool useCache = true, TimeSpan? slidingExpirationTime = null)
        {
            Requesters.StaticApiRequester = new RateLimitedRequester(apiKey, new Dictionary<TimeSpan, int>
            {
                { new TimeSpan(1, 0, 0), 10 }
            });
            requester = Requesters.StaticApiRequester;
            if (useCache)
                cache = new Cache();
            else
                cache = new PassThroughCache();

            if (slidingExpirationTime == null)
                SlidingExpirationTime = DefaultSlidingExpirationTime;
            else
                SlidingExpirationTime = slidingExpirationTime.Value;
        }

        /// <summary>
        /// Default dependency injection constructor
        /// </summary>
        /// <param name="requester"></param>
        /// <param name="cache"></param>
        public StaticRiotApi(IRateLimitedRequester requester, ICache cache, TimeSpan? slidingExpirationTime = null)
        {
            this.requester = requester ?? throw new ArgumentNullException(nameof(requester));
            this.cache = cache ?? throw new ArgumentNullException(nameof(cache));

            if (slidingExpirationTime == null)
                SlidingExpirationTime = DefaultSlidingExpirationTime;
            else
                SlidingExpirationTime = slidingExpirationTime.Value;
        }

        #pragma warning disable CS1691
        #region Champions

        public async Task<ChampionListStatic> GetChampionsAsync(Region region,
            ChampionData championData = ChampionData.All, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ChampionListStaticWrapper>(ChampionsCacheKey);
            if (wrapper != null && language == wrapper.Language && championData == wrapper.ChampionData)
            {
                return wrapper.ChampionListStatic;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + ChampionsUrl, region,
                new List<string>
                {
                    $"locale={language}",
                    championData == ChampionData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, championData.ToString().ToLower())
                }).ConfigureAwait(false);
            var champs = JsonConvert.DeserializeObject<ChampionListStatic>(json);
            wrapper = new ChampionListStaticWrapper(champs, language, championData);
            cache.Add(ChampionsCacheKey, wrapper, SlidingExpirationTime);
            return wrapper.ChampionListStatic;
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
            var json = await requester.CreateGetRequestAsync(
                StaticDataRootUrl + string.Format(ChampionByIdUrl, championId), region,
                new List<string>
                {
                    $"locale={language}",
                    championData == ChampionData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, championData.ToString().ToLower())
                }).ConfigureAwait(false);
            var champ = JsonConvert.DeserializeObject<ChampionStatic>(json);
            cache.Add(ChampionByIdCacheKey + championId, new ChampionStaticWrapper(champ, language, championData),
                SlidingExpirationTime);
            return champ;
        }
        #endregion

        #region Items

        public async Task<ItemListStatic> GetItemsAsync(Region region, ItemData itemData = ItemData.All,
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
                    $"locale={language}",
                    itemData == ItemData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, itemData.ToString().ToLower())
                }).ConfigureAwait(false);
            var items = JsonConvert.DeserializeObject<ItemListStatic>(json);
            wrapper = new ItemListStaticWrapper(items, language, itemData);
            cache.Add(ItemsCacheKey, wrapper, SlidingExpirationTime);
            return wrapper.ItemListStatic;
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
            var json = await requester.CreateGetRequestAsync(
                StaticDataRootUrl + string.Format(ItemByIdUrl, itemId), region,
                new List<string>
                {
                    $"locale={language}",
                    itemData == ItemData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, itemData.ToString().ToLower())
                }).ConfigureAwait(false);
            var item = JsonConvert.DeserializeObject<ItemStatic>(json);
            cache.Add(ItemByIdCacheKey + itemId, new ItemStaticWrapper(item, language, itemData), SlidingExpirationTime);
            return item;
        }
        #endregion

        #region Language Strings       
    
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
                    $"locale={language}",
                    $"version={version}"
                }).ConfigureAwait(false);
            var languageStrings = JsonConvert.DeserializeObject<LanguageStringsStatic>(json);

            cache.Add(LanguageStringsCacheKey, new LanguageStringsStaticWrapper(languageStrings,
                language, version), SlidingExpirationTime);

            return languageStrings;
        }
        #endregion

        #region Languages
    
        public async Task<List<Language>> GetLanguagesAsync(Region region)
        {
            var wrapper = cache.Get<string, List<Language>>(LanguagesCacheKey);
            if (wrapper != null)
            {
                return wrapper;
            }

            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + LanguagesUrl, region).ConfigureAwait(false);
            var languages = JsonConvert.DeserializeObject<List<Language>>(json);

            cache.Add(LanguagesCacheKey, languages, SlidingExpirationTime);

            return languages;
        }
        #endregion

        #region Maps
       
        public async Task<List<MapStatic>> GetMapsAsync(Region region, Language language = Language.en_US,
            string version = "")
        {
            var wrapper = cache.Get<string, MapsStaticWrapper>(MapsCacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.Version == version)
            {
                return wrapper.MapsStatic.Data.Values.ToList();
            }

            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + MapsUrl, region,
                new List<string> {
                    $"locale={language}",
                    $"version={version}"
                }).ConfigureAwait(false);
            var maps = JsonConvert.DeserializeObject<MapsStatic>(json);

            cache.Add(MapsCacheKey, new MapsStaticWrapper(maps, language, version), SlidingExpirationTime);

            return maps.Data.Values.ToList();
        }
        #endregion

        #region Masteries
      
        public async Task<MasteryListStatic> GetMasteriesAsync(Region region,
            MasteryData masteryData = MasteryData.All, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, MasteryListStaticWrapper>(MasteriesCacheKey);
            if (wrapper != null && language == wrapper.Language && masteryData == wrapper.MasteryData)
            {
                return wrapper.MasteryListStatic;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + MasteriesUrl, region,
                new List<string>
                {
                    $"locale={language}",
                    masteryData == MasteryData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, masteryData.ToString().ToLower())
                }).ConfigureAwait(false);
            var masteries = JsonConvert.DeserializeObject<MasteryListStatic>(json);
            wrapper = new MasteryListStaticWrapper(masteries, language, masteryData);
            cache.Add(MasteriesCacheKey, wrapper, SlidingExpirationTime);
            return wrapper.MasteryListStatic;
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
            var json = await requester.CreateGetRequestAsync(
                StaticDataRootUrl + string.Format(MasteryByIdUrl, masteryId), region,
                new List<string>
                {
                    $"locale={language}",
                    masteryData == MasteryData.Basic ?
                        string.Empty : string.Format(TagsParameter, masteryData.ToString().ToLower())
                }).ConfigureAwait(false);
            var mastery = JsonConvert.DeserializeObject<MasteryStatic>(json);
            cache.Add(MasteryByIdCacheKey + masteryId, new MasteryStaticWrapper(mastery, language, masteryData),
                SlidingExpirationTime);
            return mastery;
        }
        #endregion

        #region Profile Icons

        public async Task<ProfileIconListStatic> GetProfileIconsAsync(Region region, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ProfileIconsStaticWrapper>(ProfileIconsCacheKey);
            if (wrapper != null && language == wrapper.Language)
            {
                return wrapper.ProfileIconListStatic;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + ProfileIconsUrl, region,
                new List<string>
                {
                    $"locale={language}",
                }).ConfigureAwait(false);
            var profileIcons = JsonConvert.DeserializeObject<ProfileIconListStatic>(json);
            wrapper = new ProfileIconsStaticWrapper(profileIcons, language);
            cache.Add(ProfileIconsCacheKey, wrapper, SlidingExpirationTime);
            return wrapper.ProfileIconListStatic;
        }
        #endregion

        #region Realms
    
        public async Task<RealmStatic> GetRealmAsync(Region region)
        {
            var wrapper = cache.Get<string, RealmStaticWrapper>(RealmsCacheKey);
            if (wrapper != null)
            {
                return wrapper.RealmStatic;
            }

            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + RealmsUrl, region).ConfigureAwait(false);
            var realm = JsonConvert.DeserializeObject<RealmStatic>(json);

            cache.Add(RealmsCacheKey, new RealmStaticWrapper(realm), SlidingExpirationTime);

            return realm;
        }
        #endregion

        #region Runes
     
        public async Task<RuneListStatic> GetRunesAsync(Region region, RuneData runeData = RuneData.All,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, RuneListStaticWrapper>(RunesCacheKey);
            if (wrapper != null && !(language != wrapper.Language | runeData != wrapper.RuneData))
            {
                return wrapper.RuneListStatic;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + RunesUrl, region,
                new List<string>
                {
                    $"locale={language}",
                    runeData == RuneData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, runeData.ToString().ToLower())
                }).ConfigureAwait(false);
            var runes = JsonConvert.DeserializeObject<RuneListStatic>(json);
            wrapper = new RuneListStaticWrapper(runes, language, runeData);
            cache.Add(RunesCacheKey, wrapper, SlidingExpirationTime);
            return wrapper.RuneListStatic;
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
            var json = await requester.CreateGetRequestAsync(
                StaticDataRootUrl + string.Format(RuneByIdUrl, runeId), region,
                new List<string>
                {
                    $"locale={language}",
                    runeData == RuneData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, runeData.ToString().ToLower())
                }).ConfigureAwait(false);
            var rune = JsonConvert.DeserializeObject<RuneStatic>(json);
            cache.Add(RuneByIdCacheKey + runeId, new RuneStaticWrapper(rune, language, runeData), SlidingExpirationTime);
            return rune;
        }
        #endregion

        #region Summoner Spells
 
        public async Task<SummonerSpellListStatic> GetSummonerSpellsAsync(Region region,
            SummonerSpellData summonerSpellData = SummonerSpellData.All, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
            if (wrapper != null && wrapper.Language == language && wrapper.SummonerSpellData == summonerSpellData)
            {
                return wrapper.SummonerSpellListStatic;
            }
            var json = await requester.CreateGetRequestAsync(StaticDataRootUrl + SummonerSpellsUrl, region,
                new List<string>
                {
                    $"locale={language}",
                    summonerSpellData == SummonerSpellData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, summonerSpellData.ToString().ToLower())
                }).ConfigureAwait(false);
            var spells = JsonConvert.DeserializeObject<SummonerSpellListStatic>(json);
            wrapper = new SummonerSpellListStaticWrapper(spells, language, summonerSpellData);
            cache.Add(SummonerSpellsCacheKey, wrapper, SlidingExpirationTime);
            return wrapper.SummonerSpellListStatic;
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
            var json = await requester.CreateGetRequestAsync(
                StaticDataRootUrl + string.Format(SummonerSpellByIdUrl, summonerSpellId), region,
                new List<string>
                {
                    $"locale={language}",
                    summonerSpellData == SummonerSpellData.Basic ?
                        string.Empty :
                        string.Format(TagsParameter, summonerSpellData.ToString().ToLower())
                }).ConfigureAwait(false);
            var spell = JsonConvert.DeserializeObject<SummonerSpellStatic>(json);
            cache.Add(SummonerSpellByIdCacheKey + summonerSpellId,
                new SummonerSpellStaticWrapper(spell, language, summonerSpellData), SlidingExpirationTime);
            return spell;
        }
        #endregion

        #region Versions

        public async Task<List<string>> GetVersionsAsync(Region region)
        {
            var wrapper = cache.Get<string, List<string>>(VersionsCacheKey);
            if (wrapper != null)
            {
                return wrapper;
            }

            var json =
                await requester.CreateGetRequestAsync(StaticDataRootUrl + VersionsUrl, region).ConfigureAwait(false);
            var version = JsonConvert.DeserializeObject<List<string>>(json);

            cache.Add(VersionsCacheKey, version, SlidingExpirationTime);

            return version;
        }
        #endregion
        #pragma warning restore CS1591
    }
}
