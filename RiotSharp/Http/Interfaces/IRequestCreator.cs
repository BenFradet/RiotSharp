using System.Collections.Generic;
using System.Net.Http;
using RiotSharp.Misc;

namespace RiotSharp.Http.Interfaces
{
    public interface IRequestCreator
    {
        HttpRequestMessage CreateGetRequest(Region region, string apiEndpoint, List<string> addedArguments, bool useHttps = true);
    }
}
