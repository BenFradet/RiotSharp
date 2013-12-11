using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RiotSharp;

namespace RiotSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Requester.LimitEnabled = true;
            Task.Run(() =>
            {
                HttpWebRequest req2;
                for (int i = 0; i < 30; i++)
                {
                    Thread.Sleep(2000);
                    req2 = Requester.Instance.CreateRequest("req2");
                }
            });

            HttpWebRequest req;
            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(2000);
                req = Requester.Instance.CreateRequest("req1");
            }

            Console.ReadLine();
        }
    }
}
