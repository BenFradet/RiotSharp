using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint;

namespace RiotSharp.Test
{
    [TestClass]
    public class StaticRiotApiTest : StaticRiotApiTestBase
    {
        private readonly IStaticDataEndpoints _api;

        public StaticRiotApiTest()
        {
            var cache = new Cache();
            _api = StaticDataEndpoints.GetInstance(true);
        }

        #region Champions Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public async Task GetChampionAsync_Test()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var champ = await _api.Champions.GetChampionAsync(StaticChampionKey, StaticVersion);
                Assert.AreEqual(StaticChampionName, champ.Name);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public async Task GetChampionsAsync_Test()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var champs = await _api.Champions.GetChampionsAsync(StaticVersion);
                Assert.IsTrue(champs.Champions.Count > 0);
            });
        }

        #endregion

        #region Items Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public async Task GetItemsAsync_Test()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var items = await _api.Items.GetItemsAsync(StaticVersion);
                Assert.IsTrue(items.Items.Count > 0);
            });
        }

        #endregion

        #region Language Strings Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public async Task GetLanguageStringsAsync_Test()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var strings = await _api.Languages.GetLanguageStringsAsync(StaticVersion);
                Assert.IsTrue(strings.Data.Count > 0);
            });
        }

        #endregion

        #region Languages Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public async Task GetLanguagesAsync_Test()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var langs = await _api.Languages.GetLanguagesAsync();
                Assert.IsTrue(langs.Count > 0);
            });
        }

        #endregion

        #region Maps Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public async Task GetMapsAsync_Test()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var maps = await _api.Maps.GetMapsAsync(StaticVersion);
                Assert.IsTrue(maps.Count > 0);
            });
        }

        #endregion

        #region Masteries

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public async Task GetMasteriesAsync_Test()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var masteries = await _api.Masteries.GetMasteriesAsync(LegacyVersion); 
                Assert.IsTrue(masteries.Masteries.Count > 0);
            });
        }

        #endregion

        #region Profile Icons Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public async Task GetProfileIconsAsync_Test()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var profileIcons = await _api.ProfileIcons.GetProfileIconsAsync(StaticVersion);
                Assert.IsTrue(profileIcons.ProfileIcons.Count > 0);
            });
        }

        #endregion

        #region Reforged Runes

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public async Task GetReforgedRunesAsync_Test()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var reforgedRunes = await _api.ReforgedRunes.GetReforgedRunesAsync(StaticVersion);
                Assert.IsTrue(reforgedRunes.Count > 0);
            });
        }

        #endregion

        #region Runes

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public async Task GetRunesAsync_Test()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var runes = await _api.Runes.GetRunesAsync(LegacyVersion);
                Assert.IsTrue(runes.Runes.Count > 0);
            });
        }

        #endregion

        #region Summoner Spells Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public async Task GetSummonerSpellsAsync_Test()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var spells = await _api.SummonerSpells.GetSummonerSpellsAsync(StaticVersion);
                Assert.IsTrue(spells.SummonerSpells.Count > 0);
            });
        }

        #endregion

        #region Versions Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public async Task GetVersionsAsync_Test()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var versions = await _api.Versions.GetVersionsAsync();
                Assert.IsTrue(versions.Count > 0);
            });
        }

        #endregion

        #region Realms Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public async Task GetRealmAsync_Test()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var realm = await _api.Realms.GetRealmAsync(Region);
                Assert.IsNotNull(realm);
            });
        }

        #endregion

        #region TarballLinks Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetTarballLinksAsyncVersion_Test()
        {
            var tarballLink = _api.TarballLinks.GetTarballLink(StaticVersion);
            Assert.IsFalse(string.IsNullOrEmpty(tarballLink));
        }

        #endregion
    }
}
