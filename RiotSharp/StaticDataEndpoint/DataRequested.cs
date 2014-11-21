namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Enum when requesting data for the Champion Static API.
    /// </summary>
    public enum ChampionData
    {
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
