using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.ProfileIcons
{
    /// <summary>
    /// The profile icons
    /// </summary>
    public class ProfileIconListStatic
    {
        /// <summary>
        /// A dictionary of profile icons
        /// </summary>
        [JsonPropertyName("data")]
        public Dictionary<string, ProfileIconStatic> ProfileIcons { get; set; }
    }
}
