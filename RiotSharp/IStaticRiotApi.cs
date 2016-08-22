using RiotSharp.StaticDataEndpoint;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp
{
    #pragma warning disable 1591
    public interface IStaticRiotApi
    {
        ChampionListStatic GetChampions(Region region, ChampionData championData = ChampionData.basic,
            Language language = Language.en_US);
        Task<ChampionListStatic> GetChampionsAsync(Region region,
            ChampionData championData = ChampionData.basic, Language language = Language.en_US);
        ChampionStatic GetChampion(Region region, int championId,
            ChampionData championData = ChampionData.basic, Language language = Language.en_US);
        Task<ChampionStatic> GetChampionAsync(Region region, int championId,
            ChampionData championData = ChampionData.basic, Language language = Language.en_US);
        ItemListStatic GetItems(Region region, ItemData itemData = ItemData.basic,
            Language language = Language.en_US);
        Task<ItemListStatic> GetItemsAsync(Region region, ItemData itemData = ItemData.basic,
            Language language = Language.en_US);
        ItemStatic GetItem(Region region, int itemId, ItemData itemData = ItemData.basic,
            Language language = Language.en_US);
        Task<ItemStatic> GetItemAsync(Region region, int itemId, ItemData itemData = ItemData.basic,
            Language language = Language.en_US);
        LanguageStringsStatic GetLanguageStrings(Region region, Language language = Language.en_US,
            string version = "");
        Task<LanguageStringsStatic> GetLanguageStringsAsync(Region region,
            Language language = Language.en_US, string version = "");
        List<Language> GetLanguages(Region region);
        Task<List<Language>> GetLanguagesAsync(Region region);
        List<MapStatic> GetMaps(Region region, Language language = Language.en_US, string version = "");
        Task<List<MapStatic>> GetMapsAsync(Region region, Language language = Language.en_US,
            string version = "");
        MasteryListStatic GetMasteries(Region region, MasteryData masteryData = MasteryData.basic,
            Language language = Language.en_US);
        Task<MasteryListStatic> GetMasteriesAsync(Region region,
            MasteryData masteryData = MasteryData.basic, Language language = Language.en_US);
        MasteryStatic GetMastery(Region region, int masteryId, MasteryData masteryData = MasteryData.basic,
            Language language = Language.en_US);
        Task<MasteryStatic> GetMasteryAsync(Region region, int masteryId,
            MasteryData masteryData = MasteryData.basic, Language language = Language.en_US);
        RealmStatic GetRealm(Region region);
        Task<RealmStatic> GetRealmAsync(Region region);
        RuneListStatic GetRunes(Region region, RuneData runeData = RuneData.basic
            , Language language = Language.en_US);
        Task<RuneListStatic> GetRunesAsync(Region region, RuneData runeData = RuneData.basic,
            Language language = Language.en_US);
        RuneStatic GetRune(Region region, int runeId, RuneData runeData = RuneData.basic,
            Language language = Language.en_US);
        Task<RuneStatic> GetRuneAsync(Region region, int runeId, RuneData runeData = RuneData.basic,
           Language language = Language.en_US);
        SummonerSpellListStatic GetSummonerSpells(Region region,
            SummonerSpellData summonerSpellData = SummonerSpellData.basic, Language language = Language.en_US);
        Task<SummonerSpellListStatic> GetSummonerSpellsAsync(Region region,
            SummonerSpellData summonerSpellData = SummonerSpellData.basic, Language language = Language.en_US);
        SummonerSpellStatic GetSummonerSpell(Region region, SummonerSpell summonerSpell,
            SummonerSpellData summonerSpellData = SummonerSpellData.basic, Language language = Language.en_US);
        Task<SummonerSpellStatic> GetSummonerSpellAsync(Region region, SummonerSpell summonerSpell,
            SummonerSpellData summonerSpellData = SummonerSpellData.basic, Language language = Language.en_US);
        List<string> GetVersions(Region region);
        Task<List<string>> GetVersionsAsync(Region region);
    }
    #pragma warning restore 1591
}
