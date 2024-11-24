using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharpNET8.Http.Interfaces
{
	public interface IHttpRequester
	{
		Task<HttpResponseMessage> SendMessageAsync(HttpRequestMessage request);
	}
}
