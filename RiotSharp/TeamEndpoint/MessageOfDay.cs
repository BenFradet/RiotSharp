// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageOfDay.cs" company="">
//
// </copyright>
// <summary>
//   Message of the day of the team (Team API).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace RiotSharp.TeamEndpoint
{
    /// <summary>
    /// Message of the day of the team (Team API).
    /// </summary>
    [Serializable]
    public class MessageOfDay
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageOfDay"/> class.
        /// </summary>
        internal MessageOfDay() { }

        /// <summary>
        /// Date of the message creation.
        /// </summary>
        [JsonProperty("createDate")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Version of the message.
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }
    }
}
