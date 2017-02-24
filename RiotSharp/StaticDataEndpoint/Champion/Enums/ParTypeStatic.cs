using Newtonsoft.Json;
using RiotSharp.StaticDataEndpoint.Champion.Enums.Converters;

namespace RiotSharp.StaticDataEndpoint.Champion.Enums
{
    /// <summary>
    /// Enum representing a champion's resource.
    /// </summary>
    [JsonConverter(typeof(ParTypeStaticConverter))]
    public enum ParTypeStatic
    {
        /// <summary>
        /// BloodWell (Aatrox).
        /// </summary>
        BloodWell,

        /// <summary>
        /// Battlefury (Tryndamere).
        /// </summary>
        Battlefury,

        /// <summary>
        /// Dragonfury (Shyvana).
        /// </summary>
        Dragonfury,

        /// <summary>
        /// Energy (Shen, Kennen, etc).
        /// </summary>
        Energy,

        /// <summary>
        /// Ferocity (Rengar).
        /// </summary>
        Ferocity,

        /// <summary>
        /// Gnarfury (Gnar).
        /// </summary>
        Gnarfury,

        /// <summary>
        /// Heat (Rumble).
        /// </summary>
        Heat,

        /// <summary>
        /// Mana.
        /// </summary>
        Mana,

        /// <summary>
        /// MP (Poppy, Lux, Caitlyn, etc).
        /// </summary>
        MP,

        /// <summary>
        /// None (Zac, Mundo, etc).
        /// </summary>
        None,

        /// <summary>
        /// Rage (Renekton before rework).
        /// </summary>
        Rage,

        /// <summary>
        /// Shield (Mordekaiser).
        /// </summary>
        Shield,

        /// <summary>
        /// Wind (Yasuo before rework).
        /// </summary>
        Wind,

        /// <summary>
        /// Courage (Kled).
        /// </summary>
        Courage,

        /// <summary>
        /// Crimson Rush (Vladimir).
        /// </summary>
        CrimsonRush,

        /// <summary>
        /// Flow (Yasuo).
        /// </summary>
        Flow,

        /// <summary>
        /// Fury (Renekton).
        /// </summary>
        Fury,
    }
}
