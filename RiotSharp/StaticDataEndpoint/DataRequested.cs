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
        none,

        all,
        image,
        skins,
        lore,
        blurb,
        allytips,
        enemytips,
        tags,
        partype,
        info,
        stats,
        spells,
        passive,
        recommended
    }

    /// <summary>
    /// Enum when requesting data for the Item Static API.
    /// </summary>
    public enum ItemData
    {
        /// <summary>
        /// The default. Resolves to type, version, basic, data, id, name, plaintext, group, and description
        /// </summary>
        none,

        all,
        description,
        colloq,
        into,
        image,
        gold,
        tags,
        stats
    }

    /// <summary>
    /// Enum when requesting data for the Mastery Static API.
    /// </summary>
    public enum MasteryData
    {
        /// <summary>
        /// The default. Resolves to type, version, data, id, name, and description
        /// </summary>
        none,

        all,
        ranks,
        prereq,
        image
    }

    /// <summary>
    /// Enum when requesting data for the Rune Static API.
    /// </summary>
    public enum RuneData
    {
        /// <summary>
        /// The default. Resolves to type, version, data, id, name, rune, and description
        /// </summary>
        none,

        all,
        image,
        stats,
        tags,
        colloq,
        plaintext
    }

    /// <summary>
    /// Enum when requesting data for the SummonerSpell Static API.
    /// </summary>
    public enum SummonerSpellData
    {
        /// <summary>
        /// The default. Resolves to type, version, data, id, key, name, description, and summonerLevel
        /// </summary>
        none,

        all,
        key,
        image,
        tooltip,
        resource,
        maxrank,
        modes,
        costType,
        cost,
        costBurn,
        range,
        rangeBurn,
        effect,
        effectBurn,
        cooldown,
        cooldownBurn,
        vars
    }
}
