using Newtonsoft.Json;

namespace RiotSharp.Endpoints.AccountEndpoint
{
    /// <summary>
    /// Class representing an account.
    /// </summary>
    public class Account
    {
        internal Account() { }

        /// <summary>
        /// Encrypted PUUID. Exact length of 78 characters.
        /// </summary>
        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        /// <summary>
        /// GameName of account.
        /// </summary>
        /// <remarks>
        /// This field may be excluded if the account doesn't have a gameName.
        /// </remarks>
        [JsonProperty("gameName")]
        public string GameName { get; set; }

        /// <summary>
        /// TagLine of account.
        /// </summary>
        /// <remarks>
        /// This field may be excluded if the account doesn't have a tagLine.
        /// </remarks>
        [JsonProperty("tagLine")]
        public string TagLine { get; set; }
    }
}
