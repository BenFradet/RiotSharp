using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ProfileIcons
{
    public class ProfileIconListStatic
    {
        [JsonProperty("data")]
        public Dictionary<string, ProfileIconStatic> ProfileIcons { get; set; }
    }
}
