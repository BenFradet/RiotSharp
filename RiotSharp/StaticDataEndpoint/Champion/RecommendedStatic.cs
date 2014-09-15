using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing a recommended item for a champion (Static API).
    /// </summary>
    [Serializable]
    public class RecommendedStatic
    {
        internal RecommendedStatic() { }

        /// <summary>
        /// List of recommended items ordered by block.
        /// </summary>
        [JsonProperty("blocks")]
        public List<BlockStatic> Blocks { get; set; }

        /// <summary>
        /// Name of the champion for which those items are recommended.
        /// </summary>
        [JsonProperty("champion")]
        public string Champion { get; set; }

        /// <summary>
        /// Map id for which those items are recommended.
        /// <list type="table">
        /// <listheader><description>Possible values:</description></listheader>
        /// <item><term>1</term><description>Summoner's Rift: Summer Variant</description></item>
        /// <item><term>2</term><description>Summoner's Rift: Autumn Variant</description></item>
        /// <item><term>3</term><description>The Proving Grounds: Tutorial Map</description></item>
        /// <item><term>4</term><description>Twisted Treeline: Original Version</description></item>
        /// <item><term>8</term><description>The Crystal Scar: Dominion Map</description></item>
        /// <item><term>10</term><description>Twisted Treeline: Current Version</description></item>
        /// <item><term>12</term><description>Howling Abyss: ARAM Map</description></item>
        /// </list>
        /// </summary>
        [JsonProperty("map")]
        public string Map { get; set; }

        /// <summary>
        /// Mode for which those items are recommended.
        /// </summary>
        [JsonProperty("mode")]
        [JsonConverter(typeof(GameModeConverter))]
        public GameMode Mode { get; set; }

        /// <summary>
        /// Priority of the recommended items list.
        /// <para>This is default false for each Riot page.
        /// This means players' lists will normally display when a game starts instead of Riots' pages.</para>
        /// </summary>
        [JsonProperty("priority")]
        public bool Priority { get; set; }

        /// <summary>
        /// Title of the items list.
        /// <para>(eg: Beginner / riot-beginner / VladimirHA / VladimirDM / ...)</para>
        /// <para>Later if costum sets are server side, we might be able to request these too.</para>
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Type of list.
        /// <para>(eg: riot-beginner / riot)</para>
        /// <para>This is probably to find out who's list it is. (Riot's' or a players')</para>
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
