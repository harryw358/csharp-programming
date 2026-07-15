using System;

namespace Excercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // print the first n natural numbers
            printNaturalNumbers(1, 10);

            Console.ReadKey();
        }

        static int printNaturalNumbers(int startValue, int maxValue)
        {
            if (maxValue < 1)
            {
                return startValue;
            }
            else
            {
                maxValue--;
                Console.Write(startValue + " ");
                return printNaturalNumbers(startValue + 1, maxValue);
            }
        }
    }
}

