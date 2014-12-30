﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaticRiotApi.cs" company="">
//
// </copyright>
// <summary>
//   Entry point for the static API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using RiotSharp.StaticDataEndpoint;

namespace RiotSharp
{
    /// <summary>
    /// Entry point for the static API.
    /// </summary>
    public class StaticRiotApi
    {
        /// <summary>
        /// The champion root url.
        /// </summary>
        private const string ChampionRootUrl = "/api/lol/static-data/{0}/v1.2/champion";

        /// <summary>
        /// The champions cache key.
        /// </summary>
        private const string ChampionsCacheKey = "champions";

        /// <summary>
        /// The champion cache key.
        /// </summary>
        private const string ChampionCacheKey = "champion";

        /// <summary>
        /// The item root url.
        /// </summary>
        private const string ItemRootUrl = "/api/lol/static-data/{0}/v1.2/item";

        /// <summary>
        /// The items cache key.
        /// </summary>
        private const string ItemsCacheKey = "items";

        /// <summary>
        /// The item cache key.
        /// </summary>
        private const string ItemCacheKey = "item";

        /// <summary>
        /// The mastery root url.
        /// </summary>
        private const string MasteryRootUrl = "/api/lol/static-data/{0}/v1.2/mastery";

        /// <summary>
        /// The masteries cache key.
        /// </summary>
        private const string MasteriesCacheKey = "masteries";

        /// <summary>
        /// The mastery cache key.
        /// </summary>
        private const string MasteryCacheKey = "mastery";

        /// <summary>
        /// The rune root url.
        /// </summary>
        private const string RuneRootUrl = "/api/lol/static-data/{0}/v1.2/rune";

        /// <summary>
        /// The runes cache key.
        /// </summary>
        private const string RunesCacheKey = "runes";

        /// <summary>
        /// The rune cache key.
        /// </summary>
        private const string RuneCacheKey = "rune";

        /// <summary>
        /// The summoner spell root url.
        /// </summary>
        private const string SummonerSpellRootUrl = "/api/lol/static-data/{0}/v1.2/summoner-spell";

        /// <summary>
        /// The summoner spells cache key.
        /// </summary>
        private const string SummonerSpellsCacheKey = "spells";

        /// <summary>
        /// The summoner spell cache key.
        /// </summary>
        private const string SummonerSpellCacheKey = "spell";

        /// <summary>
        /// The version root url.
        /// </summary>
        private const string VersionRootUrl = "/api/lol/static-data/{0}/v1.2/versions";

        /// <summary>
        /// The realm root url.
        /// </summary>
        private const string RealmRootUrl = "/api/lol/static-data/{0}/v1.2/realm";

        /// <summary>
        /// The id url.
        /// </summary>
        private const string IdUrl = "/{0}";

        /// <summary>
        /// The root domain.
        /// </summary>
        private const Region RootDomain = Region.global;

        /// <summary>
        /// The requester.
        /// </summary>
        private readonly Requester requester;

        /// <summary>
        /// The instance.
        /// </summary>
        private static StaticRiotApi instance;

