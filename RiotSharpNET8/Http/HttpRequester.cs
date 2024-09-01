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
	    private readonly string _apiKey;
	    private static readonly HashSet<HttpStatusCode> RiotHttpStatusCodeBadResponse = new()
	    {
	        HttpStatusCode.BadRequest, HttpStatusCode.Unauthorized,
	        HttpStatusCode.Forbidden, HttpStatusCode.NotFound,
	        HttpStatusCode.MethodNotAllowed, HttpStatusCode.UnsupportedMediaType,
	        HttpStatusCode.InternalServerError, HttpStatusCode.BadRequest,
	        HttpStatusCode.ServiceUnavailable, HttpStatusCode.GatewayTimeout
	    };

	    public HttpRequester(HttpClient httpClient, string apiKey)
	    {
	        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
	        _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
	    }

	    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
	    {
	        var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
	        if (!response.IsSuccessStatusCode)
	        {
	            HandleRequestFailure(response); //Pass Response to get status code, Then Dispose Object.
	        }
	        return response;
	    }

	    public HttpRequestMessage PrepareRequest(string host, string relativeUrl, List<string>? queryParameters, bool useHttps, HttpMethod httpMethod)
	    {
	        var scheme = useHttps ? "https" : "http";
	        var url = queryParameters == null
	            ? $"{scheme}://{host}{relativeUrl}"
	            : $"{scheme}://{host}{relativeUrl}?{BuildArgumentsString(queryParameters)}";

	        var requestMessage = new HttpRequestMessage(httpMethod, url);
	        if (!string.IsNullOrEmpty(_apiKey))
	        {
	            requestMessage.Headers.Add("X-Riot-Token", _apiKey);
	        }
	        return requestMessage;
	    }

	    public async Task<string> GetResponseContentAsync(HttpResponseMessage response)
	    {
	        using (response)
	        using (var content = response.Content)
	        {
	            return await content.ReadAsStringAsync().ConfigureAwait(false);
	        }
	    }

	    private string BuildArgumentsString(List<string> arguments)
	    {
	        return arguments
	            .Where(arg => !string.IsNullOrWhiteSpace(arg))
	            .Aggregate(string.Empty, (current, arg) => current + ("&" + arg));
	    }

	    private void HandleRequestFailure(HttpResponseMessage response)
	    {
	        try
	        {
	            if (response.StatusCode == (HttpStatusCode)429)
	            {
	                var retryAfter = TimeSpan.Zero;
	                if (response.Headers.TryGetValues("Retry-After", out var retryAfterHeaderValues))
	                {
	                    if (int.TryParse(retryAfterHeaderValues.FirstOrDefault(), out var seconds))
	                    {
	                        retryAfter = TimeSpan.FromSeconds(seconds);
	                    }
	                }

	                string? rateLimitType = null;
	                if (response.Headers.TryGetValues("X-Rate-Limit-Type", out var rateLimitTypeHeaderValues))
	                {
	                    rateLimitType = rateLimitTypeHeaderValues.FirstOrDefault();
	                }
	                throw new RiotSharpRateLimitException("429, Rate Limit Exceeded", response.StatusCode, retryAfter, rateLimitType ?? "No rateLimitType specified in response");
	            }
	            else if (RiotHttpStatusCodeBadResponse.Contains(response.StatusCode))
	            {
	                string? message = response.StatusCode.ToString();
	                var json = response.Content.ToString();
	                if (json != null)
	                {
	                    using var doc = JsonDocument.Parse(json);
	                    var root = doc.RootElement;
	                    if (root.TryGetProperty("status", out var statusElement) &&
	                        statusElement.TryGetProperty("message", out var messageElement))
	                    {
	                        message = messageElement.GetString();
	                    }
	                }
	                throw new RiotSharpException(message ?? "There was no message in the response", response.StatusCode);
	            }
	            else
	            {
	                throw new RiotSharpException("Unexpected failure", response.StatusCode);
	            }
	        }
	        finally
	        {
	            response.Dispose(); //Dispose Response On Error
	        }
	    }
	}

}
