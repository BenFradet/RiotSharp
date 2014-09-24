namespace RiotSharp.MatchEndpoint
{
    /// <summary>
    /// Event's type (Match API).
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// Ascended event.
        /// </summary>
        AscendedEvent,

        /// <summary>
        /// Triggers on building kills.
        /// </summary>
        BuildingKill,

        /// <summary>
        /// Triggers on captured point in dominion games.
        /// </summary>
        CapturePoint,

        /// <summary>
        /// Triggers on champion kills.
        /// </summary>
        ChampionKill,

        /// <summary>
        /// Triggers on Nashor or Dragon kills.
        /// </summary>
        EliteMonsterKill,

        /// <summary>
        /// Triggers on item destructions.
        /// </summary>
        ItemDestroyed,

        /// <summary>
        /// Triggers on item purchases.
        /// </summary>
        ItemPurchased,

        /// <summary>
        /// Triggers on item sells.
        /// </summary>
        ItemSold,

        /// <summary>
        /// Triggers on undo item purchases.
        /// </summary>
        ItemUndo,

        /// <summary>
        /// Triggers on skill level ups.
        /// </summary>
        SkillLevelUp,

        /// <summary>
        /// Triggers on ward kills.
        /// </summary>
        WardKill,

        /// <summary>
        /// Triggers on ward placements.
        /// </summary>
        WardPlaced
    }

    static class EventTypeExtension
    {
        public static string ToCustomString(this EventType eventType)
        {
            switch (eventType)
            {
                case EventType.AscendedEvent:
                    return "ASCENDED_EVENT";
                case EventType.BuildingKill:
                    return "BUILDING_KILL";
                case EventType.CapturePoint:
                    return "CAPTURE_POINT";
                case EventType.ChampionKill:
                    return "CHAMPION_KILL";
                case EventType.EliteMonsterKill:
                    return "ELITE_MONSTER_KILL";
                case EventType.ItemDestroyed:
                    return "ITEM_DESTROYED";
                case EventType.ItemPurchased:
                    return "ITEM_PURCHASED";
                case EventType.ItemSold:
                    return "ITEM_SOLD";
                case EventType.ItemUndo:
                    return "ITEM_UNDO";
                case EventType.SkillLevelUp:
                    return "SKILL_LEVEL_UP";
                case EventType.WardKill:
                    return "WARD_KILL";
                case EventType.WardPlaced:
                    return "WARD_PLACED";
                default:
                    return string.Empty;
            }
        }
    }
}
