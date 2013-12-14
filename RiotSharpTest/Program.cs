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
            var api = new RiotApi("", false);
            var summoner = api.GetSummoners(Region.euw, new List<int> { 1 });

            foreach (SummonerBase parent in summoner)
            {
                Console.WriteLine(parent.Id);
                Console.WriteLine(parent.Name);
                Console.WriteLine();
            }

            var summ = api.GetSummoner(Region.euw, 1);
            var masteries = summ.GetMasteryPages().First();
            
            foreach (Talent talent in masteries.Talents)
            {
                Console.WriteLine(talent.Name + " " + talent.Rank);
            }

            //var pages = summ.GetRunePages();

            //foreach (RunePage page in pages.Take(100))
            //{
            //    foreach (RuneSlot slot in page.Slots)
            //    {
            //        Console.WriteLine(slot.Rune.Name);
            //    }
            //    Console.WriteLine(page.Name);
            //    Console.WriteLine();
            //}

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
