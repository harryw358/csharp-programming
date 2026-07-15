using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(num + "! = " + Factorial_Recursive(num) + " (recursion)");
            Console.WriteLine(num + "! = " + Factorial_Iteration(num) + " (iteration");
            Console.WriteLine("The Fibonacci of " + num + " = " + Fibonacci(num));
            Console.Write("Enter another number: ");
            num = int.Parse(Console.ReadLine());
            Console.Write("Enter an exponent: ");
            int exponent = int.Parse(Console.ReadLine());
            Console.WriteLine(num + "^" + exponent + " = " + Power(num, exponent));
            Console.ReadKey();
        }

        static int Factorial_Recursive(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial_Recursive(n - 1);
            }
        }

        static int Factorial_Iteration(int n)
        {
            for (int i = n - 1; i >= 2; i--)
            {
                n *= i;
            }
            return n;
        }

        static int Fibonacci(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }

        static int Power(int a, int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return a * Power(a, n - 1);
            }
        }
    }
}
