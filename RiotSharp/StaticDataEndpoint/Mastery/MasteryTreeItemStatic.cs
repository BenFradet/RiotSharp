﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MasteryTreeItemStatic.cs" company="">
//   
// </copyright>
// <summary>
//   Class representing a mastery tree item or talent (Static API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.StaticDataEndpoint
{
    /// <summary>
    /// Class representing a mastery tree item or talent (Static API).
    /// </summary>
    [Serializable]
    public class MasteryTreeItemStatic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasteryTreeItemStatic"/> class.
        /// </summary>
        internal MasteryTreeItemStatic() { }

        /// <summary>
        /// Id of the mastery.
        /// </summary>
        [JsonProperty("masteryId")]
        public int MasteryId { get; set; }

        /// <summary>
        /// Prerequisite.
        /// </summary>
        [JsonProperty("prereq")]
        public string Prerequisite { get; set; }
    }
}
