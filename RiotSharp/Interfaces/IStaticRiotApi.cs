using System.Collections.Generic;
using System.Threading.Tasks;
using RiotSharp.Endpoints.StaticDataEndpoint;
using RiotSharp.Endpoints.StaticDataEndpoint.Champion;
using RiotSharp.Endpoints.StaticDataEndpoint.Item;
using RiotSharp.Endpoints.StaticDataEndpoint.LanguageStrings;
using RiotSharp.Endpoints.StaticDataEndpoint.Map;
using RiotSharp.Endpoints.StaticDataEndpoint.Mastery;
using RiotSharp.Endpoints.StaticDataEndpoint.ProfileIcons;
using RiotSharp.Endpoints.StaticDataEndpoint.Realm;
using RiotSharp.Endpoints.StaticDataEndpoint.Rune;
using RiotSharp.Endpoints.StaticDataEndpoint.SummonerSpell;
using RiotSharp.Misc;

namespace RiotSharp.Interfaces
{

    /// <summary>
    /// Entry point for the static API.
    /// </summary>
    public interface IStaticRiotApi
    {
        /// <summary>
        /// Get a list of all champions asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="championData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A ChampionListStatic object containing all champions.</returns>
        Task<ChampionListStatic> GetChampionsAsync(Region region,
            ChampionData championData = ChampionData.All, Language language = Language.en_US);

        /// <summary>
        /// Get a champion asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="championId">Id of the champion to retrieve.</param>
        /// <param name="championData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A champion.</returns>
        Task<ChampionStatic> GetChampionAsync(Region region, int championId,
            ChampionData championData = ChampionData.All, Language language = Language.en_US);

        /// <summary>
        /// Get a list of all items synchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="itemData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>An ItemListStatic object containing all items.</returns>
        Task<ItemListStatic> GetItemsAsync(Region region, ItemData itemData = ItemData.All,
            Language language = Language.en_US);

        /// <summary>
        /// Get an item asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="itemId">Id of the item to retrieve.</param>
        /// <param name="itemData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>An item.</returns>
        Task<ItemStatic> GetItemAsync(Region region, int itemId, ItemData itemData = ItemData.All,
            Language language = Language.en_US);

        /// <summary>
        /// Retrieve language strings asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <param name="version">Version of the dragon API.</param>
        /// <returns>A object containing the language strings.</returns>
        Task<LanguageStringsStatic> GetLanguageStringsAsync(Region region,
            Language language = Language.en_US, string version = "");

        /// <summary>
        /// Get languages asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <returns>A list of languages.</returns>
        Task<List<Language>> GetLanguagesAsync(Region region);

        /// <summary>
        /// Get maps asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <param name="version">Version of the dragon API.</param>
        /// <returns>A list of objects representing maps.</returns>
        Task<List<MapStatic>> GetMapsAsync(Region region, Language language = Language.en_US,
            string version = "");

        /// <summary>
        /// Get a list of all masteries asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="masteryData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>An MasteryListStatic object containing all masteries.</returns>
        Task<MasteryListStatic> GetMasteriesAsync(Region region,
            MasteryData masteryData = MasteryData.All, Language language = Language.en_US);

        /// <summary>
        /// Get a mastery asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="masteryId">Id of the mastery to retrieve.</param>
        /// <param name="masteryData">Data to retrieve.</param>
        /// <param name="language">Language of th data to be retrieved.</param>
        /// <returns>A mastery.</returns>
        Task<MasteryStatic> GetMasteryAsync(Region region, int masteryId,
            MasteryData masteryData = MasteryData.All, Language language = Language.en_US);

        /// <summary>
        /// Get a list of profile icons asynchronously
        /// </summary>
        /// <param name="region">Region corresponding to data to retrieve.</param>
        /// <param name="language">>Language of the data to be retrieved.</param>
        /// <returns>A ProfileIconListStatic object containing all runes.</returns>
        Task<ProfileIconListStatic> GetProfileIconsAsync(Region region, Language language = Language.en_US);

        /// <summary>
        /// Retrieve realm data asynchronously.
        /// </summary>
        /// <param name="region">Region corresponding to data to retrieve.</param>
        /// <returns>A realm object containing the requested information.</returns>
        Task<RealmStatic> GetRealmAsync(Region region);

        /// <summary>
        /// Get a list of all runes asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="runeData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A RuneListStatic object containing all runes.</returns>
        Task<RuneListStatic> GetRunesAsync(Region region, RuneData runeData = RuneData.All,
            Language language = Language.en_US);

        /// <summary>
        /// Get a rune asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="runeId">Id of the rune to retrieve.</param>
        /// <param name="runeData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A rune.</returns>
        Task<RuneStatic> GetRuneAsync(Region region, int runeId, RuneData runeData = RuneData.All,
           Language language = Language.en_US);

        /// <summary>
        /// Get a list of all summoner spells asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="summonerSpellData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A SummonerSpellListStatic object containing all summoner spells.</returns>
        Task<SummonerSpellListStatic> GetSummonerSpellsAsync(Region region,
            SummonerSpellData summonerSpellData = SummonerSpellData.All, Language language = Language.en_US);

        /// <summary>
        /// Get a summoner spell asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="summonerSpell">Summoner spell to retrieve.</param>
        /// <param name="summonerSpellData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A summoner spell.</returns>
        Task<SummonerSpellStatic> GetSummonerSpellAsync(Region region, int summonerSpellId,
            SummonerSpellData summonerSpellData = SummonerSpellData.All, Language language = Language.en_US);

        /// <summary>
        /// Retrieve static api version data asynchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve data.</param>
        /// <returns>A list of versions as strings.</returns>
        Task<List<string>> GetVersionsAsync(Region region);
    }
}
