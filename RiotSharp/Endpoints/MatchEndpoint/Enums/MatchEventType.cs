using Newtonsoft.Json;
using RiotSharp.Endpoints.MatchEndpoint.Enums.Converters;

namespace RiotSharp.Endpoints.MatchEndpoint.Enums
{
    /// <summary>
    /// Event's type (Match API).
    /// </summary>
    [JsonConverter(typeof(MatchEventTypeConverter))]
    public enum MatchEventType
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
        public static string ToCustomString(this MatchEventType eventType)
        {
            switch (eventType)
            {
                case MatchEventType.AscendedEvent:
                    return "ASCENDED_EVENT";
                case MatchEventType.BuildingKill:
                    return "BUILDING_KILL";
                case MatchEventType.CapturePoint:
                    return "CAPTURE_POINT";
                case MatchEventType.ChampionKill:
                    return "CHAMPION_KILL";
                case MatchEventType.EliteMonsterKill:
                    return "ELITE_MONSTER_KILL";
                case MatchEventType.ItemDestroyed:
                    return "ITEM_DESTROYED";
                case MatchEventType.ItemPurchased:
                    return "ITEM_PURCHASED";
                case MatchEventType.ItemSold:
                    return "ITEM_SOLD";
                case MatchEventType.ItemUndo:
                    return "ITEM_UNDO";
                case MatchEventType.SkillLevelUp:
                    return "SKILL_LEVEL_UP";
                case MatchEventType.WardKill:
                    return "WARD_KILL";
                case MatchEventType.WardPlaced:
                    return "WARD_PLACED";
                default:
                    return string.Empty;
            }
        }
    }
}
