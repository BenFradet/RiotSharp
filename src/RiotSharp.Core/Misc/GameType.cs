using System.Text.Json.Serialization;
using RiotSharp.Core.Misc.Converters;

namespace RiotSharp.Core.Misc
{
    /// <summary>
    /// Type of the game.
    /// </summary>
    [JsonConverter(typeof(GameTypeConverter))]
    public enum GameType
    {
        /// <summary>
        /// Custom games.
        /// </summary>
        CustomGame,

        /// <summary>
        /// Neither tutorial nor custom games
        /// </summary>
        MatchedGame,

        /// <summary>
        /// Tutorial games.
        /// </summary>
        TutorialGame
    }

    public static class GameTypeExtension
	{
		public static string ToCustomString(this GameType gameType)
		{
			return gameType switch
			{
				GameType.CustomGame => "CUSTOM_GAME",
				GameType.MatchedGame => "MATCHED_GAME",
				GameType.TutorialGame => "TUTORIAL_GAME",
				_ => ""
			};
		}
	}

}
