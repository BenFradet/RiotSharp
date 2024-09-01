using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharpNET8.Http.Interfaces
{
	internal interface IHttpRequester
	{
		Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
		HttpRequestMessage PrepareRequest(string host, string relativeUrl, List<string>? queryParameters, bool useHttps, HttpMethod httpMethod);
		Task<string> GetResponseContentAsync(HttpResponseMessage response);
	}

}
