﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaticRiotApiTest.cs" company="">
//
// </copyright>
// <summary>
//   The static riot api test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using RiotSharp;
using RiotSharp.StaticDataEndpoint;

namespace RiotSharpTest
{
    /// <summary>
    /// The static riot api test.
    /// </summary>
    [TestClass]
    public class StaticRiotApiTest
    {
        /// <summary>
        /// The api key.
        /// </summary>
        private static string apiKey = ConfigurationManager.AppSettings["ApiKey"];

        /// <summary>
        /// The api.
        /// </summary>
        private static StaticRiotApi api = StaticRiotApi.GetInstance(apiKey);

        /// <summary>
        /// The get champion_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetChampion_Test()
        {
            var champ = api.GetChampion(Region.euw, 1, ChampionData.all);

            Assert.AreEqual(champ.Name, "Annie");
        }

        /// <summary>
        /// The get champion async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            var champ = api.GetChampionAsync(Region.euw, 1, ChampionData.all);

            Assert.AreEqual(champ.Result.Name, "Annie");
        }

        /// <summary>
        /// The get champions_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetChampions_Test()
        {
            var champs = api.GetChampions(Region.euw, ChampionData.all);

            Assert.IsNotNull(champs.Champions);
            Assert.IsTrue(champs.Champions.Count > 0);
        }

        /// <summary>
        /// The get champions async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            var champs = api.GetChampionsAsync(Region.euw, ChampionData.all);

            Assert.IsNotNull(champs.Result.Champions);
            Assert.IsTrue(champs.Result.Champions.Count > 0);
        }

        /// <summary>
        /// The get items_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetItems_Test()
        {
            var items = api.GetItems(Region.euw, ItemData.all);

            Assert.IsNotNull(items.Items);
            Assert.IsTrue(items.Items.Count > 0);
        }

        /// <summary>
        /// The get items async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetItemsAsync_Test()
        {
            var items = api.GetItemsAsync(Region.euw, ItemData.all);

            Assert.IsNotNull(items.Result.Items);
            Assert.IsTrue(items.Result.Items.Count > 0);
        }

        /// <summary>
        /// The get item_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetItem_Test()
        {
            var item = api.GetItem(Region.euw, 1001, ItemData.all);

            Assert.AreEqual(item.Name, "Boots of Speed");
        }

        /// <summary>
        /// The get item async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetItemAsync_Test()
        {
            var item = api.GetItemAsync(Region.euw, 1001, ItemData.all);

            Assert.AreEqual(item.Result.Name, "Boots of Speed");
        }

        /// <summary>
        /// The get masteries_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetMasteries_Test()
        {
            var masteries = api.GetMasteries(Region.euw, MasteryData.all);

            Assert.IsNotNull(masteries.Masteries);
            Assert.IsTrue(masteries.Masteries.Count > 0);
        }

        /// <summary>
        /// The get masteries async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetMasteriesAsync_Test()
        {
            var masteries = api.GetMasteriesAsync(Region.euw, MasteryData.all);

            Assert.IsNotNull(masteries.Result.Masteries);
            Assert.IsTrue(masteries.Result.Masteries.Count > 0);
        }

        /// <summary>
        /// The get mastery_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetMastery_Test()
        {
            var mastery = api.GetMastery(Region.euw, 4111, MasteryData.all);

            Assert.AreEqual(mastery.Name, "Double-Edged Sword");
        }

        /// <summary>
        /// The get mastery async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetMasteryAsync_Test()
        {
            var mastery = api.GetMasteryAsync(Region.euw, 4111, MasteryData.all);

            Assert.AreEqual(mastery.Result.Name, "Double-Edged Sword");
        }

        /// <summary>
        /// The get runes_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetRunes_Test()
        {
            var runes = api.GetRunes(Region.euw, RuneData.all);

            Assert.IsNotNull(runes);
            Assert.IsTrue(runes.Runes.Count > 0);
        }

        /// <summary>
        /// The get runes async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRunesAsync_Test()
        {
            var runes = api.GetRunesAsync(Region.euw, RuneData.all);

            Assert.IsNotNull(runes.Result);
            Assert.IsTrue(runes.Result.Runes.Count > 0);
        }

        /// <summary>
        /// The get rune_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetRune_Test()
        {
            var rune = api.GetRune(Region.euw, 5001, RuneData.all);

            Assert.AreEqual(rune.Name, "Lesser Mark of Attack Damage");
        }

        /// <summary>
        /// The get rune async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRuneAsync_Test()
        {
            var rune = api.GetRuneAsync(Region.euw, 5001, RuneData.all);

            Assert.AreEqual(rune.Result.Name, "Lesser Mark of Attack Damage");
        }

        /// <summary>
        /// The get summoner spells_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetSummonerSpells_Test()
        {
            var spells = api.GetSummonerSpells(Region.euw, SummonerSpellData.all);

            Assert.IsNotNull(spells.SummonerSpells);
            Assert.IsTrue(spells.SummonerSpells.Count > 0);
        }

        /// <summary>
        /// The get summoner spells async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetSummonerSpellsAsync_Test()
        {
            var spells = api.GetSummonerSpellsAsync(Region.euw, SummonerSpellData.all);

            Assert.IsNotNull(spells.Result.SummonerSpells);
            Assert.IsTrue(spells.Result.SummonerSpells.Count > 0);
        }

        /// <summary>
        /// The get summoner spell_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetSummonerSpell_Test()
        {
            var spell = api.GetSummonerSpell(Region.euw, SummonerSpell.Barrier, SummonerSpellData.all);

            Assert.AreEqual(spell.Name, "Barrier");
        }

        /// <summary>
        /// The get summoner spell async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetSummonerSpellAsync_Test()
        {
            var spell = api.GetSummonerSpellAsync(Region.euw, SummonerSpell.Barrier, SummonerSpellData.all);

            Assert.AreEqual(spell.Result.Name, "Barrier");
        }

        /// <summary>
        /// The get versions_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetVersions_Test()
        {
            var versions = api.GetVersions(Region.euw);

            Assert.IsNotNull(versions);
            Assert.IsTrue(versions.Count() > 0);
        }

        /// <summary>
        /// The get versions async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetVersionsAsync_Test()
        {
            var versions = api.GetVersionsAsync(Region.euw);

            Assert.IsNotNull(versions.Result);
            Assert.IsTrue(versions.Result.Count() > 0);
        }

        /// <summary>
        /// The get realm_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetRealm_Test()
        {
            var realm = api.GetRealm(Region.euw);

            Assert.IsNotNull(realm);
        }

        /// <summary>
        /// The get real async_ test.
        /// </summary>
        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRealAsync_Test()
        {
            var realm = api.GetRealmAsync(Region.euw);

            Assert.IsNotNull(realm.Result);
        }
    }
}
