using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    public enum SummonerSpell
    {
        Barrier,
        Surge,
        Cleanse,
        Clairvoyance,
        Ignite,
        Exhaust,
        Flash,
        Fortify,
        Ghost,
        Heal,
        Clarity,
        Garrison,
        Promote,
        Rally,
        Revive,
        Smite,
        Teleport
    }

    static class SummonerSpellExtension
    {
        public static string ToCustomString(this SummonerSpell spell)
        {
            string transformedString;
            switch (spell)
            {
                case(SummonerSpell.Surge):
                    transformedString = "BattleCry";
                    break;
                case (SummonerSpell.Cleanse):
                    transformedString = "Boost";
                    break;
                case (SummonerSpell.Ignite):
                    transformedString = "Dot";
                    break;
                case(SummonerSpell.Ghost):
                    transformedString = "Haste";
                    break;
                case(SummonerSpell.Clarity):
                    transformedString = "Mana";
                    break;
                case (SummonerSpell.Garrison):
                    transformedString = "OdinGarrison";
                    break;
                case(SummonerSpell.Promote):
                    transformedString = "PromoteSR";
                    break;
                default:
                    transformedString = spell.ToString();
                    break;
            }
            return "Summoner" + transformedString;
        }
    }
}
