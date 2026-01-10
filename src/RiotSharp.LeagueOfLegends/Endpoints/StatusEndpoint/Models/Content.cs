using RiotSharp.Core.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace RiotSharp.LeagueOfLegends.Endpoints.StatusEndpoint.Models
{
    public class Content
    {
        [JsonPropertyName("locale")]
        public Language Locale { get; set; }

        [JsonPropertyName("content")]
        public string TextContent { get; set; }
    }
}