using Newtonsoft.Json;

namespace RiotSharp.Endpoints.SpectatorEndpoint
{
    /// <summary>
    /// Class representing an Observer in the API.
    /// </summary>
    public class Observer
    {
        /// <summary>
        /// Key required to pass to the LoL client to spectate a game. (Key used to decrypt the spectator grid game data for playback)
        /// </summary>
        [JsonProperty("encryptionKey")]
        public string EncryptionKey { get; set; }
    }
}
