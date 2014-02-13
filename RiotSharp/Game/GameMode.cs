using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp
{
    /// <summary>
    /// Mode of the game (Game API).
    /// </summary>
    public enum GameMode
    {
        /// <summary>
        /// Classic Summoner's Rift and Twisted Treeline games.
        /// </summary>
        Classic,

        /// <summary>
        /// Dominion/Crystal Scar games.
        /// </summary>
        Dominion,

        /// <summary>
        /// ARAM games.
        /// </summary>
        Aram,

        /// <summary>
        /// Tutorial games.
        /// </summary>
        Tutorial,

        /// <summary>
        /// One for All games.
        /// </summary>
        OneForAll,

        /// <summary>
        /// Snowdown Showdown games.
        /// </summary>
        FirstBlood
    }
}
