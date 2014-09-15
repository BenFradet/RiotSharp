using System;
using System.Configuration;
using RiotSharp;

namespace RiotSharpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = RiotApi.GetInstance(ConfigurationManager.AppSettings["ApiKey"]);
            var staticApi = StaticRiotApi.GetInstance(ConfigurationManager.AppSettings["ApiKey"]);
            int id = int.Parse(ConfigurationManager.AppSettings["Summoner1Id"]);
            string name = ConfigurationManager.AppSettings["Summoner1Name"];
            int id2 = int.Parse(ConfigurationManager.AppSettings["Summoner2Id"]);
            string name2 = ConfigurationManager.AppSettings["Summoner2Name"];
            string team = ConfigurationManager.AppSettings["Team1Id"];
            string team2 = ConfigurationManager.AppSettings["Team2Id"];

            var games = api.GetRecentGames(Region.euw, id);

            Console.ReadLine();
        }
    }
}
