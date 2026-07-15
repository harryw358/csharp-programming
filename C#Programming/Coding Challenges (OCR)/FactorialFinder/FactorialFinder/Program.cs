using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter, factorial = 1, num;

            Console.Write("Enter a number: ");
            num = int.Parse(Console.ReadLine());

            if (num < 0)
            {
                Console.WriteLine("You cannot find the factorial of a negative number, sorry.");
            }
            else if (num <= 1)
            {
                Console.WriteLine(num + "! is 1");
            }
            else if (num >= 32)
            {
                Console.WriteLine("That number is too big, sorry.");
               
            }
            else
            {
                for(counter = num; counter >= 2; counter--)
                {
                    factorial = counter * factorial;                     
                }
            }

            Console.WriteLine(num + "! = " + factorial);
            Console.ReadKey();
        }
    }
}
