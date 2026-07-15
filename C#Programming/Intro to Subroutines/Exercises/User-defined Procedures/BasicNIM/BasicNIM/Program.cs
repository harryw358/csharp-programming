using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicNIM
{
    class Program
    {
        static void Main(string[] args)
        {
            //randomizes the number of counters and displays them horizontally
            int numOfCounters = Counters();
            DisplayCounters(numOfCounters);
            Console.WriteLine();

            //players move
            int removeCounters = PlayerMove(removeCounters = 0, numOfCounters);
            Console.Clear();
            DisplayCounters(numOfCounters - removeCounters);

            //computers move
            int computerRemoveCounters = ComputerMove(computerRemoveCounters = 0, numOfCounters);
            Console.Clear();
            DisplayCounters(numOfCounters - removeCounters - computerRemoveCounters);

            Console.ReadKey();
        }
        static int Counters()
        {
            Random counters = new Random();
            return counters.Next(5, 21);
        }
        static void DisplayCounters(int numOfCounters)
        {
            Console.WriteLine();
            for(int i = 0; i <= numOfCounters; i++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
        static int PlayerMove(int removeCounters, int numOfCounters)
        {
            do
            {
                Console.Write("How many counters do you want to remove? ");
                try
                {
                    removeCounters = int.Parse(Console.ReadLine());
                    if (removeCounters < 1 || removeCounters > 3)
                        throw new Exception();
                }
                catch
                {
                    Console.WriteLine("You can only remove 1, 2 or 3 counters at a time.");
                    Console.ReadKey();
                    Console.Clear();
                    DisplayCounters(numOfCounters);
                    Console.WriteLine();
                }
            }
            while (removeCounters < 1 || removeCounters > 3);
            Console.WriteLine("Player has chosen to remove " + removeCounters + " counters.");
            Console.ReadKey();
            return removeCounters;
        }
        static int ComputerMove(int computerRemoveCounters, int numOfCounters)
        {
            Random rnd = new Random();
            computerRemoveCounters = rnd.Next(1, 4);
            Console.WriteLine("\nThe computer has chosen to remove " + computerRemoveCounters + " counters.");
            Console.ReadKey();
            return computerRemoveCounters;
        }
    }
}
