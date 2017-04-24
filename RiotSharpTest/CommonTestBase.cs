using System;
using System.Configuration;
using RiotSharp.Misc;

namespace RiotSharpTest
{
    public class CommonTestBase
    {
        public static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        public static int summoner1Id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
        public static string summoner1Name = ConfigurationManager.AppSettings["Summoner1Name"];
        public static RiotSharp.StatsEndpoint.Season summoner1Season = (RiotSharp.StatsEndpoint.Season)Enum.Parse(typeof(RiotSharp.StatsEndpoint.Season), ConfigurationManager.AppSettings["Summoner1Season"]);
        public static int summoner2Id = int.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);
        public static string summoner2Name = ConfigurationManager.AppSettings["Summoner2Name"];
        public static Region summoner1and2Region = (Region)Enum.Parse(typeof(Region), ConfigurationManager.AppSettings["Summoner1and2Region"]);
        public static string faultyApiKey = ConfigurationManager.AppSettings["FaultyApiKey"];
    }
}
