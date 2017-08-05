namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Enum when requesting data for the Champion Static API.
    /// </summary>
    public enum ChampionData
    {
        /// <summary>
        /// The default. Resolves to type, version, data, id, key, name, and title
        /// </summary>
        Basic,

        All,
        Image,
        Skins,
        Lore,
        Blurb,
        Allytips,
        Enemytips,
        Tags,
        Partype,
        Info,
        Stats,
        Spells,
        Passive,
        Recommended
    }

    /// <summary>
    /// Enum when requesting data for the Item Static API.
    /// </summary>
    public enum ItemData
    {
        /// <summary>
        /// The default. Resolves to type, version, basic, data, id, name, plaintext, group, and description
        /// </summary>
        Basic,

        All,
        Description,
        Colloq,
        Into,
        Image,
        Gold,
        Tags,
        Stats
    }

    /// <summary>
    /// Enum when requesting data for the Mastery Static API.
    /// </summary>
    public enum MasteryData
    {
        /// <summary>
        /// The default. Resolves to type, version, data, id, name, and description
        /// </summary>
        Basic,

        All,
        Ranks,
        Prereq,
        Image
    }

    /// <summary>
    /// Enum when requesting data for the Rune Static API.
    /// </summary>
    public enum RuneData
    {
        /// <summary>
        /// The default. Resolves to type, version, data, id, name, rune, and description
        /// </summary>
        Basic,

        All,
        Image,
        Stats,
        Tags,
        Colloq,
        Plaintext
    }

    /// <summary>
    /// Enum when requesting data for the SummonerSpell Static API.
    /// </summary>
    public enum SummonerSpellData
    {
        /// <summary>
        /// The default. Resolves to type, version, data, id, key, name, description, and summonerLevel
        /// </summary>
        Basic,

        All,
        Key,
        Image,
        Tooltip,
        Resource,
        Maxrank,
        Modes,
        CostType,
        Cost,
        CostBurn,
        Range,
        RangeBurn,
        Effect,
        EffectBurn,
        Cooldown,
        CooldownBurn,
        Vars
    }
}
