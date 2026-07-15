using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1IfStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            //Harry W - If Statement
            //checks for a negative input

            int aNumber;

            Console.Write("Enter an integer: ");
            aNumber = int.Parse(Console.ReadLine());

            if (aNumber < 0)
            {
                Console.WriteLine("Negative Number");
            }

            Console.ReadKey();
        }
    }
}
