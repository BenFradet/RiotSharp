using System.Net.Http;

namespace RiotSharp.Http.Interfaces
{
    public interface IFailedRequestHandler
    {
        void Handle(HttpResponseMessage message);
    }
}
