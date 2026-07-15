using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2IfElseStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            //Harry Wray - If-Else Statement

            int aNumber;

            Console.Write("Enter an integer: ");
            aNumber = int.Parse(Console.ReadLine());

            if (aNumber < 0)
            {
                Console.WriteLine("Negative Number");
            }
            else
            {
                Console.WriteLine("Value = " + aNumber);
            }

            Console.ReadKey();
        }
    }
}
