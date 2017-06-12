using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.AspNetCore
{
    public class TournamentApiKeyOptions : ApiKeyOptions
    {
        internal TournamentApiKeyOptions() { }

        public bool UseStub { get; set; }
    }
}
