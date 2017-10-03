using System.Collections.Generic;
using System.Net.Http;
using RiotSharp.Misc;

namespace RiotSharp.Http.Interfaces
{
    public interface IRequestCreator
    {
        HttpRequestMessage CreateGetRequest(Region region, string apiEndpoint, List<string> addedArguments, bool useHttps = true);

        HttpRequestMessage CreatePostRequest<T>(Region region, string apiEndpoint, T body, List<string> addedArguments, bool useHttps);

        HttpRequestMessage CreatePutRequest<T>(Region region, string apiEndpoint, T body, List<string> addedArguments, bool useHttps);
    }
}
