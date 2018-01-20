using RiotSharp.Endpoints.Interfaces.Static;

namespace RiotSharp.Endpoints.Interfaces.Static
{
    public interface IStaticDataEndpoint
    {
        IStaticChampionEndpoint Champion { get; }
        IStaticItemEndpoint Item { get; }
        IStaticLanguageEndpoint Language { get; }
        IStaticMapEndpoint Map { get; }
        IStaticMasteryEndpoint Mastery { get; }
        IStaticProfileIconEndpoint ProfileIcon { get; }
        IStaticRealmEndpoint Realm { get; }
        IStaticRuneEndpoint Rune { get; }
        IStaticSummonerSpellEndpoint SummonerSpell { get; }
        IStaticVersionEndpoint Version { get; }
    }
}