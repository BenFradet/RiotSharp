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
            Task.Run(() =>
            {
                HttpWebRequest req2;
                for (int i = 0; i < 10; i++)
                {
                    req2 = Requester.Instance.CreateRequest("req2");
                    Thread.Sleep(1000);
                }
            });

            HttpWebRequest req;
            for (int i = 0; i < 10; i++)
            {
                req = Requester.Instance.CreateRequest("req1");
                Thread.Sleep(900);
            }

            Console.ReadLine();
        }
    }
}
