using Newtonsoft.Json;
using System.Collections.Generic;

namespace RiotSharp.StaticDataEndpoint.ProfileIcons
{
    public class ProfileIconListStatic
    {
        [JsonProperty("data")]
        public Dictionary<string, ProfileIconStatic> ProfileIcons { get; set; }
    }
}
