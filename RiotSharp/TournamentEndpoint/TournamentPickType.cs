using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.TournamentEndpoint
{
    /// <summary>
    /// Pick type of the game (Tournament API).
    /// </summary>
    public enum TournamentPickType
    {
        BlindPick,
        DraftMode,
        AllRandom,
        TournamentDraft
    }
}
