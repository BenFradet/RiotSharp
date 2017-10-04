using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using RiotSharp.Http.Interfaces;

namespace RiotSharp.Http
{
    public class FailedRequestHandler : IFailedRequestHandler
    {
        public void Handle(HttpResponseMessage message)
        {
            if (message.IsSuccessStatusCode)
            {
                return;
            }
            switch (message.StatusCode)
            {
                case HttpStatusCode.ServiceUnavailable:
                    throw new RiotSharpException("503, Service unavailable", message.StatusCode);
                case HttpStatusCode.InternalServerError:
                    throw new RiotSharpException("500, Internal server error", message.StatusCode);
                case HttpStatusCode.Unauthorized:
                    throw new RiotSharpException("401, Unauthorized", message.StatusCode);
                case HttpStatusCode.BadRequest:
                    throw new RiotSharpException("400, Bad request", message.StatusCode);
                case HttpStatusCode.NotFound:
                    throw new RiotSharpException("404, Resource not found", message.StatusCode);
                case HttpStatusCode.Forbidden:
                    throw new RiotSharpException("403, Forbidden", message.StatusCode);
                case (HttpStatusCode)429:
                    throw new RiotSharpException("429, Rate Limit Exceeded", message.StatusCode);
                default:
                    throw new RiotSharpException("Unexpeced failure", message.StatusCode);
            }
        }
    }
}
