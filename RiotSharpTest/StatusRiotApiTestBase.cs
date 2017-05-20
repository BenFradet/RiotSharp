using RiotSharp.Misc;
using System;
using System.Configuration;

namespace RiotSharpTest
{
    public class StatusRiotApiTestBase : CommonTestBase
    {
        public static Platform platform = (Platform)Enum.Parse(typeof(Platform), 
            ConfigurationManager.AppSettings["StatusPlatform"]);
    }
}
