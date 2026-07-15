using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            //      intilisation    condition       update
            for(int multiply = 1; multiply <= number; multiply++)
            { 
                Console.WriteLine(number + " x " + multiply + " = " + (multiply * number));
            }

            Console.ReadKey();

        }
    }
}
