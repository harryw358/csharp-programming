using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1OrienteeringEvent
{
    class Program
    {
        struct TCompetitor
        {
            public string Name;
            public int[] Times;
            public int TotalTime;
        }
        static void Main(string[] args)
        {
            TCompetitor competitor01 = new TCompetitor
            {
                Times = new int[4],
                TotalTime = 0
            };
            TCompetitor competitor02 = new TCompetitor
            {
                Times = new int[4],
                TotalTime = 0
            };
            Console.WriteLine("Orienteering Event");
            Console.WriteLine("\nEnter details for first competitor");
            competitor01 = EnterDetails(competitor01);
            competitor01.TotalTime = TotalTime(competitor01);
            Console.WriteLine("\nEnter details for second competitor");
            competitor02 = EnterDetails(competitor02);
            competitor02.TotalTime = TotalTime(competitor02);
            Console.WriteLine();
            DisplayResult(competitor01, competitor02);

            Console.ReadKey();
        }
        static TCompetitor EnterDetails(TCompetitor competitor)
        {
            Console.Write("Enter name: ");
            competitor.Name = Console.ReadLine();
            for(int i = 0; i < 4; i++)
            {
                Console.Write("Enter time (mins) for leg " + (i + 1) + ": ");
                competitor.Times[i] = int.Parse(Console.ReadLine());
            }
            return competitor;
        }
        static int TotalTime(TCompetitor competitor)
        {
            for(int i = 0; i < 4; i++)
            {
                competitor.TotalTime += competitor.Times[i];
            }
            return competitor.TotalTime;
        }
        static void DisplayResult(TCompetitor competitor01, TCompetitor competitor02)
        {
            if(competitor01.TotalTime < competitor02.TotalTime)
            {
                Console.WriteLine(competitor01.Name + " was the fastest and took " + competitor01.TotalTime + " minutes.");
                Console.WriteLine(competitor02.Name + " took " + competitor02.TotalTime + " minutes.");
            }
            else if(competitor02.TotalTime < competitor01.TotalTime)
            {
                Console.WriteLine(competitor02.Name + " was the fastest and took " + competitor02.TotalTime + " minutes.");
                Console.WriteLine(competitor01.Name + " took " + competitor01.TotalTime + " minutes.");
            }
            else
            {
                Console.WriteLine("Both competitors took the same amount of time.");
            }
        }
    }
}
