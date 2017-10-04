using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Http.Interfaces
{
    public interface IRequestContentSerializer
    {
        HttpContent Serialize(object body);

        Task<HttpContent> SerializeAsync(object body);
    }
}
