namespace RiotSharp.Endpoints.Interfaces.Static
{
    /// <summary>
    /// The interface containing all Data Dragon endpoints
    /// </summary>
    public interface IDataDragonEndpoints
    {
        /// <summary>
        /// The static Champion Endpoint
        /// </summary>
        IStaticChampionEndpoint Champions { get; }

        /// <summary>
        /// The static Item Endpoint
        /// </summary>
        IStaticItemEndpoint Items { get; }

        /// <summary>
        /// The static Language Endpoint
        /// </summary>
        IStaticLanguageEndpoint Languages { get; }

        /// <summary>
        /// The static Map Endpoint
        /// </summary>
        IStaticMapEndpoint Maps { get; }

        /// <summary>
        /// The static Mastery Endpoint
        /// </summary>
        IStaticMasteryEndpoint Masteries { get; }

        /// <summary>
        /// The static ProfileIcon Endpoint
        /// </summary>
        IStaticProfileIconEndpoint ProfileIcons { get; }

        /// <summary>
        /// The static Realm Endpoint
        /// </summary>
        IStaticRealmEndpoint Realms { get; }

        /// <summary>
        /// The static ReforgedRune Endpoint
        /// </summary>
        IStaticReforgedRuneEndpoint ReforgedRunes { get; }

        /// <summary>
        /// The static Rune Endpoint
        /// </summary>
        IStaticRuneEndpoint Runes { get; }

        /// <summary>
        /// The static SummonerSpell Endpoint
        /// </summary>
        IStaticSummonerSpellEndpoint SummonerSpells { get; }

        /// <summary>
        /// The static Version Endpoint
        /// </summary>
        IStaticVersionEndpoint Versions { get; }

        /// <summary>
        /// The static TarballLink Endpoint
        /// </summary>
        IStaticTarballLinkEndPoint TarballLinks { get; }
    }
}
