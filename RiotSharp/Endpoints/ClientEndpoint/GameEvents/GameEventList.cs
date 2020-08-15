using System.Collections.Generic;
using Newtonsoft.Json;
using RiotSharp.Endpoints.ClientEndpoint.Converters;

namespace RiotSharp.Endpoints.ClientEndpoint.GameEvents
{
    public class GameEventList
    {
        internal GameEventList() { }

        [JsonProperty("Events", ItemConverterType = typeof(GameEventConverter))]
        public List<BaseGameEvent> Events { get; set; }
    }
}