using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ReforgedRune.Cache
{
    class ReforgedRuneStaticWrapper
    {
        public int Id { get; set; }
        public Language Language { get; set; }
        public string Version { get; set; }

        public ReforgedRuneStatic ReforgedRune { get; set; }

        public ReforgedRuneStaticWrapper(int id, Language language, string version, ReforgedRuneStatic reforgedRune)
        {
            Id = id;
            Language = language;
            Version = version;
            ReforgedRune = reforgedRune;
        }

        public bool Validate(int id, Language language, string version)
        {
            return Id == id && Language == language && Version == version;
        }
    }
}
