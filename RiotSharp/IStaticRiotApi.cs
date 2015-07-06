using RiotSharp.StaticDataEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    public interface IStaticRiotApi
    {
        ChampionListStatic GetChampions(Region region, ChampionData championData = ChampionData.none,
            Language language = Language.en_US);
        Task<ChampionListStatic> GetChampionsAsync(Region region,
            ChampionData championData = ChampionData.none, Language language = Language.en_US);
        ChampionStatic GetChampion(Region region, int championId,
            ChampionData championData = ChampionData.none, Language language = Language.en_US);
        Task<ChampionStatic> GetChampionAsync(Region region, int championId,
            ChampionData championData = ChampionData.none, Language language = Language.en_US);
        ItemListStatic GetItems(Region region, ItemData itemData = ItemData.none,
            Language language = Language.en_US);
        Task<ItemListStatic> GetItemsAsync(Region region, ItemData itemData = ItemData.none,
            Language language = Language.en_US);
        ItemStatic GetItem(Region region, int itemId, ItemData itemData = ItemData.none,
            Language language = Language.en_US);
        Task<ItemStatic> GetItemAsync(Region region, int itemId, ItemData itemData = ItemData.none,
            Language language = Language.en_US);
        LanguageStringsData GetLanguageStrings(Region region, Language language = Language.en_US,
            string version = "5.3.1");
        Task<LanguageStringsData> GetLanguageStringsAsync(Region region,
            Language language = Language.en_US, string version = "5.3.1");
        List<Language> GetLanguages(Region region);
        Task<List<Language>> GetLanguagesAsync(Region region);
        List<MapStatic> GetMaps(Region region, Language language = Language.en_US, string version = "5.3.1");
        Task<List<MapStatic>> GetMapsAsync(Region region, Language language = Language.en_US,
            string version = "5.3.1");
        MasteryListStatic GetMasteries(Region region, MasteryData masteryData = MasteryData.none,
            Language language = Language.en_US);
        Task<MasteryListStatic> GetMasteriesAsync(Region region,
            MasteryData masteryData = MasteryData.none, Language language = Language.en_US);
        MasteryStatic GetMastery(Region region, int masteryId, MasteryData masteryData = MasteryData.none,
            Language language = Language.en_US);
        Task<MasteryStatic> GetMasteryAsync(Region region, int masteryId,
            MasteryData masteryData = MasteryData.none, Language language = Language.en_US);
        Realm GetRealm(Region region);
        Task<Realm> GetRealmAsync(Region region);
        RuneListStatic GetRunes(Region region, RuneData runeData = RuneData.none
            , Language language = Language.en_US);
        Task<RuneListStatic> GetRunesAsync(Region region, RuneData runeData = RuneData.none,
            Language language = Language.en_US);
        RuneStatic GetRune(Region region, int runeId, RuneData runeData = RuneData.none,
            Language language = Language.en_US);
        Task<RuneStatic> GetRuneAsync(Region region, int runeId, RuneData runeData = RuneData.none,
           Language language = Language.en_US);
        SummonerSpellListStatic GetSummonerSpells(Region region,
            SummonerSpellData summonerSpellData = SummonerSpellData.none, Language language = Language.en_US);
        Task<SummonerSpellListStatic> GetSummonerSpellsAsync(Region region,
            SummonerSpellData summonerSpellData = SummonerSpellData.none, Language language = Language.en_US);
        SummonerSpellStatic GetSummonerSpell(Region region, SummonerSpell summonerSpell,
            SummonerSpellData summonerSpellData = SummonerSpellData.none, Language language = Language.en_US);
        Task<SummonerSpellStatic> GetSummonerSpellAsync(Region region, SummonerSpell summonerSpell,
            SummonerSpellData summonerSpellData = SummonerSpellData.none, Language language = Language.en_US);
        List<string> GetVersions(Region region);
        Task<List<string>> GetVersionsAsync(Region region);
    }
}
