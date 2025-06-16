namespace RiotSharp.Core.Http.Interfaces
{
	public interface IHttpRequester
	{
		Task<HttpResponseMessage> SendMessageAsync(HttpRequestMessage request);
	}
}