        /// <summary>
        /// Get the instance of StaticRiotApi.
        /// </summary>
        /// <param name="apiKey">
        /// The api key.
        /// </param>
        /// <returns>
        /// The instance of StaticRiotApi.
        /// </returns>
        public static StaticRiotApi GetInstance(string apiKey)
        {
            if (instance == null || apiKey != Requester.ApiKey)
            {
                instance = new StaticRiotApi(apiKey);
            }

            return instance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticRiotApi"/> class.
        /// </summary>
        /// <param name="apiKey">
        /// The api key.
        /// </param>
        private StaticRiotApi(string apiKey)
        {
            requester = Requester.Instance;
            Requester.ApiKey = apiKey;
        }

        /// <summary>
        /// Get a list of all champions synchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="championData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// A ChampionListStatic object containing all champions.
        /// </returns>
        public ChampionListStatic GetChampions(
            Region region,
            ChampionData championData = ChampionData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ChampionListStaticWrapper>(ChampionsCacheKey);
            if (wrapper == null || language != wrapper.Language || championData != wrapper.ChampionData)
            {
                var json = requester.CreateRequest(
                    string.Format(ChampionRootUrl, region),
                    RootDomain,
                    new List<string>
                        {
                            string.Format("locale={0}", language),
                            championData == ChampionData.none
                                ? string.Empty
                                : string.Format("champData={0}", championData)
                        });
                var champs = JsonConvert.DeserializeObject<ChampionListStatic>(json);
                wrapper = new ChampionListStaticWrapper(champs, language, championData);
                Cache.Add(ChampionsCacheKey, wrapper);
            }

            return wrapper.ChampionListStatic;
        }

        /// <summary>
        /// Get a list of all champions asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="championData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// A ChampionListStatic object containing all champions.
        /// </returns>
        public async Task<ChampionListStatic> GetChampionsAsync(
            Region region,
            ChampionData championData = ChampionData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ChampionListStaticWrapper>(ChampionsCacheKey);
            if (wrapper == null || language != wrapper.Language || championData != wrapper.ChampionData)
            {
                var json =
                    await
                    requester.CreateRequestAsync(
                        string.Format(ChampionRootUrl, region),
                        RootDomain,
                        new List<string>
                            {
                                string.Format("locale={0}", language),
                                championData == ChampionData.none
                                    ? string.Empty
                                    : string.Format("champData={0}", championData)
                            });
                var champs = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ChampionListStatic>(json));
                wrapper = new ChampionListStaticWrapper(champs, language, championData);
                Cache.Add(ChampionsCacheKey, wrapper);
            }

            return wrapper.ChampionListStatic;
        }

        /// <summary>
        /// Get a champion synchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="championId">
        /// Id of the champion to retrieve.
        /// </param>
        /// <param name="championData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// A champion.
        /// </returns>
        public ChampionStatic GetChampion(
            Region region,
            int championId,
            ChampionData championData = ChampionData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ChampionStaticWrapper>(ChampionCacheKey + championId);
            if (wrapper != null && wrapper.Language == language && wrapper.ChampionData == championData)
            {
                return wrapper.ChampionStatic;
            }

            var listWrapper = Cache.Get<ChampionListStaticWrapper>(ChampionsCacheKey);
            if (listWrapper != null && listWrapper.Language == language && listWrapper.ChampionData == championData)
            {
                return listWrapper.ChampionListStatic.Champions.Values.FirstOrDefault(c => c.Id == championId);
            }

            var json =
                this.requester.CreateRequest(
                    string.Format(ChampionRootUrl, region) + string.Format(IdUrl, championId),
                    RootDomain,
                    new List<string>
                        {
                            string.Format("locale={0}", language),
                            championData == ChampionData.none
                                ? string.Empty
                                : string.Format("champData={0}", championData)
                        });
            var champ = JsonConvert.DeserializeObject<ChampionStatic>(json);
            Cache.Add(ChampionCacheKey + championId, new ChampionStaticWrapper(champ, language, championData));
            return champ;
        }

