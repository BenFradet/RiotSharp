using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RiotSharp.Endpoints.ClientEndpoint.Enums
{
    /// <summary>
    ///     Represents the outcome of a game from the view of the <see cref="ActivePlayer.ActivePlayer" />.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GameResultType
    {
        /// <summary>
        ///     Represents a game that has been won by the team of the <see cref="ActivePlayer.ActivePlayer" />.
        /// </summary>
        [EnumMember(Value = "Win")]
        Win,

        /// <summary>
        ///     Represents a game that has been lost by the team of the <see cref="ActivePlayer.ActivePlayer" />.
        /// </summary>
        [EnumMember(Value = "Lose")]
        Lose
    }
}