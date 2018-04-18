namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticDataEndpoints
    {
        IStaticChampionEndpoint Champion { get; }
        IStaticItemEndpoint Item { get; }
        IStaticLanguageEndpoint Language { get; }
        IStaticMapEndpoint Map { get; }
        IStaticMasteryEndpoint Mastery { get; }
        IStaticProfileIconEndpoint ProfileIcon { get; }
        IStaticRealmEndpoint Realm { get; }
        IStaticReforgedRuneEndpoint ReforgedRune { get; }
        IStaticRuneEndpoint Rune { get; }
        IStaticSummonerSpellEndpoint SummonerSpell { get; }
        IStaticVersionEndpoint Version { get; }
        IStaticTarballLinkEndPoint TarballLink { get; }
    }
}