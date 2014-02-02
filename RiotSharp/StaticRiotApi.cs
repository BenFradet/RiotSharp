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
        private const string ChampionsCacheKey = "champions";
        private const string ChampionCacheKey = "champion";

        private const string ItemRootUrl = "/api/lol/static-data/{0}/v1/item";
        private const string ItemsCacheKey = "items";
        private const string ItemCacheKey = "item";

        private const string IdUrl = "/{0}";

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

        public ChampionListStatic GetChampions(Region region, ChampionData championData = ChampionData.all
            , Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ChampionListStaticWrapper>(ChampionsCacheKey);
            if (wrapper == null || language != wrapper.Language || championData != wrapper.ChampionData)
            {
                var json = requester.CreateRequest(string.Format(ChampionRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                        , championData == ChampionData.none ? string.Empty 
                            : string.Format("champData={0}", championData.ToString()) });
                var champs = JsonConvert.DeserializeObject<ChampionListStatic>(json);

                wrapper = new ChampionListStaticWrapper(champs, language, championData);
                Cache.Add<ChampionListStaticWrapper>(ChampionsCacheKey, wrapper);
            }
            return wrapper.ChampionListStatic;
        }

        public async Task<ChampionListStatic> GetChampionsAsync(Region region
            , ChampionData championData = ChampionData.all, Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ChampionListStaticWrapper>(ChampionsCacheKey);
            if (wrapper == null || language != wrapper.Language || championData != wrapper.ChampionData)
            {
                var json = await requester.CreateRequestAsync(string.Format(ChampionRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                        , championData == ChampionData.none ? string.Empty 
                            : string.Format("champData={0}", championData.ToString()) });
                var champs = await JsonConvert.DeserializeObjectAsync<ChampionListStatic>(json);

                wrapper = new ChampionListStaticWrapper(champs, language, championData);
                Cache.Add<ChampionListStaticWrapper>(ChampionsCacheKey, wrapper);
            }
            return wrapper.ChampionListStatic;
        }

        public ChampionStatic GetChampion(Region region, int championId
            , ChampionData championData = ChampionData.all, Language language = Language.en_US)
        {
            var listWrapper = Cache.Get<ChampionListStaticWrapper>(ChampionsCacheKey);
            var wrapper = Cache.Get<ChampionStaticWrapper>(ChampionCacheKey + championId);
            if (wrapper != null && wrapper.Language == language && wrapper.ChampionData == championData)
            {
                return wrapper.ChampionStatic;
            }
            else
            {
                if (listWrapper != null && listWrapper.Language == language && listWrapper.ChampionData == championData)
                {
                    return listWrapper.ChampionListStatic.Champions.Values
                        .Where((c) => c.Key == championId).FirstOrDefault();
                }
                else
                {
                    var json = requester.CreateRequest(string.Format(ChampionRootUrl, region.ToString())
                        + string.Format(IdUrl, championId)
                        , new List<string>() { string.Format("locale={0}", language.ToString())
                            , championData == ChampionData.none ? string.Empty 
                                : string.Format("champData={0}", championData.ToString()) });
                    var champ = JsonConvert.DeserializeObject<ChampionStatic>(json);

                    wrapper = new ChampionStaticWrapper(champ, language, championData);
                    Cache.Add<ChampionStaticWrapper>(ChampionCacheKey + championId, wrapper);
                    return champ;
                }
            }
        }

        public async Task<ChampionStatic> GetChampionAsync(Region region, int championId
            , ChampionData championData = ChampionData.all, Language language = Language.en_US)
        {
            var listWrapper = Cache.Get<ChampionListStaticWrapper>(ChampionsCacheKey);
            var wrapper = Cache.Get<ChampionStaticWrapper>(ChampionCacheKey + championId);
            if (wrapper != null && wrapper.Language == language && wrapper.ChampionData == championData)
            {
                return wrapper.ChampionStatic;
            }
            else
            {
                if (listWrapper != null && listWrapper.Language == language && listWrapper.ChampionData == championData)
                {
                    return listWrapper.ChampionListStatic.Champions.Values
                        .Where((c) => c.Key == championId).FirstOrDefault();
                }
                else
                {
                    var json = await requester.CreateRequestAsync(string.Format(ChampionRootUrl, region.ToString())
                        + string.Format(IdUrl, championId)
                        , new List<string>() { string.Format("local={0}", language.ToString())
                            , championData == ChampionData.none ? string.Empty 
                                : string.Format("champData={0}", championData.ToString()) });
                    var champ = await JsonConvert.DeserializeObjectAsync<ChampionStatic>(json);

                    wrapper = new ChampionStaticWrapper(champ, language, championData);
                    Cache.Add<ChampionStaticWrapper>(ChampionCacheKey + championId, wrapper);
                    return champ;
                }
            }
        }

        public ItemListStatic GetItems(Region region, ItemData itemData = ItemData.all, Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ItemListStaticWrapper>(ItemsCacheKey);
            if (wrapper == null || language != wrapper.Language || itemData != wrapper.ItemData)
            {
                var json = requester.CreateRequest(string.Format(ItemRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                        , itemData == ItemData.none ? string.Empty
                            : string.Format("itemListData={0}", itemData.ToString()) });
                var items = JsonConvert.DeserializeObject<ItemListStatic>(json);

                wrapper = new ItemListStaticWrapper(items, language, itemData);
                Cache.Add<ItemListStaticWrapper>(ItemsCacheKey, wrapper);
            }
            return wrapper.ItemListStatic;
        }

        public async Task<ItemListStatic> GetItemsAsync(Region region, ItemData itemData = ItemData.all
            , Language language = Language.en_US)
        {
            var wrapper = Cache.Get<ItemListStaticWrapper>(ItemsCacheKey);
            if (wrapper == null || language != wrapper.Language || itemData != wrapper.ItemData)
            {
                var json = await requester.CreateRequestAsync(string.Format(ItemRootUrl, region.ToString())
                    , new List<string>() { string.Format("locale={0}", language.ToString())
                        , itemData == ItemData.none ? string.Empty
                            : string.Format("itemListData={0}", itemData.ToString()) });
                var items = await JsonConvert.DeserializeObjectAsync<ItemListStatic>(json);

                wrapper = new ItemListStaticWrapper(items, language, itemData);
                Cache.Add<ItemListStaticWrapper>(ItemsCacheKey, wrapper);
            }
            return wrapper.ItemListStatic;
        }

        public ItemStatic GetItem(Region region, int itemId, ItemData itemData = ItemData.all
            , Language language = Language.en_US)
        {
            var listWrapper = Cache.Get<ItemListStaticWrapper>(ItemsCacheKey);
            var wrapper = Cache.Get<ItemStaticWrapper>(ItemCacheKey + itemId);
            if (wrapper != null && wrapper.Language == language && wrapper.ItemData == itemData)
            {
                return wrapper.ItemStatic;
            }
            else
            {
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
                    var json = requester.CreateRequest(string.Format(ItemRootUrl, region.ToString())
                        + string.Format(IdUrl, itemId)
                        , new List<string>() { string.Format("locale={0}", language.ToString())
                            , itemData == ItemData.none ? string.Empty
                                : string.Format("itemData={0}", itemData.ToString()) });
                    var item = JsonConvert.DeserializeObject<ItemStatic>(json);

                    wrapper = new ItemStaticWrapper(item, language, itemData);
                    Cache.Add<ItemStaticWrapper>(ItemCacheKey + itemId, wrapper);
                    return item;
                }
            }
        }

        public async Task<ItemStatic> GetItemAsync(Region region, int itemId, ItemData itemData = ItemData.all
            , Language language = Language.en_US)
        {
            var listWrapper = Cache.Get<ItemListStaticWrapper>(ItemsCacheKey);
            var wrapper = Cache.Get<ItemStaticWrapper>(ItemCacheKey + itemId);
            if (wrapper != null && wrapper.Language == language && wrapper.ItemData == itemData)
            {
                return wrapper.ItemStatic;
            }
            else
            {
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
                    var json = await requester.CreateRequestAsync(string.Format(ItemRootUrl, region.ToString())
                        + string.Format(IdUrl, itemId)
                        , new List<string>() { string.Format("local={0}", language.ToString())
                            , itemData == ItemData.none ? string.Empty
                                : string.Format("itemData={0}", itemData.ToString()) });
                    var item = await JsonConvert.DeserializeObjectAsync<ItemStatic>(json);

                    wrapper = new ItemStaticWrapper(item, language, itemData);
                    Cache.Add<ItemStaticWrapper>(ItemCacheKey + itemId, wrapper);
                    return item;
                }
            }
        }

    }
}
