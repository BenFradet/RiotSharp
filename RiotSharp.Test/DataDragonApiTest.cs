using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint;

namespace RiotSharp.Test
{
    [TestClass]
    public class DataDragonApiTest : DataDragonApiTestBase
    {
        private readonly IDataDragonEndpoints _api;
        private const string TestCategory = "DataDragonApi";

        public DataDragonApiTest()
        {
            var cache = new Cache();
            _api = DataDragonEndpoints.GetInstance(true);
        }

        #region Champions Tests

        [TestMethod]
        [TestCategory(TestCategory), TestCategory("Async")]
        public async Task GetByKeyAsync_GetChampionByKeyAsync_ReturnAnnie()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var champ = await _api.Champions.GetByKeyAsync(StaticChampionKey, StaticVersion);
                Assert.AreEqual(StaticChampionNameAnnie, champ.Name);
            });
        }

        [TestMethod]
        [TestCategory(TestCategory), TestCategory("Async")]
        public async Task GetByIdAsync_GetChampionByIdAsync_ReturnAarox()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var aatroxId = 266;
                var champ = await _api.Champions.GetByIdAsync(aatroxId, StaticVersion);
                Assert.AreEqual(StaticChampionNameAatrox, champ.Name);
            });
        }

        [TestMethod]
        [TestCategory(TestCategory), TestCategory("Async")]
        public async Task GetAllAsync_GetChampionsAsync_ReturnChampions()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var champs = await _api.Champions.GetAllAsync(StaticVersion, fullData: false);
                Assert.IsTrue(champs.Champions.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory(TestCategory), TestCategory("Async")]
        public async Task GetAllAsync_GetChampionsAsync_ReturnAChampionWithPassiveAndSpells()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var champs = await _api.Champions.GetAllAsync(StaticVersion, fullData: true);
                var champion = champs.Champions.First();
                Assert.IsTrue(champs.Champions.Count > 0);
                Assert.IsNotNull(champion.Value.Passive);
                Assert.IsNotNull(champion.Value.Spells);
            });
        }

        #endregion

        #region Items Tests

        [TestMethod]
        [TestCategory(TestCategory), TestCategory("Async")]
        public async Task GetAllAsync_GetItems_ReturnAllItems()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var items = await _api.Items.GetAllAsync(StaticVersion);
                var item = items.Items.First();

                Assert.IsTrue(items.Items.Count > 0);
                Assert.IsTrue(item.Value.Id > 0);
                Assert.IsTrue(!string.IsNullOrEmpty(item.Value.Name));
            });
        }

        [TestMethod]
        [TestCategory(TestCategory), TestCategory("Async")]
        public async Task SerializeObject_ItemListStatic_ReturnDeserializeList()
        {
            await EnsureCredibilityAsync(async () =>
            {
                // Arrange 
                var itemsSample = await _api.Items.GetAllAsync(StaticVersion);
                var itemSample = itemsSample.Items.First();

                // Act
                var itemsJson = JsonConvert.SerializeObject(itemsSample);
                var items = JsonConvert.DeserializeObject<Endpoints.StaticDataEndpoint.Item.ItemListStatic>(itemsJson);
                var item = items.Items.First();
                
                // Assert
                Assert.AreEqual(itemsSample.Items.Count, items.Items.Count);
                Assert.AreEqual(itemSample.Value.Id, item.Value.Id);
                Assert.AreEqual(itemSample.Value.Name, item.Value.Name);
            });
        }

        #endregion

        #region Language Strings Tests

        [TestMethod]
        [TestCategory(TestCategory), TestCategory("Async")]
        public async Task GetLanguageStringsAsync_GetLanguageStrings_ReturnLanguageStrings()
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
        [TestCategory(TestCategory), TestCategory("Async")]
        public async Task GetLanguagesAsync_GetLanguages_ReturnLanguages()
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
        [TestCategory(TestCategory), TestCategory("Async")]
        public async Task GetMapsAsync_GetsAllMaps_ReturnAllMaps()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var maps = await _api.Maps.GetAllAsync(StaticVersion);
                Assert.IsTrue(maps.Count > 0);
            });
        }

        #endregion

        #region Masteries

        [TestMethod]
        [TestCategory(TestCategory), TestCategory("Async")]
        public async Task GetAllAsync_GetMasteriesAsync_ReturnAllMasteries()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var masteries = await _api.Masteries.GetAllAsync(LegacyVersion); 
                Assert.IsTrue(masteries.Masteries.Count > 0);
            });
        }

        #endregion

        #region Profile Icons Tests

        [TestMethod]
        [TestCategory(TestCategory), TestCategory("Async")]
        public async Task GetAllAsync_GetProfileIconsAsync_ReturnAllProfileIcons()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var profileIcons = await _api.ProfileIcons.GetAllAsync(StaticVersion);
                Assert.IsTrue(profileIcons.ProfileIcons.Count > 0);
            });
        }

        #endregion

        #region Reforged Runes

        [TestMethod]
        [TestCategory(TestCategory), TestCategory("Async")]
        public async Task GetAllAsync_GetReforgedRunesAsync_ReturnAllReforgedRunes()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var reforgedRunes = await _api.ReforgedRunes.GetAllAsync(StaticVersion);
                Assert.IsTrue(reforgedRunes.Count > 0);
            });
        }

        #endregion

        #region Runes

        [TestMethod]
        [TestCategory(TestCategory), TestCategory("Async")]
        public async Task GetAllAsync_GetRunesAsync_ReturnAllRunes()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var runes = await _api.Runes.GetAllAsync(LegacyVersion);
                Assert.IsTrue(runes.Runes.Count > 0);
            });
        }

        #endregion

        #region Summoner Spells Tests

        [TestMethod]
        [TestCategory(TestCategory), TestCategory("Async")]
        public async Task GetAllAsync_GetSummonerSpellsAsync_ReturnAllSummonerSpells()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var spells = await _api.SummonerSpells.GetAllAsync(StaticVersion);
                Assert.IsTrue(spells.SummonerSpells.Count > 0);
            });
        }

        #endregion

        #region Versions Tests

        [TestMethod]
        [TestCategory(TestCategory), TestCategory("Async")]
        public async Task GetAllAsync_GetVersionsAsync_ReturnAllVersions()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var versions = await _api.Versions.GetAllAsync();
                Assert.IsTrue(versions.Count > 0);
            });
        }

        #endregion

        #region Realms Tests

        [TestMethod]
        [TestCategory(TestCategory), TestCategory("Async")]
        public async Task GetAllAsync_GetRealmAsync_ReturnAllRealms()
        {
            await EnsureCredibilityAsync(async () =>
            {
                var realm = await _api.Realms.GetAllAsync(Region);
                Assert.IsNotNull(realm);
            });
        }

        #endregion

        #region TarballLinks Tests

        [TestMethod]
        [TestCategory(TestCategory), TestCategory("Async")]
        public void Get_GetTarballLink_ReturnTarballLinks()
        {
            var tarballLink = _api.TarballLinks.Get(StaticVersion);
            Assert.IsFalse(string.IsNullOrEmpty(tarballLink));
        }

        #endregion
    }
}
