using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    /// <summary>
    /// Type of the game (Game API).
    /// </summary>
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
}
