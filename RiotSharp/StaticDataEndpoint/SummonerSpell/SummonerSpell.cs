namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Enum representing the different summon spells.
    /// </summary>
    public enum SummonerSpell
    {
        /// <summary>
        /// Barrier.
        /// </summary>
        Barrier = 21,

        /// <summary>
        /// Cleanse.
        /// </summary>
        Cleanse = 1,

        /// <summary>
        /// Clairvoyance.
        /// </summary>
        Clairvoyance = 2,

        /// <summary>
        /// Ignite.
        /// </summary>
        Ignite = 14,

        /// <summary>
        /// Exhaust.
        /// </summary>
        Exhaust = 3,

        /// <summary>
        /// Flash.
        /// </summary>
        Flash = 4,

        /// <summary>
        /// Ghost.
        /// </summary>
        Ghost = 6,

        /// <summary>
        /// Heal.
        /// </summary>
        Heal = 7,

        /// <summary>
        /// Clarity.
        /// </summary>
        Clarity = 13,

        /// <summary>
        /// Garrison.
        /// </summary>
        Garrison = 17,

        /// <summary>
        /// Revive.
        /// </summary>
        Revive = 10,

        /// <summary>
        /// Smite.
        /// </summary>
        Smite = 11,

        /// <summary>
        /// Teleport.
        /// </summary>
        Teleport = 12
    }

    static class SummonerSpellExtension
    {
        public static string ToCustomString(this SummonerSpell spell)
        {
            string transformedString;
            switch (spell)
            {
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
                default:
                    transformedString = spell.ToString();
                    break;
            }
            return "Summoner" + transformedString;
        }
    }
}
