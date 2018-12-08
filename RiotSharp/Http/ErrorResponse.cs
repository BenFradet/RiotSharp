using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Http
{
    /// <summary>
    /// Internal class for deserializing responses of failed requests.
    /// </summary>
    internal class ErrorResponse
    {
        [JsonProperty("status")]
        public StatusContent Status { get; set; }

        internal class StatusContent
        {
            [JsonProperty("status_code")]
            public int StatusCode { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }
        }
    }
}
