using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;

            Console.Write("Enter a number: ");
            try
            {
                num1 = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a whole number.");
                Console.Write("Enter a number: ");
                num1 = int.Parse(Console.ReadLine());
            }
            Console.Write("Enter another number: ");
            try
            {
                num2 = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a whole number.");
                Console.Write("Enter another number: ");
                num2 = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(num1 + " goes into " + num2 + " " + (num2 / num1) + " times, and the remainder is " + (num2 % num1));
            Console.ReadKey();
        }
    }
}
