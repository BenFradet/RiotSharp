using System;
using System.Configuration;
using RiotSharp.Misc;

namespace RiotSharpTest
{
    public class CommonTestBase
    {
        public static string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        public static string faultyApiKey = ConfigurationManager.AppSettings["FaultyApiKey"];

        public static Region summoner1and2Region = (Region)Enum.Parse(typeof(Region),
            ConfigurationManager.AppSettings["Summoner1and2Region"]);

        public static long summoner1Id = long.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
        public static long summoner1AccountId = long.Parse(ConfigurationManager.AppSettings["Summoner1AccountId"]);
        public static string summoner1Name = ConfigurationManager.AppSettings["Summoner1Name"];
        public static RiotSharp.StatsEndpoint.Season summoner1Season = 
            (RiotSharp.StatsEndpoint.Season)Enum.Parse(typeof(RiotSharp.StatsEndpoint.Season), 
                ConfigurationManager.AppSettings["Summoner1Season"]);

        public static long summoner2Id = long.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);
        public static long summoner2AccountId = long.Parse(ConfigurationManager.AppSettings["Summoner2AccountId"]);
        public static string summoner2Name = ConfigurationManager.AppSettings["Summoner2Name"];               
    }
}
