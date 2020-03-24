using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ProfileIcons
{
    /// <summary>
    /// The profile icons
    /// </summary>
    public class ProfileIconListStatic
    {
        /// <summary>
        /// A dictionary of profile icons
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<string, ProfileIconStatic> ProfileIcons { get; set; }
    }
}
