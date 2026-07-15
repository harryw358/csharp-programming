using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            double n = double.Parse(Console.ReadLine());
            double f = 16.0d, x, l;
            if(n >= 1.0)
            {
                x = n;
                while(x * x - n > 1.0 && f - 1.0 > 1.0)
                {
                    l = x;
                    x = x / f;
                    while (x * x <= n)
                    {
                        f = f - 0.1;
                        x = l / f;
                    }
                }
                Console.WriteLine(x);
            }
            else
            {
                Console.WriteLine("Not a number greater than or equal to 1.");
            }
            Console.ReadKey();
        }
    }
}
