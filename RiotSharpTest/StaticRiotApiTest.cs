using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace RiotSharpTest
{
    [TestClass]
    public class StaticRiotApiTest
    {
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        private static StaticRiotApi api = StaticRiotApi.GetInstance(apiKey);

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetChampion_Test()
        {
            var champ = api.GetChampion(Region.euw, 1, ChampionData.none);

            Assert.AreEqual(champ.Name, "Annie");
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            var champ = api.GetChampionAsync(Region.euw, 1, ChampionData.none);

            Assert.AreEqual(champ.Result.Name, "Annie");
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetChampions_Test()
        {
            var champs = api.GetChampions(Region.euw, ChampionData.none);

            Assert.IsNotNull(champs.Champions);
            Assert.IsTrue(champs.Champions.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            var champs = api.GetChampionsAsync(Region.euw, ChampionData.none);

            Assert.IsNotNull(champs.Result.Champions);
            Assert.IsTrue(champs.Result.Champions.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetItems_Test()
        {
            var items = api.GetItems(Region.euw, ItemData.none);

            Assert.IsNotNull(items.Items);
            Assert.IsTrue(items.Items.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetItemsAsync_Test()
        {
            var items = api.GetItemsAsync(Region.euw, ItemData.none);

            Assert.IsNotNull(items.Result.Items);
            Assert.IsTrue(items.Result.Items.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetItem_Test()
        {
            var item = api.GetItem(Region.euw, 1001, ItemData.none);

            Assert.AreEqual(item.Name, "Boots of Speed");
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetItemAsync_Test()
        {
            var item = api.GetItemAsync(Region.euw, 1001, ItemData.none);

            Assert.AreEqual(item.Result.Name, "Boots of Speed");
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetMasteries_Test()
        {
            var masteries = api.GetMasteries(Region.euw, MasteryData.none);

            Assert.IsNotNull(masteries.Data);
            Assert.IsTrue(masteries.Data.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetMasteriesAsync_Test()
        {
            var masteries = api.GetMasteriesAsync(Region.euw, MasteryData.none);

            Assert.IsNotNull(masteries.Result.Data);
            Assert.IsTrue(masteries.Result.Data.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetMastery_Test()
        {
            var mastery = api.GetMastery(Region.euw, 4111, MasteryData.none);

            Assert.AreEqual(mastery.Name, "Double-Edged Sword");
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetMasteryAsync_Test()
        {
            var mastery = api.GetMasteryAsync(Region.euw, 4111, MasteryData.none);

            Assert.AreEqual(mastery.Result.Name, "Double-Edged Sword");
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetRunes_Test()
        {
            var runes = api.GetRunes(Region.euw, RuneData.none);

            Assert.IsNotNull(runes);
            Assert.IsTrue(runes.Data.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRunesAsync_Test()
        {
            var runes = api.GetRunesAsync(Region.euw, RuneData.none);

            Assert.IsNotNull(runes.Result);
            Assert.IsTrue(runes.Result.Data.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetRune_Test()
        {
            var rune = api.GetRune(Region.euw, 5001, RuneData.none);

            Assert.AreEqual(rune.Name, "Lesser Mark of Attack Damage");
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRuneAsync_Test()
        {
            var rune = api.GetRuneAsync(Region.euw, 5001, RuneData.none);

            Assert.AreEqual(rune.Result.Name, "Lesser Mark of Attack Damage");
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetSummonerSpells_Test()
        {
            var spells = api.GetSummonerSpells(Region.euw, SummonerSpellData.none);

            Assert.IsNotNull(spells.Data);
            Assert.IsTrue(spells.Data.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetSummonerSpellsAsync_Test()
        {
            var spells = api.GetSummonerSpellsAsync(Region.euw, SummonerSpellData.none);

            Assert.IsNotNull(spells.Result.Data);
            Assert.IsTrue(spells.Result.Data.Count > 0);
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetSummonerSpell_Test()
        {
            var spell = api.GetSummonerSpell(Region.euw, SummonerSpell.Barrier, SummonerSpellData.none);

            Assert.AreEqual(spell.Name, "Barrier");
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetSummonerSpellAsync_Test()
        {
            var spell = api.GetSummonerSpellAsync(Region.euw, SummonerSpell.Barrier, SummonerSpellData.none);

            Assert.AreEqual(spell.Result.Name, "Barrier");
        }
    }
}
