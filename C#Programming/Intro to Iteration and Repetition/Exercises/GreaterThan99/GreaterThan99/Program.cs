using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreaterThan99
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            do
            {
                Console.Write("Enter a whole number between 100 and 200: ");
                try
                {
                    number = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please enter a whole number.");
                    number = int.Parse(Console.ReadLine());
                }
                if ((number < 100) || (number > 200))
                {
                    Console.WriteLine("I said enter a whole number between 100 and 200.");
                }
            }
            while ((number < 100) || (number > 200));
            Console.WriteLine("Thank you!");
            Console.ReadKey();

        }
    }
}
