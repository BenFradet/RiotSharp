namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticDataEndpoints
    {
        IStaticChampionEndpoint Champions { get; }
        IStaticItemEndpoint Items { get; }
        IStaticLanguageEndpoint Languages { get; }
        IStaticMapEndpoint Maps { get; }
        IStaticMasteryEndpoint Masteries { get; }
        IStaticProfileIconEndpoint ProfileIcons { get; }
        IStaticRealmEndpoint Realms { get; }
        IStaticReforgedRuneEndpoint ReforgedRunes { get; }
        IStaticRuneEndpoint Runes { get; }
        IStaticSummonerSpellEndpoint SummonerSpells { get; }
        IStaticVersionEndpoint Versions { get; }
        IStaticTarballLinkEndPoint TarballLinks { get; }
    }
}