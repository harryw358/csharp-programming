using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int numberOfThrows, throwCount;
            string answer = "y";

            while((answer == "y") || (answer == "Y"))
            {
                numberOfThrows = 0;
                throwCount = 0;
                while(throwCount != 6)
                {
                    throwCount = rnd.Next(1, 7);
                    numberOfThrows++;
                    Console.WriteLine("You threw a " + throwCount);
                }
                Console.WriteLine("That took " + numberOfThrows + " throws.");
                Console.WriteLine("Want another go? (Y or y): ");
                answer = Console.ReadLine();
            }
            Console.ReadKey();
        }
    }
}
