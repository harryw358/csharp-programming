using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            //testing errors:
            // - some numbers entered give a negative value
            // - some numbers entered give a num! = 0 (fixed, range check used)

            int num, factorial = 1;

            Console.Write("Enter a number: ");
            num = int.Parse(Console.ReadLine());

            if (num < 0)
            {
                Console.WriteLine("Sorry, you can't find the factorial of a negative number.");
            }
            else if (num > 31)
            {
                Console.WriteLine("Sorry, that number is too big.");
            }
            else if (num <= 1)
            {
                Console.WriteLine(num + "! = " + factorial);
            }
            else
            {
                for(int counter = num; counter >= 2; counter--)
                {
                    factorial = factorial * counter;
                }
                Console.WriteLine(num + "! = " + factorial);
            }

            Console.ReadKey();
        }
    }
}