        /// <summary>
        /// Get a champion asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="championId">
        /// Id of the champion to retrieve.
        /// </param>
        /// <param name="championData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// A champion.
        /// </returns>
        public async Task<ChampionStatic> GetChampionAsync(
            Region region,
            int championId,
            ChampionData championData = ChampionData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ChampionStaticWrapper>(ChampionCacheKey + championId);
            if (wrapper != null && wrapper.Language == language && wrapper.ChampionData == championData)
            {
                return wrapper.ChampionStatic;
            }

            var listWrapper = Cache.Get<ChampionListStaticWrapper>(ChampionsCacheKey);
            if (listWrapper != null && listWrapper.Language == language && listWrapper.ChampionData == championData)
            {
                return listWrapper.ChampionListStatic.Champions.Values.FirstOrDefault(c => c.Id == championId);
            }

            var json =
                await
                this.requester.CreateRequestAsync(
                    string.Format(ChampionRootUrl, region) + string.Format(IdUrl, championId),
                    RootDomain,
                    new List<string>
                        {
                            string.Format("locale={0}", language),
                            championData == ChampionData.none
                                ? string.Empty
                                : string.Format("champData={0}", championData)
                        });
            var champ = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ChampionStatic>(json));
            Cache.Add(ChampionCacheKey + championId, new ChampionStaticWrapper(champ, language, championData));
            return champ;
        }

        /// <summary>
        /// Get a list of all items synchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="itemData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// An ItemListStatic object containing all items.
        /// </returns>
        public ItemListStatic GetItems(
            Region region,
            ItemData itemData = ItemData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ItemListStaticWrapper>(ItemsCacheKey);
            if (wrapper == null || language != wrapper.Language || itemData != wrapper.ItemData)
            {
                var json = requester.CreateRequest(
                    string.Format(ItemRootUrl, region),
                    RootDomain,
                    new List<string>
                        {
                            string.Format("locale={0}", language),
                            itemData == ItemData.none
                                ? string.Empty
                                : string.Format("itemListData={0}", itemData)
                        });
                var items = JsonConvert.DeserializeObject<ItemListStatic>(json);
                wrapper = new ItemListStaticWrapper(items, language, itemData);
                Cache.Add(ItemsCacheKey, wrapper);
            }

            return wrapper.ItemListStatic;
        }

        /// <summary>
        /// Get a list of all items synchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="itemData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// An ItemListStatic object containing all items.
        /// </returns>
        public async Task<ItemListStatic> GetItemsAsync(
            Region region,
            ItemData itemData = ItemData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ItemListStaticWrapper>(ItemsCacheKey);
            if (wrapper == null || language != wrapper.Language || itemData != wrapper.ItemData)
            {
                var json =
                    await
                    requester.CreateRequestAsync(
                        string.Format(ItemRootUrl, region),
                        RootDomain,
                        new List<string>
                            {
                                string.Format("locale={0}", language),
                                itemData == ItemData.none
                                    ? string.Empty
                                    : string.Format("itemListData={0}", itemData)
                            });
                var items = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ItemListStatic>(json));
                wrapper = new ItemListStaticWrapper(items, language, itemData);
                Cache.Add(ItemsCacheKey, wrapper);
            }

