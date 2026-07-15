using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationTableV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            for(int multiply = 1; multiply <= number; multiply++)
            {
                for(int multiply2 = 1; multiply2 <= number; multiply2++)
                {
                   Console.Write("{0} x {1} = {2}\t", multiply2, multiply, multiply * multiply2);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
