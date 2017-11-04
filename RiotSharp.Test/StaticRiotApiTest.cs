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
        private readonly StaticRiotApi _api; 
        private static readonly RateLimitedRequester Requester = new RateLimitedRequester(ApiKey, new Dictionary<TimeSpan, int>
            {
                { new TimeSpan(1, 0, 0), 10 }
            });

        public StaticRiotApiTest()
        {
            var cache = new Cache();
            _api = new StaticRiotApi(Requester, cache);
        }

        #region Constructor Tests
        [TestMethod]
        public void StaticRiotApiTest_SetSlidingExpirationTime_Test()
        {
            // Arrange
            var timeSpan = new TimeSpan(5, 34, 23);

            // Act 
            var staticRiotApi = new StaticRiotApi(Requester, new Cache(), timeSpan);

            // Assert
            Assert.AreEqual(timeSpan, staticRiotApi.SlidingExpirationTime);
        }

        [TestMethod]
        public void StaticRiotApiTest_NoSlidingExpirationTimeProvided_Test()
        {
            // Act 
            var staticRiotApi = new StaticRiotApi(Requester, new Cache());

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
                var champ = _api.GetChampion(StaticRiotApiTestBase.Region, 
                    StaticRiotApiTestBase.StaticChampionId);

                Assert.AreEqual(StaticRiotApiTestBase.StaticChampionName, champ.Name);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var champ = _api.GetChampionAsync(StaticRiotApiTestBase.Region, 
                    StaticRiotApiTestBase.StaticChampionId);

                Assert.AreEqual(StaticRiotApiTestBase.StaticChampionName, champ.Result.Name);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetChampions_Test()
        {
            EnsureCredibility(() =>
            {
                var champs = _api.GetChampions(StaticRiotApiTestBase.Region);

                Assert.IsTrue(champs.Champions.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var champs = _api.GetChampionsAsync(StaticRiotApiTestBase.Region);

                Assert.IsTrue(champs.Result.Champions.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void SerializeChampions_Test()
        {
            EnsureCredibility(() =>
            {
                var champs = _api.GetChampions(StaticRiotApiTestBase.Region, ChampionData.Basic);
                ICollection<ChampionStatic> champ = champs.Champions.Values;
                var json = JsonConvert.SerializeObject(champ);
                champ = JsonConvert.DeserializeObject<List<ChampionStatic>>(json);

                Assert.IsNotNull(champ);
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
                var items = _api.GetItems(StaticRiotApiTestBase.Region);

                Assert.IsTrue(items.Items.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetItemsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var items = _api.GetItemsAsync(StaticRiotApiTestBase.Region);

                Assert.IsTrue(items.Result.Items.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetItem_Test()
        {
            EnsureCredibility(() =>
            {
                var item = _api.GetItem(StaticRiotApiTestBase.Region, StaticRiotApiTestBase.StaticItemId);

                Assert.AreEqual(StaticRiotApiTestBase.StaticItemName, item.Name);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetItemAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var item = _api.GetItemAsync(StaticRiotApiTestBase.Region, 
                    StaticRiotApiTestBase.StaticItemId);

                Assert.AreEqual(StaticRiotApiTestBase.StaticItemName, item.Result.Name);
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
                var strings = _api.GetLanguageStrings(StaticRiotApiTestBase.Region);

                Assert.IsTrue(strings.Data.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetLanguageStringsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var strings = _api.GetLanguageStringsAsync(StaticRiotApiTestBase.Region);

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
                var langs = _api.GetLanguages(StaticRiotApiTestBase.Region);

                Assert.IsTrue(langs.Count > 0);
            });          
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetLanguagesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var langs = _api.GetLanguagesAsync(StaticRiotApiTestBase.Region);

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
                var maps = _api.GetMaps(StaticRiotApiTestBase.Region);

                Assert.IsTrue(maps.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetMapsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var maps = _api.GetMapsAsync(StaticRiotApiTestBase.Region);

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
                var masteries = _api.GetMasteries(StaticRiotApiTestBase.Region);

                Assert.IsTrue(masteries.Masteries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetMasteriesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var masteries = _api.GetMasteriesAsync(StaticRiotApiTestBase.Region);

                Assert.IsTrue(masteries.Result.Masteries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetMastery_Test()
        {
            EnsureCredibility(() =>
            {
                var mastery = _api.GetMastery(StaticRiotApiTestBase.Region, 
                    StaticRiotApiTestBase.StaticMasteryId);

                Assert.AreEqual(StaticRiotApiTestBase.StaticMasteryName, mastery.Name);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetMasteryAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var mastery = _api.GetMasteryAsync(StaticRiotApiTestBase.Region, 
                    StaticRiotApiTestBase.StaticMasteryId);

                Assert.AreEqual(StaticRiotApiTestBase.StaticMasteryName, mastery.Result.Name);
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
                var profileIcons = _api.GetProfileIcons(StaticRiotApiTestBase.Region);

                Assert.IsTrue(profileIcons.ProfileIcons.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetProfileIconsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var profileIcons = _api.GetProfileIconsAsync(StaticRiotApiTestBase.Region).Result;

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
                var runes = _api.GetRunes(StaticRiotApiTestBase.Region);

                Assert.IsTrue(runes.Runes.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRunesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var runes = _api.GetRunesAsync(StaticRiotApiTestBase.Region);

                Assert.IsTrue(runes.Result.Runes.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetRune_Test()
        {
            EnsureCredibility(() =>
            {
                var rune = _api.GetRune(StaticRiotApiTestBase.Region, StaticRiotApiTestBase.StaticRuneId);

                Assert.AreEqual(StaticRiotApiTestBase.StaticRuneName, rune.Name);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRuneAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var rune = _api.GetRuneAsync(StaticRiotApiTestBase.Region, 
                    StaticRiotApiTestBase.StaticRuneId);

                Assert.AreEqual(StaticRiotApiTestBase.StaticRuneName, rune.Result.Name);
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
                var spells = _api.GetSummonerSpells(StaticRiotApiTestBase.Region);

                Assert.IsTrue(spells.SummonerSpells.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetSummonerSpellsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var spells = _api.GetSummonerSpellsAsync(StaticRiotApiTestBase.Region);

                Assert.IsTrue(spells.Result.SummonerSpells.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi")]
        public void GetSummonerSpell_Test()
        {
            EnsureCredibility(() =>
            {
                var spell = _api.GetSummonerSpell(StaticRiotApiTestBase.Region,
                    (int)StaticRiotApiTestBase.StaticSummonerSpell);

                Assert.AreEqual(StaticRiotApiTestBase.StaticSummonerSpellName, spell.Name);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetSummonerSpellAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var spell = _api.GetSummonerSpellAsync(StaticRiotApiTestBase.Region,
                    (int)StaticRiotApiTestBase.StaticSummonerSpell);

                Assert.AreEqual(StaticRiotApiTestBase.StaticSummonerSpellName, spell.Result.Name);
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
                var versions = _api.GetVersions(StaticRiotApiTestBase.Region);

                Assert.IsTrue(versions.Count() > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetVersionsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var versions = _api.GetVersionsAsync(StaticRiotApiTestBase.Region);

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
                var realm = _api.GetRealm(StaticRiotApiTestBase.Region);

                Assert.IsNotNull(realm);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRealmAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var realm = _api.GetRealmAsync(StaticRiotApiTestBase.Region);

                Assert.IsNotNull(realm.Result);
            });
        }
        #endregion
    }
}
