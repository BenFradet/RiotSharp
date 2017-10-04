using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RiotSharp.Http.Interfaces
{
    public interface IResponseDeserializer
    {
        T DeserializeTo<T>(HttpResponseMessage message);

        Task<T> DeserializeToAsync<T>(HttpResponseMessage message);
    }
}
