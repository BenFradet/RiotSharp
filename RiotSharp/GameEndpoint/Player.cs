﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Player.cs" company="">
//
// </copyright>
// <summary>
//   Player in the game (Game API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.GameEndpoint
{
    /// <summary>
    /// Player in the game (Game API).
    /// </summary>
    [Serializable]
    public class Player
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        internal Player() { }

        /// <summary>
        /// Champion id associated with player.
        /// </summary>
        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        /// <summary>
        /// Summoner id associated with player.
        /// </summary>
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        /// <summary>
        /// Team id associated with player.
        /// <para>Blue = 100</para>
        /// <para>Purple = 200</para>
        /// </summary>
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
    }
}
