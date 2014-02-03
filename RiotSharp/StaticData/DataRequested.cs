using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
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

    public enum MasteryData
    {
        none,
        all,
        ranks,
        prereq,
        image
    }
}
