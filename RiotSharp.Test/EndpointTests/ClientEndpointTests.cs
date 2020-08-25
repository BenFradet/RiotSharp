using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint;
using RiotSharp.Endpoints.ClientEndpoint.Enums;

namespace RiotSharp.Test.EndpointTests
{
    [TestClass]
    public class ClientEndpointTests
    {
        private const string FullGamePath = "./Resources/ClientEndpoint/full-game.json";

        [TestMethod]
        public void DeserializeFullGame_Test()
        {
            var gameData = JsonConvert.DeserializeObject<GameData>(File.ReadAllText(FullGamePath));
            
            Assert.AreEqual(61, gameData.EventList.Events.Count);
            Assert.AreEqual(GameEventType.GameStart, gameData.EventList.Events.First().Type);
            Assert.AreEqual(GameEventType.GameEnd, gameData.EventList.Events.Last().Type);
            
            Assert.AreEqual(10, gameData.Players.Count);
            Assert.AreEqual(5, gameData.Players.Count(player => player.Team == TeamType.Order));
            Assert.AreEqual(5, gameData.Players.Count(player => player.Team == TeamType.Chaos));
        }
    }
}