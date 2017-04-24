using RiotSharp.Misc;
using System;
using System.Configuration;

namespace RiotSharpTest
{
    public class StatusRiotApiTestBase : CommonTestBase
    {
        public static Region region = (Region)Enum.Parse(typeof(Region), ConfigurationManager.AppSettings["StatusRegion"]);
    }
}
