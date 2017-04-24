using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace RiotSharpTest
{
    public class CommonTestBase
    {
        public static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        public static int summoner1Id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
        public static string summoner1Name = ConfigurationManager.AppSettings["Summoner1Name"];
        public static int summoner2Id = int.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);
        public static string summoner2Name = ConfigurationManager.AppSettings["Summoner2Name"];
    }
}
