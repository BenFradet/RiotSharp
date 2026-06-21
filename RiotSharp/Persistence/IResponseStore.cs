using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Persistence
{
    public interface IResponseStore
    {
       
        void Save(string key, string response);

        Response Get(string key);
    }
}
