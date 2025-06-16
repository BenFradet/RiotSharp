using Newtonsoft.Json;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ProfileIcons
{
    public class ProfileIconStatic
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image")]
        public ImageStatic Image { get; set; }
    }
}
