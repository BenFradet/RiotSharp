using RiotSharpNET8.Http.Interfaces;

namespace RiotSharpNET8.Http.Requesters
{
	public class HttpRequester : IHttpRequester
	{
	    private readonly HttpClient _httpClient;
	    public HttpRequester(HttpClient httpClient)
	    {
	        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
	    }

	    public async Task<HttpResponseMessage> SendMessageAsync(HttpRequestMessage request)
	    {
	        var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
	        return response;
	    }
	}
}
