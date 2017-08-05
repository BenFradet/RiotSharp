using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RiotSharp;
using RiotSharp.StaticDataEndpoint;
using System.Collections.Generic;
using System.Linq;
using RiotSharp.StaticDataEndpoint.Champion;
using RiotSharp.Http;
using System;

namespace RiotSharp.Test
{
    [TestClass]
    public class StaticRiotApiTest : CommonTestBase
    {
        private StaticRiotApi api; 
        private static RateLimitedRequester requester = new RateLimitedRequester(apiKey, new Dictionary<TimeSpan, int>
            {
                { new TimeSpan(1, 0, 0), 10 }
            });

        public StaticRiotApiTest()
        {
            var cache = new Cache();
            api = new StaticRiotApi(requester, cache);
        }

        #region Constructor Tests
        [TestMethod]
        public void StaticRiotApiTest_SetSlidingExpirationTime_Test()
        {
            // Arrange
            var timeSpan = new TimeSpan(5, 34, 23);

            // Act 
            var staticRiotApi = new StaticRiotApi(requester, new Cache(), timeSpan);

            // Assert
            Assert.AreEqual(timeSpan, staticRiotApi.SlidingExpirationTime);
        }

        [TestMethod]
        public void StaticRiotApiTest_NoSlidingExpirationTimeProvided_Test()
        {
            // Act 
            var staticRiotApi = new StaticRiotApi(requester, new Cache());

            // Assert
            Assert.AreEqual(new TimeSpan(1, 0, 0), staticRiotApi.SlidingExpirationTime);
        }
        #endregion

