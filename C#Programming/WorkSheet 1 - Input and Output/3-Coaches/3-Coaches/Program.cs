using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Coaches
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalMembers, coachCapacity, fullCoaches, passengersLeft;

            Console.Write("How many passengers are going to the match? ");
            totalMembers = int.Parse(Console.ReadLine());

            Console.Write("What's the seating capacity of the coach? ");
            coachCapacity = int.Parse(Console.ReadLine());

            fullCoaches = (totalMembers / coachCapacity);

            passengersLeft = (totalMembers % coachCapacity);

            Console.WriteLine("There are " + fullCoaches + " full coaches, and " + passengersLeft + " passengers left on the last coach.");
            Console.ReadKey();
        }
    }
}
