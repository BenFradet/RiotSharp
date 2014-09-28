// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataRequested.cs" company="">
//   
// </copyright>
// <summary>
//   Enum when requesting data for the Champion Static API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Enum when requesting data for the Champion Static API.
    /// </summary>
    public enum ChampionData
    {
        /// <summary>
        /// The none.
        /// </summary>
        none, 

        /// <summary>
        /// The all.
        /// </summary>
        all, 

        /// <summary>
        /// The image.
        /// </summary>
        image, 

        /// <summary>
        /// The skins.
        /// </summary>
        skins, 

        /// <summary>
        /// The lore.
        /// </summary>
        lore, 

        /// <summary>
        /// The blurb.
        /// </summary>
        blurb, 

        /// <summary>
        /// The allytips.
        /// </summary>
        allytips, 

        /// <summary>
        /// The enemytips.
        /// </summary>
        enemytips, 

        /// <summary>
        /// The tags.
        /// </summary>
        tags, 

        /// <summary>
        /// The partype.
        /// </summary>
        partype, 

        /// <summary>
        /// The info.
        /// </summary>
        info, 

        /// <summary>
        /// The stats.
        /// </summary>
        stats, 

        /// <summary>
        /// The spells.
        /// </summary>
        spells, 

        /// <summary>
        /// The passive.
        /// </summary>
        passive, 

        /// <summary>
        /// The recommended.
        /// </summary>
        recommended
    }

    /// <summary>
    /// Enum when requesting data for the Item Static API.
    /// </summary>
    public enum ItemData
    {
        /// <summary>
        /// The none.
        /// </summary>
        none, 

        /// <summary>
        /// The all.
        /// </summary>
        all, 

        /// <summary>
        /// The description.
        /// </summary>
        description, 

        /// <summary>
        /// The colloq.
        /// </summary>
        colloq, 

        /// <summary>
        /// The into.
        /// </summary>
        into, 

        /// <summary>
        /// The image.
        /// </summary>
        image, 

        /// <summary>
        /// The gold.
        /// </summary>
        gold, 

        /// <summary>
        /// The tags.
        /// </summary>
        tags, 

        /// <summary>
        /// The stats.
        /// </summary>
        stats
    }

    /// <summary>
    /// Enum when requesting data for the Mastery Static API.
    /// </summary>
    public enum MasteryData
    {
        /// <summary>
        /// The none.
        /// </summary>
        none, 

        /// <summary>
        /// The all.
        /// </summary>
        all, 

        /// <summary>
        /// The ranks.
        /// </summary>
        ranks, 

        /// <summary>
        /// The prereq.
        /// </summary>
        prereq, 

        /// <summary>
        /// The image.
        /// </summary>
        image
    }

    /// <summary>
    /// Enum when requesting data for the Rune Static API.
    /// </summary>
    public enum RuneData
    {
        /// <summary>
        /// The none.
        /// </summary>
        none, 

        /// <summary>
        /// The all.
        /// </summary>
        all, 

        /// <summary>
        /// The image.
        /// </summary>
        image, 

        /// <summary>
        /// The stats.
        /// </summary>
        stats, 

        /// <summary>
        /// The tags.
        /// </summary>
        tags, 

        /// <summary>
        /// The colloq.
        /// </summary>
        colloq, 

        /// <summary>
        /// The plaintext.
        /// </summary>
        plaintext
    }

    /// <summary>
    /// Enum when requesting data for the SummonerSpell Static API.
    /// </summary>
    public enum SummonerSpellData
    {
        /// <summary>
        /// The none.
        /// </summary>
        none, 

        /// <summary>
        /// The all.
        /// </summary>
        all, 

        /// <summary>
        /// The key.
        /// </summary>
        key, 

        /// <summary>
        /// The image.
        /// </summary>
        image, 

        /// <summary>
        /// The tooltip.
        /// </summary>
        tooltip, 

        /// <summary>
        /// The resource.
        /// </summary>
        resource, 

        /// <summary>
        /// The maxrank.
        /// </summary>
        maxrank, 

        /// <summary>
        /// The modes.
        /// </summary>
        modes, 

        /// <summary>
        /// The cost type.
        /// </summary>
        costType, 

        /// <summary>
        /// The cost.
        /// </summary>
        cost, 

        /// <summary>
        /// The cost burn.
        /// </summary>
        costBurn, 

        /// <summary>
        /// The range.
        /// </summary>
        range, 

        /// <summary>
        /// The range burn.
        /// </summary>
        rangeBurn, 

        /// <summary>
        /// The effect.
        /// </summary>
        effect, 

        /// <summary>
        /// The effect burn.
        /// </summary>
        effectBurn, 

        /// <summary>
        /// The cooldown.
        /// </summary>
        cooldown, 

        /// <summary>
        /// The cooldown burn.
        /// </summary>
        cooldownBurn, 

        /// <summary>
        /// The vars.
        /// </summary>
        vars
    }
}
