using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3UsingBooleanOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            //Harry Wray - Using Boolean Operators

            int aNumber;

            Console.Write("Enter a number between 0 and 10: ");
            aNumber = int.Parse(Console.ReadLine());

            if ((aNumber > 0) && (aNumber < 10))
            {
                Console.WriteLine("Thank you - number is " + aNumber);
            }
            else
            {
                Console.WriteLine("NO - I said between 0 and 10!");
            }

            Console.ReadKey();
        }
    }
}
