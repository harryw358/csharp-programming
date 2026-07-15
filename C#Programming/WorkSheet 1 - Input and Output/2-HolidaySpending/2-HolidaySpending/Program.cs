using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_HolidaySpending
{
    class Program
    {
        static void Main(string[] args)
        {
            double MoneyLeft = 50000;
            double food, trips, presents;

            Console.WriteLine("Italian Holiday");

            Console.WriteLine("You have " + MoneyLeft + " lire left to spend on your holiday");

            Console.Write("How much did you spend on food? ");
            food = double.Parse(Console.ReadLine());

            Console.Write("How much did you spend on trips? ");
            trips = double.Parse(Console.ReadLine());

            Console.Write("How much did you spend on presents? ");
            presents = double.Parse(Console.ReadLine());

            double total = MoneyLeft - food - trips - presents;

            if (total > 0)
            {
                Console.WriteLine("You now have " + total + " lire left to spend.");
            }
            else if (total < 0)
            {
                Console.WriteLine("You are now in debt of " + (total * -1) + " lire.");
            }
            Console.ReadKey();
        }
    }
}
