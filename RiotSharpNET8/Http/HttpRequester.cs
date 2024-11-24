using RiotSharpNET8.Http.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RiotSharpNET8.Http
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
