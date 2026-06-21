using System.Net.Http;

namespace RiotSharp.Misc
{
  public static class HttpRequestMessageExtensions
  {

    public static HttpRequestMessage Clone(this HttpRequestMessage req)
    {
      var newReq = new HttpRequestMessage(req.Method, req.RequestUri);
      foreach (var header in req.Headers)
      {
        newReq.Headers.Add(header.Key, header.Value);
      }
      return newReq;
    }
  }
}