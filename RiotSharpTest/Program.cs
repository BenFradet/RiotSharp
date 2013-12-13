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
            //toreplace
            var api = new RiotApi("toreplace");
            var summoner = api.GetSummoners(Region.euw, new List<int> { 123456, 654321 });

            foreach (CommonParent parent in summoner)
            {
                Console.WriteLine(parent.Id);
                Console.WriteLine(parent.Name);
                Console.WriteLine();
            }

            //Console.WriteLine(summoner.Name);
            //Console.WriteLine(summoner.Level);
            //Console.WriteLine(summoner.Id);
            //Console.WriteLine(summoner.ProfileIconId);
            //Console.WriteLine(summoner.RevisionDate);
            //Console.WriteLine(summoner.RevisionDateString);

            Console.ReadLine();
        }
    }
}
