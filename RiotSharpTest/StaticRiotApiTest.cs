using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RiotSharp;
using RiotSharp.StaticDataEndpoint;
using System.Collections.Generic;
using System.Linq;
using RiotSharp.StaticDataEndpoint.Champion;
using RiotSharp.StaticDataEndpoint.Item;

namespace RiotSharpTest
{
    [TestClass]
    public class StaticRiotApiTest
    {
        private static StaticRiotApi api = StaticRiotApi.GetInstance(StaticRiotApiTestBase.apiKey);

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetChampion_Test()
        {
            var champ = api.GetChampion(StaticRiotApiTestBase.region, StaticRiotApiTestBase.staticChampionId, ChampionData.all);

            Assert.AreEqual(champ.Name, StaticRiotApiTestBase.staticChampionName);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            var champ = api.GetChampionAsync(StaticRiotApiTestBase.region, StaticRiotApiTestBase.staticChampionId, ChampionData.all);

            Assert.AreEqual(champ.Result.Name, StaticRiotApiTestBase.staticChampionName);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetChampions_Test()
        {
            var champs = api.GetChampions(StaticRiotApiTestBase.region, ChampionData.all);

            Assert.IsNotNull(champs.Champions);
            Assert.IsTrue(champs.Champions.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            var champs = api.GetChampionsAsync(StaticRiotApiTestBase.region, ChampionData.all);

            Assert.IsNotNull(champs.Result.Champions);
            Assert.IsTrue(champs.Result.Champions.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void SerializeChampions_Test()
        {
            var champs = api.GetChampions(StaticRiotApiTestBase.region, ChampionData.basic);
            ICollection<ChampionStatic> champ = champs.Champions.Values;
            string json = JsonConvert.SerializeObject(champ);
            champ = JsonConvert.DeserializeObject<List<ChampionStatic>>(json);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetItems_Test()
        {
            var items = api.GetItems(StaticRiotApiTestBase.region, ItemData.all);

            Assert.IsNotNull(items.Items);
            Assert.IsTrue(items.Items.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetItemsAsync_Test()
        {
            var items = api.GetItemsAsync(StaticRiotApiTestBase.region, ItemData.all);

            Assert.IsNotNull(items.Result.Items);
            Assert.IsTrue(items.Result.Items.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetItem_Test()
        {
            var item = api.GetItem(StaticRiotApiTestBase.region, StaticRiotApiTestBase.staticItemId, ItemData.all);

            Assert.AreEqual(item.Name, StaticRiotApiTestBase.staticItemName);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetItemAsync_Test()
        {
            var item = api.GetItemAsync(StaticRiotApiTestBase.region, StaticRiotApiTestBase.staticItemId, ItemData.all);

            Assert.AreEqual(item.Result.Name, StaticRiotApiTestBase.staticItemName);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetLanguageStrings_Test()
        {
            var strings = api.GetLanguageStrings(StaticRiotApiTestBase.region);

            Assert.IsTrue(strings.Data.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetLanguageStringsAsync_Test()
        {
            var strings = api.GetLanguageStringsAsync(StaticRiotApiTestBase.region);

            Assert.IsTrue(strings.Result.Data.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetLanguages_Test()
        {
            var langs = api.GetLanguages(StaticRiotApiTestBase.region);

            Assert.IsTrue(langs.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetLanguagesAsync_Test()
        {
            var langs = api.GetLanguagesAsync(StaticRiotApiTestBase.region);

            Assert.IsTrue(langs.Result.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetMaps_Test()
        {
            var maps = api.GetMaps(StaticRiotApiTestBase.region);

            Assert.IsTrue(maps.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetMapsAsync_Test()
        {
            var maps = api.GetMapsAsync(StaticRiotApiTestBase.region);

            Assert.IsTrue(maps.Result.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetMasteries_Test()
        {
            var masteries = api.GetMasteries(StaticRiotApiTestBase.region, MasteryData.all);

            Assert.IsNotNull(masteries.Masteries);
            Assert.IsTrue(masteries.Masteries.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetMasteriesAsync_Test()
        {
            var masteries = api.GetMasteriesAsync(StaticRiotApiTestBase.region, MasteryData.all);

            Assert.IsNotNull(masteries.Result.Masteries);
            Assert.IsTrue(masteries.Result.Masteries.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetMastery_Test()
        {
            var mastery = api.GetMastery(StaticRiotApiTestBase.region, StaticRiotApiTestBase.staticMasteryId, MasteryData.all);

            Assert.AreEqual(mastery.Name, StaticRiotApiTestBase.staticMasteryName);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetMasteryAsync_Test()
        {
            var mastery = api.GetMasteryAsync(StaticRiotApiTestBase.region, StaticRiotApiTestBase.staticMasteryId, MasteryData.all);

            Assert.AreEqual(mastery.Result.Name, StaticRiotApiTestBase.staticMasteryName);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetRunes_Test()
        {
            var runes = api.GetRunes(StaticRiotApiTestBase.region, RuneData.all);

            Assert.IsNotNull(runes);
            Assert.IsTrue(runes.Runes.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRunesAsync_Test()
        {
            var runes = api.GetRunesAsync(StaticRiotApiTestBase.region, RuneData.all);

            Assert.IsNotNull(runes.Result);
            Assert.IsTrue(runes.Result.Runes.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetRune_Test()
        {
            var rune = api.GetRune(StaticRiotApiTestBase.region, StaticRiotApiTestBase.staticRuneId, RuneData.all);

            Assert.AreEqual(rune.Name, StaticRiotApiTestBase.staticRuneName);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRuneAsync_Test()
        {
            var rune = api.GetRuneAsync(StaticRiotApiTestBase.region, StaticRiotApiTestBase.staticRuneId, RuneData.all);

            Assert.AreEqual(rune.Result.Name, StaticRiotApiTestBase.staticRuneName);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetSummonerSpells_Test()
        {
            var spells = api.GetSummonerSpells(StaticRiotApiTestBase.region, SummonerSpellData.all);

            Assert.IsNotNull(spells.SummonerSpells);
            Assert.IsTrue(spells.SummonerSpells.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetSummonerSpellsAsync_Test()
        {
            var spells = api.GetSummonerSpellsAsync(StaticRiotApiTestBase.region, SummonerSpellData.all);

            Assert.IsNotNull(spells.Result.SummonerSpells);
            Assert.IsTrue(spells.Result.SummonerSpells.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetSummonerSpell_Test()
        {
            var spell = api.GetSummonerSpell(StaticRiotApiTestBase.region, 
                StaticRiotApiTestBase.staticSummonerSpell, SummonerSpellData.all);

            Assert.AreEqual(spell.Name, StaticRiotApiTestBase.staticSummonerSpellName);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetSummonerSpellAsync_Test()
        {
            var spell = api.GetSummonerSpellAsync(StaticRiotApiTestBase.region, 
                StaticRiotApiTestBase.staticSummonerSpell, SummonerSpellData.all);

            Assert.AreEqual(spell.Result.Name, StaticRiotApiTestBase.staticSummonerSpellName);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetVersions_Test()
        {
            var versions = api.GetVersions(StaticRiotApiTestBase.region);

            Assert.IsNotNull(versions);
            Assert.IsTrue(versions.Count() > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetVersionsAsync_Test()
        {
            var versions = api.GetVersionsAsync(StaticRiotApiTestBase.region);

            Assert.IsNotNull(versions.Result);
            Assert.IsTrue(versions.Result.Count() > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetRealm_Test()
        {
            var realm = api.GetRealm(StaticRiotApiTestBase.region);

            Assert.IsNotNull(realm);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRealmAsync_Test()
        {
            var realm = api.GetRealmAsync(StaticRiotApiTestBase.region);

            Assert.IsNotNull(realm.Result);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetItems_WithRequestDelegate_OutputChanges()
        {
            // Arange
            var defaultItems = api.GetItems(CommonTestBase.summoner1and2Region);
            var defaultItem = defaultItems.Items.SingleOrDefault(x => x.Key == 2053);

            // Act
            api.RegisterRequestDelegate(result => 
            {
                var itemList = (ItemListStatic)result;
                itemList.Items.Remove(2053);
            });

            // Assert 
            var itemListStatic = api.GetItems(CommonTestBase.summoner1and2Region);
            var removedItem = itemListStatic.Items.SingleOrDefault(x => x.Key == 2053);
            Assert.IsNull(removedItem.Value);
            Assert.IsNotNull(defaultItem);
        }
    }
}
