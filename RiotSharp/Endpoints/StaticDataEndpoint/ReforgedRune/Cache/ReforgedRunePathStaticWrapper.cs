using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.StaticDataEndpoint.ReforgedRune.Cache
{
    class ReforgedRunePathStaticWrapper
    {
        public int Id { get; set; }
        public Language Language { get; set; }
        public string Version { get; set; }

        public ReforgedRunePathStatic ReforgedRunePath { get; set; }

        public ReforgedRunePathStaticWrapper(int id, Language language, string version, ReforgedRunePathStatic reforgedRunePath)
        {
            Id = id;
            Language = language;
            Version = version;
            ReforgedRunePath = reforgedRunePath;
        }

        public bool Validate(int id, Language language, string version)
        {
            return Id == id && Language == language && Version == version;
        }
    }
}