            return wrapper.ItemListStatic;
        }

        /// <summary>
        /// Get an item synchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="itemId">
        /// Id of the item to retrieve.
        /// </param>
        /// <param name="itemData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// An item.
        /// </returns>
        public ItemStatic GetItem(
            Region region,
            int itemId,
            ItemData itemData = ItemData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ItemStaticWrapper>(ItemCacheKey + itemId);
            if (wrapper != null && wrapper.Language == language && wrapper.ItemData == itemData)
            {
                return wrapper.ItemStatic;
            }

            var listWrapper = Cache.Get<ItemListStaticWrapper>(ItemsCacheKey);
            if (listWrapper != null && listWrapper.Language == language && listWrapper.ItemData == itemData)
            {
                if (listWrapper.ItemListStatic.Items.ContainsKey(itemId))
                {
                    return listWrapper.ItemListStatic.Items[itemId];
                }

                return null;
            }

            var json = this.requester.CreateRequest(
                string.Format(ItemRootUrl, region) + string.Format(IdUrl, itemId),
                RootDomain,
                new List<string>
                    {
                        string.Format("locale={0}", language),
                        itemData == ItemData.none ? string.Empty : string.Format("itemData={0}", itemData)
                    });
            var item = JsonConvert.DeserializeObject<ItemStatic>(json);
            Cache.Add(ItemCacheKey + itemId, new ItemStaticWrapper(item, language, itemData));
            return item;
        }

        /// <summary>
        /// Get an item asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="itemId">
        /// Id of the item to retrieve.
        /// </param>
        /// <param name="itemData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// An item.
        /// </returns>
        public async Task<ItemStatic> GetItemAsync(
            Region region,
            int itemId,
            ItemData itemData = ItemData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ItemStaticWrapper>(ItemCacheKey + itemId);
            if (wrapper != null && wrapper.Language == language && wrapper.ItemData == itemData)
            {
                return wrapper.ItemStatic;
            }

            var listWrapper = Cache.Get<ItemListStaticWrapper>(ItemsCacheKey);
            if (listWrapper != null && listWrapper.Language == language && listWrapper.ItemData == itemData)
            {
                if (listWrapper.ItemListStatic.Items.ContainsKey(itemId))
                {
                    return listWrapper.ItemListStatic.Items[itemId];
                }

                return null;
            }

            var json =
                await
                this.requester.CreateRequestAsync(
                    string.Format(ItemRootUrl, region) + string.Format(IdUrl, itemId),
                    RootDomain,
                    new List<string>
                        {
                            string.Format("locale={0}", language),
                            itemData == ItemData.none
                                ? string.Empty
                                : string.Format("itemData={0}", itemData)
                        });
            var item = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ItemStatic>(json));
            Cache.Add(ItemCacheKey + itemId, new ItemStaticWrapper(item, language, itemData));
            return item;
        }

        /// <summary>
        /// Get a list of all masteries synchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="masteryData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// An MasteryListStatic object containing all masteries.
        /// </returns>
        public MasteryListStatic GetMasteries(
            Region region,
            MasteryData masteryData = MasteryData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<MasteryListStaticWrapper>(MasteriesCacheKey);
            if (wrapper == null || language != wrapper.Language || masteryData != wrapper.MasteryData)
            {
                var json = requester.CreateRequest(
                    string.Format(MasteryRootUrl, region),
                    RootDomain,
                    new List<string>
                        {
                            string.Format("locale={0}", language),
                            masteryData == MasteryData.none
                                ? string.Empty
                                : string.Format("masteryListData={0}", masteryData)
                        });
                var masteries = JsonConvert.DeserializeObject<MasteryListStatic>(json);
                wrapper = new MasteryListStaticWrapper(masteries, language, masteryData);
                Cache.Add(MasteriesCacheKey, wrapper);
            }

            return wrapper.MasteryListStatic;
        }

        /// <summary>
        /// Get a list of all masteries asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="masteryData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// An MasteryListStatic object containing all masteries.
        /// </returns>
        public async Task<MasteryListStatic> GetMasteriesAsync(
            Region region,
            MasteryData masteryData = MasteryData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<MasteryListStaticWrapper>(MasteriesCacheKey);
            if (wrapper == null || language != wrapper.Language || masteryData != wrapper.MasteryData)
            {
                var json =
                    await
                    requester.CreateRequestAsync(
                        string.Format(MasteryRootUrl, region),
                        RootDomain,
                        new List<string>
                            {
                                string.Format("locale={0}", language),
                                masteryData == MasteryData.none
                                    ? string.Empty
                                    : string.Format("masteryListData={0}", masteryData)
                            });
                var masteries =
                    await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<MasteryListStatic>(json));
                wrapper = new MasteryListStaticWrapper(masteries, language, masteryData);
                Cache.Add(MasteriesCacheKey, wrapper);
            }

            return wrapper.MasteryListStatic;
        }

        /// <summary>
        /// Get a mastery synchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="masteryId">
        /// Id of the mastery to retrieve.
        /// </param>
        /// <param name="masteryData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of th data to be retrieved.
        /// </param>
        /// <returns>
        /// A mastery.
        /// </returns>
        public MasteryStatic GetMastery(
            Region region,
            int masteryId,
            MasteryData masteryData = MasteryData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<MasteryStaticWrapper>(MasteryCacheKey + masteryId);
            if (wrapper != null && wrapper.Language == language && wrapper.MasteryData == masteryData)
            {
                return wrapper.MasteryStatic;
            }

            var listWrapper = Cache.Get<MasteryListStaticWrapper>(MasteriesCacheKey);
            if (listWrapper != null && listWrapper.Language == language && listWrapper.MasteryData == masteryData)
            {
                if (listWrapper.MasteryListStatic.Masteries.ContainsKey(masteryId))
                {
                    return listWrapper.MasteryListStatic.Masteries[masteryId];
                }

                return null;
            }

            var json =
                this.requester.CreateRequest(
                    string.Format(MasteryRootUrl, region) + string.Format(IdUrl, masteryId),
                    RootDomain,
                    new List<string>
                        {
                            string.Format("locale={0}", language),
                            masteryData == MasteryData.none
                                ? string.Empty
                                : string.Format("masteryData={0}", masteryData)
                        });
            var mastery = JsonConvert.DeserializeObject<MasteryStatic>(json);
            Cache.Add(MasteryCacheKey + masteryId, new MasteryStaticWrapper(mastery, language, masteryData));
            return mastery;
        }

        /// <summary>
        /// Get a mastery asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="masteryId">
        /// Id of the mastery to retrieve.
        /// </param>
        /// <param name="masteryData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of th data to be retrieved.
        /// </param>
        /// <returns>
        /// A mastery.
        /// </returns>
        public async Task<MasteryStatic> GetMasteryAsync(
            Region region,
            int masteryId,
            MasteryData masteryData = MasteryData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<MasteryStaticWrapper>(MasteryCacheKey + masteryId);
            if (wrapper != null && wrapper.Language == language && wrapper.MasteryData == masteryData)
            {
                return wrapper.MasteryStatic;
            }

            var listWrapper = Cache.Get<MasteryListStaticWrapper>(MasteriesCacheKey);
            if (listWrapper != null && listWrapper.Language == language && listWrapper.MasteryData == masteryData)
            {
                if (listWrapper.MasteryListStatic.Masteries.ContainsKey(masteryId))
                {
                    return listWrapper.MasteryListStatic.Masteries[masteryId];
                }

                return null;
            }

            var json =
                await
                this.requester.CreateRequestAsync(
                    string.Format(MasteryRootUrl, region) + string.Format(IdUrl, masteryId),
                    RootDomain,
                    new List<string>
                        {
                            string.Format("locale={0}", language),
                            masteryData == MasteryData.none
                                ? string.Empty
                                : string.Format("masteryData={0}", masteryData)
                        });
            var mastery = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<MasteryStatic>(json));
            Cache.Add(MasteryCacheKey + masteryId, new MasteryStaticWrapper(mastery, language, masteryData));
            return mastery;
        }

        /// <summary>
        /// Get a list of all runes synchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="runeData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// A RuneListStatic object containing all runes.
        /// </returns>
        public RuneListStatic GetRunes(
            Region region,
            RuneData runeData = RuneData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<RuneListStaticWrapper>(RunesCacheKey);
            if (wrapper == null || language != wrapper.Language || runeData != wrapper.RuneData)
            {
                var json = requester.CreateRequest(
                    string.Format(RuneRootUrl, region),
                    RootDomain,
                    new List<string>
                        {
                            string.Format("locale={0}", language),
                            runeData == RuneData.none
                                ? string.Empty
                                : string.Format("runeListData={0}", runeData)
                        });
                var runes = JsonConvert.DeserializeObject<RuneListStatic>(json);
                wrapper = new RuneListStaticWrapper(runes, language, runeData);
                Cache.Add(RunesCacheKey, wrapper);
            }

            return wrapper.RuneListStatic;
        }

        /// <summary>
        /// Get a list of all runes asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="runeData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// A RuneListStatic object containing all runes.
        /// </returns>
        public async Task<RuneListStatic> GetRunesAsync(
            Region region,
            RuneData runeData = RuneData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<RuneListStaticWrapper>(RunesCacheKey);
            if (wrapper == null || language != wrapper.Language | runeData != wrapper.RuneData)
            {
                var json =
                    await
                    requester.CreateRequestAsync(
                        string.Format(RuneRootUrl, region),
                        RootDomain,
                        new List<string>
                            {
                                string.Format("locale={0}", language),
                                runeData == RuneData.none
                                    ? string.Empty
                                    : string.Format("runeListData={0}", runeData)
                            });
                var runes = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<RuneListStatic>(json));
                wrapper = new RuneListStaticWrapper(runes, language, runeData);
                Cache.Add(RunesCacheKey, wrapper);
            }

            return wrapper.RuneListStatic;
        }

        /// <summary>
        /// Get a rune synchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="runeId">
        /// Id of the rune to retrieve.
        /// </param>
        /// <param name="runeData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// A rune.
        /// </returns>
        public RuneStatic GetRune(
            Region region,
            int runeId,
            RuneData runeData = RuneData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<RuneStaticWrapper>(RuneCacheKey + runeId);
            if (wrapper != null && wrapper.Language == language && wrapper.RuneData == RuneData.all)
            {
                return wrapper.RuneStatic;
            }

            var listWrapper = Cache.Get<RuneListStaticWrapper>(RunesCacheKey);
            if (listWrapper != null && listWrapper.Language == language && listWrapper.RuneData == runeData)
            {
                if (listWrapper.RuneListStatic.Runes.ContainsKey(runeId))
                {
                    return listWrapper.RuneListStatic.Runes[runeId];
                }

                return null;
            }

            var json = this.requester.CreateRequest(
                string.Format(RuneRootUrl, region) + string.Format(IdUrl, runeId),
                RootDomain,
                new List<string>
                    {
                        string.Format("locale={0}", language),
                        runeData == RuneData.none ? string.Empty : string.Format("runeData={0}", runeData)
                    });
            var rune = JsonConvert.DeserializeObject<RuneStatic>(json);
            Cache.Add(RuneCacheKey + runeId, new RuneStaticWrapper(rune, language, runeData));
            return rune;
        }

        /// <summary>
        /// Get a rune asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="runeId">
        /// Id of the rune to retrieve.
        /// </param>
        /// <param name="runeData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// A rune.
        /// </returns>
        public async Task<RuneStatic> GetRuneAsync(
            Region region,
            int runeId,
            RuneData runeData = RuneData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<RuneStaticWrapper>(RuneCacheKey + runeId);
            if (wrapper != null && wrapper.Language == language && wrapper.RuneData == RuneData.all)
            {
                return wrapper.RuneStatic;
            }

            var listWrapper = Cache.Get<RuneListStaticWrapper>(RunesCacheKey);
            if (listWrapper != null && listWrapper.Language == language && listWrapper.RuneData == runeData)
            {
                if (listWrapper.RuneListStatic.Runes.ContainsKey(runeId))
                {
                    return listWrapper.RuneListStatic.Runes[runeId];
                }

                return null;
            }

            var json =
                await
                this.requester.CreateRequestAsync(
                    string.Format(RuneRootUrl, region) + string.Format(IdUrl, runeId),
                    RootDomain,
                    new List<string>
                        {
                            string.Format("locale={0}", language),
                            runeData == RuneData.none
                                ? string.Empty
                                : string.Format("runeData={0}", runeData)
                        });
            var rune = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<RuneStatic>(json));
            Cache.Add(RuneCacheKey + runeId, new RuneStaticWrapper(rune, language, runeData));
            return rune;
        }

        /// <summary>
        /// Get a list of all summoner spells synchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="summonerSpellData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// A SummonerSpellListStatic object containing all summoner spells.
        /// </returns>
        public SummonerSpellListStatic GetSummonerSpells(
            Region region,
            SummonerSpellData summonerSpellData = SummonerSpellData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
            if (wrapper == null || wrapper.Language != language || wrapper.SummonerSpellData != summonerSpellData)
            {
                var json = requester.CreateRequest(
                    string.Format(SummonerSpellRootUrl, region),
                    RootDomain,
                    new List<string>
                        {
                            string.Format("locale={0}", language),
                            summonerSpellData == SummonerSpellData.none
                                ? string.Empty
                                : string.Format("spellData={0}", summonerSpellData)
                        });
                var spells = JsonConvert.DeserializeObject<SummonerSpellListStatic>(json);
                wrapper = new SummonerSpellListStaticWrapper(spells, language, summonerSpellData);
                Cache.Add(SummonerSpellsCacheKey, wrapper);
            }

            return wrapper.SummonerSpellListStatic;
        }

        /// <summary>
        /// Get a list of all summoner spells asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="summonerSpellData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// A SummonerSpellListStatic object containing all summoner spells.
        /// </returns>
        public async Task<SummonerSpellListStatic> GetSummonerSpellsAsync(
            Region region,
            SummonerSpellData summonerSpellData = SummonerSpellData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
            if (wrapper == null || wrapper.Language != language || wrapper.SummonerSpellData != summonerSpellData)
            {
                var json =
                    await
                    requester.CreateRequestAsync(
                        string.Format(SummonerSpellRootUrl, region),
                        RootDomain,
                        new List<string>
                            {
                                string.Format("locale={0}", language),
                                summonerSpellData == SummonerSpellData.none
                                    ? string.Empty
                                    : string.Format("spellData={0}", summonerSpellData)
                            });
                var spells =
                    await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<SummonerSpellListStatic>(json));
                wrapper = new SummonerSpellListStaticWrapper(spells, language, summonerSpellData);
                Cache.Add(SummonerSpellsCacheKey, wrapper);
            }

            return wrapper.SummonerSpellListStatic;
        }

        /// <summary>
        /// Get a summoner spell synchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="summonerSpell">
        /// Summoner spell to retrieve.
        /// </param>
        /// <param name="summonerSpellData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// A summoner spell.
        /// </returns>
        public SummonerSpellStatic GetSummonerSpell(
            Region region,
            SummonerSpell summonerSpell,
            SummonerSpellData summonerSpellData = SummonerSpellData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<SummonerSpellStaticWrapper>(SummonerSpellCacheKey + summonerSpell.ToCustomString());
            if (wrapper != null && wrapper.SummonerSpellData == summonerSpellData && wrapper.Language == language)
            {
                return wrapper.SummonerSpellStatic;
            }

            var listWrapper = Cache.Get<SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
            if (listWrapper != null && listWrapper.SummonerSpellData == summonerSpellData
                && listWrapper.Language == language)
            {
                if (listWrapper.SummonerSpellListStatic.SummonerSpells.ContainsKey(summonerSpell.ToCustomString()))
                {
                    return listWrapper.SummonerSpellListStatic.SummonerSpells[summonerSpell.ToCustomString()];
                }

                return null;
            }

            var json =
                this.requester.CreateRequest(
                    string.Format(SummonerSpellRootUrl, region) + string.Format(IdUrl, (int)summonerSpell),
                    RootDomain,
                    new List<string>
                        {
                            string.Format("locale={0}", language),
                            summonerSpellData == SummonerSpellData.none
                                ? string.Empty
                                : string.Format("spellData={0}", summonerSpellData)
                        });
            var spell = JsonConvert.DeserializeObject<SummonerSpellStatic>(json);
            Cache.Add(
                SummonerSpellCacheKey + summonerSpell.ToCustomString(),
                new SummonerSpellStaticWrapper(spell, language, summonerSpellData));
            return spell;
        }

        /// <summary>
        /// Get a summoner spell asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve the data.
        /// </param>
        /// <param name="summonerSpell">
        /// Summoner spell to retrieve.
        /// </param>
        /// <param name="summonerSpellData">
        /// Data to retrieve.
        /// </param>
        /// <param name="language">
        /// Language of the data to be retrieved.
        /// </param>
        /// <returns>
        /// A summoner spell.
        /// </returns>
        public async Task<SummonerSpellStatic> GetSummonerSpellAsync(
            Region region,
            SummonerSpell summonerSpell,
            SummonerSpellData summonerSpellData = SummonerSpellData.none,
            Language language = Language.en_US)
        {
            var wrapper = Cache.Get<SummonerSpellStaticWrapper>(SummonerSpellCacheKey + summonerSpell.ToCustomString());
            if (wrapper != null && wrapper.SummonerSpellData == summonerSpellData && wrapper.Language == language)
            {
                return wrapper.SummonerSpellStatic;
            }

            var listWrapper = Cache.Get<SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
            if (listWrapper != null && listWrapper.SummonerSpellData == summonerSpellData
                && listWrapper.Language == language)
            {
                if (listWrapper.SummonerSpellListStatic.SummonerSpells.ContainsKey(summonerSpell.ToCustomString()))
                {
                    return listWrapper.SummonerSpellListStatic.SummonerSpells[summonerSpell.ToCustomString()];
                }

                return null;
            }

            var json =
                await
                this.requester.CreateRequestAsync(
                    string.Format(SummonerSpellRootUrl, region) + string.Format(IdUrl, (int)summonerSpell),
                    RootDomain,
                    new List<string>
                        {
                            string.Format("locale={0}", language),
                            summonerSpellData == SummonerSpellData.none
                                ? string.Empty
                                : string.Format("spellData={0}", summonerSpellData)
                        });
            var spell = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<SummonerSpellStatic>(json));
            Cache.Add(
                SummonerSpellCacheKey + summonerSpell.ToCustomString(),
                new SummonerSpellStaticWrapper(spell, language, summonerSpellData));
            return spell;
        }

        /// <summary>
        /// Retrieve static api version data synchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve data.
        /// </param>
        /// <returns>
        /// A list of versions as strings.
        /// </returns>
        public List<string> GetVersions(Region region)
        {
            var json = requester.CreateRequest(string.Format(VersionRootUrl, region), RootDomain);
            return JsonConvert.DeserializeObject<List<string>>(json);
        }

        /// <summary>
        /// Retrieve static api version data asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region from which to retrieve data.
        /// </param>
        /// <returns>
        /// A list of versions as strings.
        /// </returns>
        public async Task<List<string>> GetVersionsAsync(Region region)
        {
            var json =
                await requester.CreateRequestAsync(string.Format(VersionRootUrl, region), RootDomain);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<string>>(json));
        }

        /// <summary>
        /// Retrieve real data synchronously.
        /// </summary>
        /// <param name="region">
        /// Region corresponding to data to retrieve.
        /// </param>
        /// <returns>
        /// A realm object containing the requested information.
        /// </returns>
        public Realm GetRealm(Region region)
        {
            var json = requester.CreateRequest(string.Format(RealmRootUrl, region), RootDomain);
            return JsonConvert.DeserializeObject<Realm>(json);
        }

        /// <summary>
        /// Retrieve real data asynchronously.
        /// </summary>
        /// <param name="region">
        /// Region corresponding to data to retrieve.
        /// </param>
        /// <returns>
        /// A realm object containing the requested information.
        /// </returns>
        public async Task<Realm> GetRealmAsync(Region region)
        {
            var json = await requester.CreateRequestAsync(string.Format(RealmRootUrl, region), RootDomain);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Realm>(json));
        }
    }
}
