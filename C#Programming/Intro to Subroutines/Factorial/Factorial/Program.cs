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
            Console.Write("Enter a number between 1 and 10: ");
            int num = int.Parse(Console.ReadLine());
            int answer = Factorial(num);
            Console.WriteLine(answer);
            Console.ReadKey();
        }
        static int Factorial(int n)
        {
            int product = 1;
            for(int c = 1; c <= n; c++)
            {
                product *= c;
            }
            return product;
        }
    }
}
