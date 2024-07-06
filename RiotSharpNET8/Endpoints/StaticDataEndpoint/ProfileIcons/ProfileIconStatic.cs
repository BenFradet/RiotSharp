using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.StaticDataEndpoint.ProfileIcons
{
    public class ProfileIconStatic
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("image")]
        public ImageStatic Image { get; set; }
    }
}
