using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxAndMin
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers, maximum = 0, minimum = 0;

            Console.WriteLine("Keep entering a set of numbers, -1 to stop: ");

            do
            {
                numbers = int.Parse(Console.ReadLine());
                if (maximum < numbers)
                {
                    maximum = numbers;
                }
                else if (minimum > numbers)
                {
                    minimum = numbers;
                }
            }

            while (numbers != -1);
            Console.WriteLine("The maximum number that was entered was: " + maximum);
            Console.WriteLine("The minimum number that was entered was: " + minimum);

            Console.ReadKey();
        }
    }
}
