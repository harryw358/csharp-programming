using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestNumberEntered
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers, maximum = 0;

            Console.WriteLine("Keep entering a set of numbers");

            do
            {
                numbers = int.Parse(Console.ReadLine());
                if (maximum < numbers)
                {
                    maximum = numbers;
                }
            }
            while (numbers <= 10);
            Console.WriteLine("The largest number that was entered was: " + maximum);

            Console.ReadKey();
        }
    }
}
