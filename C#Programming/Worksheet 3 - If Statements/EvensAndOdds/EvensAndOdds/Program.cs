using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvensAndOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            //Harry Wray - Write a program that asks the user to enter a whole number then outputs a message to say whether
            //it is even or odd

            int aNumber;

            Console.Write("Enter a whole number: ");
            aNumber = int.Parse(Console.ReadLine());

            if ((aNumber % 2) > 0)
            {
                Console.WriteLine("Odd");
            }
            else
            {
                Console.WriteLine("Even");
            }

            Console.ReadKey();
        }
    }
}
