using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    /// <summary>
    /// Enum representing the different summon spells.
    /// </summary>
    public enum SummonerSpell
    {
        /// <summary>
        /// Barrier.
        /// </summary>
        Barrier,
        /// <summary>
        /// Surge.
        /// </summary>
        Surge,
        /// <summary>
        /// Cleanse.
        /// </summary>
        Cleanse,
        /// <summary>
        /// Clairvoyance.
        /// </summary>
        Clairvoyance,
        /// <summary>
        /// Ignite.
        /// </summary>
        Ignite,
        /// <summary>
        /// Exhaust.
        /// </summary>
        Exhaust,
        /// <summary>
        /// Flash.
        /// </summary>
        Flash,
        /// <summary>
        /// Fortify.
        /// </summary>
        Fortify,
        /// <summary>
        /// Ghost.
        /// </summary>
        Ghost,
        /// <summary>
        /// Heal.
        /// </summary>
        Heal,
        /// <summary>
        /// Clarity.
        /// </summary>
        Clarity,
        /// <summary>
        /// Garrison.
        /// </summary>
        Garrison,
        /// <summary>
        /// Promote
        /// </summary>
        Promote,
        /// <summary>
        /// Rally.
        /// </summary>
        Rally,
        /// <summary>
        /// Revive.
        /// </summary>
        Revive,
        /// <summary>
        /// Smite.
        /// </summary>
        Smite,
        /// <summary>
        /// Teleport.
        /// </summary>
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
