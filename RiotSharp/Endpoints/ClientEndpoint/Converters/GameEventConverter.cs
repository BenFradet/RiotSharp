using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RiotSharp.Endpoints.ClientEndpoint.Enums;
using RiotSharp.Endpoints.ClientEndpoint.GameEvents;

namespace RiotSharp.Endpoints.ClientEndpoint.Converters
{
    public class GameEventConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // taken from https://blog.mbwarez.dk/deserializing-different-types-based-on-properties-with-newtonsoft-json/
            var jsonObject = JToken.ReadFrom(reader);
            var eventType = jsonObject["EventName"].ToObject<GameEventType>();

            GameEvent result;
            switch (eventType)
            {
                case GameEventType.GameStart:
                {
                    result = new GameStartedEvent();
                    break;
                }
                case GameEventType.MinionsSpawning:
                {
                    result = new MinionsSpawningEvent();
                    break;
                }
                case GameEventType.FirstTower:
                {
                    result = new FirstTowerEvent();
                    break;
                }
                case GameEventType.TurretKilled:
                {
                    result = new TurretKilledEvent();
                    break;
                }
                case GameEventType.InhibitorKilled:
                {
                    result = new InhibitorKilledEvent();
                    break;
                }
                case GameEventType.DragonKilled:
                {
                    result = new DragonKilledEvent();
                    break;
                }
                case GameEventType.HeraldKilled:
                {
                    result = new HeraldKilledEvent();
                    break;
                }
                case GameEventType.BaronKilled:
                {
                    result = new BaronKilledEvent();
                    break;
                }
                case GameEventType.FirstBlood:
                {
                    result = new FirstBloodEvent();
                    break;
                }
                case GameEventType.ChampionKilled:
                {
                    result = new ChampionKilledEvent();
                    break;
                }
                case GameEventType.MultiKill:
                {
                    result = new MultiKillEvent();
                    break;
                }
                case GameEventType.Aced:
                {
                    result = new AcedEvent();
                    break;
                }
                default:
                {
                    throw new ArgumentException($"Unknown {nameof(GameEventType)}: {eventType}!");
                }
            }

            serializer.Populate(jsonObject.CreateReader(), result);
            return result;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}