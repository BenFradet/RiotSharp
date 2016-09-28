using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using Moq;
using RiotSharp;
using RiotSharp.ChampionEndpoint;
using RiotSharp.SummonerEndpoint;
using Newtonsoft.Json;

namespace RiotSharpTest
{
    /// <summary>
    /// Contains a variety of helper methods to generate objects for API testing
    /// </summary>
    static class ApiTestHelper
    {
        private static Summoner sum1 = new Summoner()
        {
            Id = 57039082,
            Name = "keanefo",
            Region = Region.na
        };
        private static Summoner sum2 = new Summoner()
        {
            Id = 31588136,
            Name = "Zaganox",
            Region = Region.na
        };
        private static Champion chp1 = new Champion()
        {
            Id = 1234,
            FreeToPlay = true,
            Active = true,
            BotEnabled = true,
            BotMmEnabled = true,
            RankedPlayEnabled = true
        };
        private static Champion chp2 = new Champion()
        {
            Id = 3214,
            FreeToPlay = false,
            Active = false,
            BotEnabled = false,
            BotMmEnabled = false,
            RankedPlayEnabled = false

        };

        private static Mastery mast1 = new Mastery()
        {
            Id = 12345,
            Rank = 1
        };

        private static Mastery mast2 = new Mastery()
        {
            Id = 54321,
            Rank = 2
        };

        private static MasteryPage mp1 = new MasteryPage()
        {
            Current = true,
            Id = 1234,
            Masteries = new List<Mastery>()
            {
                mast1,
                mast2
            },
            Name = "Test"
        };

        private static MasteryPages pg1 = new MasteryPages()
        {
            Pages = new List<MasteryPage>()
            {
                mp1
            },
            SummonerId = 57039082
        };

        private static List<MasteryPages> masteryList = new List<MasteryPages>()
        {

        };


        private static string team = "TEAM-66fbf960-a74c-11e4-a5a6-c81f66dd45c9";
        private static string team2 = "TEAM-0a2ea1b0-f1cf-11e4-bc7e-c81f66ddabda";
        private static int gameId = 1826202304;
        private static RiotApi api;
        private static Queue queue = Queue.RankedSolo5x5;
        private static Region region = Region.na;
        private static RiotSharp.MatchEndpoint.Enums.Season season = RiotSharp.MatchEndpoint.Enums.Season.Season2015;
        private static DateTime beginTime = new DateTime(2015, 01, 01);
        private static DateTime endTime { get { return DateTime.Now; } }

        public static Region GetRegion()
        {
            return region;
        }

        public static Summoner GetSummoner()
        {
            return sum1;
        }

        public static List<Summoner> GetSummonerList()
        {
            return new List<Summoner>()
            {
                sum1,
                sum2
            };
        }

        public static Champion GetChampion()
        {
            return chp1;
        }

        public static List<Champion> GetChampionList()
        {
            return new List<Champion>()
            {
                chp1,
                chp2
            };
        }

        public static IRateLimitedRequester GenerateRequester(string json)
        {
            IRateLimitedRequester req = null;
            var mockReq = new Mock<IRateLimitedRequester>();
            mockReq.Setup(x => x.CreateGetRequest(It.IsAny<string>(), It.IsAny<Region>(),
                                    It.IsAny<List<string>>(), It.IsAny<bool>())).Returns(json);
            mockReq.Setup(x => x.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<Region>(),
                        It.IsAny<List<string>>(), It.IsAny<bool>())).ReturnsAsync(json);
            req = mockReq.Object;
            return req;
        }

        public static Dictionary<long, Summoner> GetSummonersIdDictionary(int count)
        {
            var dict = new Dictionary<long, Summoner>();
            var sumList = GetSummonerList();
            for (int i = 0; i < count && i < sumList.Count; i++)
            {
                dict.Add(sumList[i].Id, sumList[i]);
            }
            return dict;
        }

        public static ChampionList GetChampionList(int count, bool freeToPlay = false)
        {
            ChampionList list = new ChampionList();
            var champList = GetChampionList();
            var champ = new List<Champion>();
            if (freeToPlay)
            {
                foreach (Champion chp in champList)
                {
                    if (chp.FreeToPlay)
                    {
                        champ.Add(chp);
                    }
                }
            }
            else
            {
                champ = champList;
            }
            list.Champions = champ.Take(count).ToList();
            return list;
        }

        public static Dictionary<string, string> GetSummonersNameDictionary(int count)
        {
            var sumList = GetSummonerList();
            var dict = new Dictionary<string, string>();
            for (int i = 0; i < count && i < sumList.Count; i++)
            {
                dict.Add(sumList[i].Id.ToString(), sumList[i].Name);
            }
            return dict;
        }
    }
}
