using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit, predecessor = 0, successor = 1, temp, numOfTerms = 0;

            Console.WriteLine("Fibonacci Sequence");
            Console.WriteLine();

            Console.Write("Enter a limiting value: ");
            try
            {
                limit = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a whole number.");
                Console.Write("Enter a limiting value: ");
                limit = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            if (limit > 0)
            {
                do
                {
                    Console.Write(successor + " ");
                    temp = successor;
                    successor = successor + predecessor;
                    predecessor = temp;
                    numOfTerms++;
                }
                while (successor <= limit);

                Console.WriteLine();
                Console.WriteLine("\nThere are " + numOfTerms + " terms up to " + limit);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please enter a number greater than 0, thank you.");
                Console.ReadKey();
            }
        }
    }
}
