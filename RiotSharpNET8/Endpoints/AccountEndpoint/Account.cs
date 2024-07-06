using System.Text.Json.Serialization;

namespace RiotSharpNET8.Endpoints.AccountEndpoint
{
    /// <summary>
    /// Class representing an account.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Encrypted PUUID. Exact length of 78 characters.
        /// </summary>
        [JsonPropertyName("puuid")]
        public string Puuid { get; set; }

        /// <summary>
        /// GameName of account.
        /// </summary>
        /// <remarks>
        /// This field may be excluded if the account doesn't have a gameName.
        /// </remarks>
        [JsonPropertyName("gameName")]
        public string GameName { get; set; }

        /// <summary>
        /// TagLine of account.
        /// </summary>
        /// <remarks>
        /// This field may be excluded if the account doesn't have a tagLine.
        /// </remarks>
        [JsonPropertyName("tagLine")]
        public string TagLine { get; set; }
    }
}
