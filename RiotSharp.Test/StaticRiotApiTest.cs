using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using RiotSharp.Http;
using System;
using RiotSharp.Caching;

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
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var champs = _api.GetChampionsAsync(StaticRiotApiTestBase.Region);

                Assert.IsTrue(champs.Result.Champions.Count > 0);
            });
        }

        #endregion

        #region Items Tests

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
