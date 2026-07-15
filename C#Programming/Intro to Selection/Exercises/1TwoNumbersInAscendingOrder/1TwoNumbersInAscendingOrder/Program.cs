using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1TwoNumbersInAscendingOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            //Harry Wray - To accept 2 integers and output them in ascending numerical order

            int num1, num2;

            Console.Write("Enter a number: ");
            num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter another number: ");
            num2 = int.Parse(Console.ReadLine());

            if (num1 > num2)
            {
                Console.WriteLine(num1 + " and " + num2 + " in ascending numerical order is " + num2 + ", " + num1);
            }
            else
            {
                Console.WriteLine(num1 + " and " + num2 + " in ascending numerical order is " + num1 + ", " + num2);
            }
            Console.ReadLine();
        }
    }
}