        #region Champions Tests
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetChampion_Test()
        {
            EnsureCredibility(() => 
            {
                var champ = api.GetChampion(StaticRiotApiTestBase.region, 
                    StaticRiotApiTestBase.staticChampionId, ChampionData.All);

                Assert.AreEqual(StaticRiotApiTestBase.staticChampionName, champ.Name);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var champ = api.GetChampionAsync(StaticRiotApiTestBase.region, 
                    StaticRiotApiTestBase.staticChampionId, ChampionData.All);

                Assert.AreEqual(StaticRiotApiTestBase.staticChampionName, champ.Result.Name);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetChampions_Test()
        {
            EnsureCredibility(() =>
            {
                var champs = api.GetChampions(StaticRiotApiTestBase.region, ChampionData.All);

                Assert.IsTrue(champs.Champions.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var champs = api.GetChampionsAsync(StaticRiotApiTestBase.region, ChampionData.All);

                Assert.IsTrue(champs.Result.Champions.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void SerializeChampions_Test()
        {
            EnsureCredibility(() =>
            {
                var champs = api.GetChampions(StaticRiotApiTestBase.region, ChampionData.Basic);
                ICollection<ChampionStatic> champ = champs.Champions.Values;
                string json = JsonConvert.SerializeObject(champ);
                champ = JsonConvert.DeserializeObject<List<ChampionStatic>>(json);
            });
        }
        #endregion

        #region Items Tests
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetItems_Test()
        {
            EnsureCredibility(() =>
            {
                var items = api.GetItems(StaticRiotApiTestBase.region, ItemData.All);

                Assert.IsTrue(items.Items.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetItemsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var items = api.GetItemsAsync(StaticRiotApiTestBase.region, ItemData.All);

                Assert.IsTrue(items.Result.Items.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetItem_Test()
        {
            EnsureCredibility(() =>
            {
                var item = api.GetItem(StaticRiotApiTestBase.region, StaticRiotApiTestBase.staticItemId, ItemData.All);

                Assert.AreEqual(StaticRiotApiTestBase.staticItemName, item.Name);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetItemAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var item = api.GetItemAsync(StaticRiotApiTestBase.region, 
                    StaticRiotApiTestBase.staticItemId, ItemData.All);

                Assert.AreEqual(StaticRiotApiTestBase.staticItemName, item.Result.Name);
            });
        }
        #endregion

        #region Language Strings Tests
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetLanguageStrings_Test()
        {
            EnsureCredibility(() =>
            {
                var strings = api.GetLanguageStrings(StaticRiotApiTestBase.region);

                Assert.IsTrue(strings.Data.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetLanguageStringsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var strings = api.GetLanguageStringsAsync(StaticRiotApiTestBase.region);

                Assert.IsTrue(strings.Result.Data.Count > 0);
            });
        }
        #endregion

        #region Languages Tests
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetLanguages_Test()
        {
            EnsureCredibility(() => 
            {
                var langs = api.GetLanguages(StaticRiotApiTestBase.region);

                Assert.IsTrue(langs.Count > 0);
            });          
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetLanguagesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var langs = api.GetLanguagesAsync(StaticRiotApiTestBase.region);

                Assert.IsTrue(langs.Result.Count > 0);
            });
        }
        #endregion

        #region Maps Tests
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetMaps_Test()
        {
            EnsureCredibility(() =>
            {
                var maps = api.GetMaps(StaticRiotApiTestBase.region);

                Assert.IsTrue(maps.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetMapsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var maps = api.GetMapsAsync(StaticRiotApiTestBase.region);

                Assert.IsTrue(maps.Result.Count > 0);
            });
        }
        #endregion

        #region Masteries
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetMasteries_Test()
        {
            EnsureCredibility(() =>
            {
                var masteries = api.GetMasteries(StaticRiotApiTestBase.region, MasteryData.All);

                Assert.IsTrue(masteries.Masteries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetMasteriesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var masteries = api.GetMasteriesAsync(StaticRiotApiTestBase.region, MasteryData.All);

                Assert.IsTrue(masteries.Result.Masteries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetMastery_Test()
        {
            EnsureCredibility(() =>
            {
                var mastery = api.GetMastery(StaticRiotApiTestBase.region, 
                    StaticRiotApiTestBase.staticMasteryId, MasteryData.All);

                Assert.AreEqual(StaticRiotApiTestBase.staticMasteryName, mastery.Name);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetMasteryAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var mastery = api.GetMasteryAsync(StaticRiotApiTestBase.region, 
                    StaticRiotApiTestBase.staticMasteryId, MasteryData.All);

                Assert.AreEqual(StaticRiotApiTestBase.staticMasteryName, mastery.Result.Name);
            });
        }
        #endregion

        #region Profile Icons Tests
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetProfileIcons_Test()
        {
            EnsureCredibility(() =>
            {
                var profileIcons = api.GetProfileIcons(StaticRiotApiTestBase.region);

                Assert.IsTrue(profileIcons.ProfileIcons.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetProfileIconsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var profileIcons = api.GetProfileIconsAsync(StaticRiotApiTestBase.region).Result;

                Assert.IsTrue(profileIcons.ProfileIcons.Count > 0);
            });
        }
        #endregion

        #region Runes
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetRunes_Test()
        {
            EnsureCredibility(() =>
            {
                var runes = api.GetRunes(StaticRiotApiTestBase.region, RuneData.All);

                Assert.IsTrue(runes.Runes.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRunesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var runes = api.GetRunesAsync(StaticRiotApiTestBase.region, RuneData.All);

                Assert.IsTrue(runes.Result.Runes.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetRune_Test()
        {
            EnsureCredibility(() =>
            {
                var rune = api.GetRune(StaticRiotApiTestBase.region, StaticRiotApiTestBase.staticRuneId, RuneData.All);

                Assert.AreEqual(StaticRiotApiTestBase.staticRuneName, rune.Name);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRuneAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var rune = api.GetRuneAsync(StaticRiotApiTestBase.region, 
                    StaticRiotApiTestBase.staticRuneId, RuneData.All);

                Assert.AreEqual(StaticRiotApiTestBase.staticRuneName, rune.Result.Name);
            });
        }
        #endregion

        #region Summoner Spells Tests
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetSummonerSpells_Test()
        {
            EnsureCredibility(() =>
            {
                var spells = api.GetSummonerSpells(StaticRiotApiTestBase.region, SummonerSpellData.All);

                Assert.IsTrue(spells.SummonerSpells.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetSummonerSpellsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var spells = api.GetSummonerSpellsAsync(StaticRiotApiTestBase.region, SummonerSpellData.All);

                Assert.IsTrue(spells.Result.SummonerSpells.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetSummonerSpell_Test()
        {
            EnsureCredibility(() =>
            {
                var spell = api.GetSummonerSpell(StaticRiotApiTestBase.region,
                    (int)StaticRiotApiTestBase.staticSummonerSpell, SummonerSpellData.All);

                Assert.AreEqual(StaticRiotApiTestBase.staticSummonerSpellName, spell.Name);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetSummonerSpellAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var spell = api.GetSummonerSpellAsync(StaticRiotApiTestBase.region,
                    (int)StaticRiotApiTestBase.staticSummonerSpell, SummonerSpellData.All);

                Assert.AreEqual(StaticRiotApiTestBase.staticSummonerSpellName, spell.Result.Name);
            });
        }
        #endregion

        #region Versions Tests
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetVersions_Test()
        {
            EnsureCredibility(() =>
            {
                var versions = api.GetVersions(StaticRiotApiTestBase.region);

                Assert.IsTrue(versions.Count() > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetVersionsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var versions = api.GetVersionsAsync(StaticRiotApiTestBase.region);

                Assert.IsTrue(versions.Result.Count() > 0);
            });
        }
        #endregion

        #region Realms Tests
        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetRealm_Test()
        {
            EnsureCredibility(() =>
            {
                var realm = api.GetRealm(StaticRiotApiTestBase.region);

                Assert.IsNotNull(realm);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRealmAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var realm = api.GetRealmAsync(StaticRiotApiTestBase.region);

                Assert.IsNotNull(realm.Result);
            });
        }
        #endregion
    }
}
