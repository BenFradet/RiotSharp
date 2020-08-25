using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RiotSharp.Endpoints.ClientEndpoint.Enums
{
    /// <summary>
    ///     Represents the used resource of a champion.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ResourceType
    {
        /// <summary>
        ///     Represents no resource.
        /// </summary>
        [EnumMember(Value = "NONE")]
        None,

        /// <summary>
        ///     Represents mana.
        /// </summary>
        [EnumMember(Value = "MANA")]
        Mana,

        /// <summary>
        ///     Represents energy.
        /// </summary>
        [EnumMember(Value = "ENERGY")]
        Energy,

        /// <summary>
        ///     Represents shield.
        /// </summary>
        [EnumMember(Value = "SHIELD")]
        Shield,

        /// <summary>
        ///     Represents battle fury.
        /// </summary>
        [EnumMember(Value = "BATTLEFURY")]
        BattleFury,

        /// <summary>
        ///     Represents dragon fury.
        /// </summary>
        [EnumMember(Value = "DRAGONFURY")]
        DragonFury,

        /// <summary>
        ///     Represents rage.
        /// </summary>
        [EnumMember(Value = "RAGE")]
        Rage,

        /// <summary>
        ///     Represents heat.
        /// </summary>
        [EnumMember(Value = "HEAT")]
        Heat,

        /// <summary>
        ///     Represents gnar fury.
        /// </summary>
        [EnumMember(Value = "GNARFURY")]
        GnarFury,

        /// <summary>
        ///     Represents ferocity.
        /// </summary>
        [EnumMember(Value = "FEROCITY")]
        Ferocity,

        /// <summary>
        ///     Represents blood well.
        /// </summary>
        [EnumMember(Value = "BLOODWELL")]
        BloodWell,

        /// <summary>
        ///     Represents wind.
        /// </summary>
        [EnumMember(Value = "WIND")]
        Wind,

        /// <summary>
        ///     Represents ammo.
        /// </summary>
        [EnumMember(Value = "AMMO")]
        Ammo,

        /// <summary>
        ///     Represents other resources.
        /// </summary>
        [EnumMember(Value = "OTHER")]
        Other,

        /// <summary>
        ///     Represents max.
        /// </summary>
        [EnumMember(Value = "MAX")]
        Max
    }
}