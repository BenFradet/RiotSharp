﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotSharp
{
    /// <summary>
    /// Class representing a champion (Static API).
    /// </summary>
    [Serializable]
    public class ChampionStatic
    {
        internal ChampionStatic() { }

        /// <summary>
        /// List of tips to use while playing this champion.
        /// </summary>
        [JsonProperty("allytips")]
        public List<string> AllyTips { get; set; }

        /// <summary>
        /// Beginning of the lore.
        /// </summary>
        [JsonProperty("blurb")]
        public string Blurb { get; set; }

        /// <summary>
        /// LIst of tips to use while playing against this champion.
        /// </summary>
        [JsonProperty("enemytips")]
        public List<string> EnemyTips { get; set; }

        /// <summary>
        /// Name of this champion.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Image of this champion.
        /// </summary>
        [JsonProperty("image")]
        public ImageStatic Image { get; set; }

        /// <summary>
        /// A few statistics about this champion (attack, defense, magic, difficulty).
        /// </summary>
        [JsonProperty("info")]
        public InfoStatic Info { get; set; }

        /// <summary>
        /// Id of this champion.
        /// </summary>
        [JsonProperty("key")]
        public int Key { get; set; }

        /// <summary>
        /// Lore of this champion.
        /// </summary>
        [JsonProperty("lore")]
        public string Lore { get; set; }

        /// <summary>
        /// Name of this champion.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Type of the champion (Mana, None, Energy, Shield, Rage, Ferocity, Heat, Dragonfury, Battlefury, Wind).
        /// </summary>
        [JsonProperty("partype")]
        [JsonConverter(typeof(ParTypeStaticConverter))]
        public ParTypeStatic Partype { get; set; }

        /// <summary>
        /// Information about this champion's passive.
        /// </summary>
        [JsonProperty("passive")]
        public PassiveStatic Passive { get; set; }

        /// <summary>
        /// List of recommended items for this champion.
        /// </summary>
        [JsonProperty("recommended")]
        public List<RecommendedStatic> RecommendedItems { get; set; }

        /// <summary>
        /// List of skins for this champion.
        /// </summary>
        [JsonProperty("skins")]
        public List<SkinStatic> Skins { get; set; }

        /// <summary>
        /// List of spells for this champion.
        /// </summary>
        [JsonProperty("spells")]
        public List<SpellStatic> Spells { get; set; }

        /// <summary>
        /// Stats of this champions.
        /// </summary>
        [JsonProperty("stats")]
        public ChampionStatsStatic Stats { get; set; }

        /// <summary>
        /// List of tags for this champion (Mage, Assassin, Tank, Support, etc).
        /// </summary>
        [JsonProperty("tags")]
        [JsonConverter(typeof(TagStaticConverter))]
        public List<TagStatic> Tags { get; set; }

        /// <summary>
        /// Title of this champion.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
