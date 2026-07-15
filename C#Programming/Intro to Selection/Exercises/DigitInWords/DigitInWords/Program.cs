using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitInWords
{
    class Program
    {
        static void Main(string[] args)
        {
            //Harry Wray - Accept a digit 0 to 9 and write the digit entered in words

            int num;

            Console.Write("Enter a digit 0 to 9: ");
            num = int.Parse(Console.ReadLine());

            if (num == 1)
            {
                Console.WriteLine("One");
            }
            else if (num == 2)
            {
                Console.WriteLine("Two");
            }
            else if (num == 3)
            {
                Console.WriteLine("Three");
            }
            else if (num == 4)
            {
                Console.WriteLine("Four");
            }
            else if (num == 5)
            {
                Console.WriteLine("Five");
            }
            else if (num == 6)
            {
                Console.WriteLine("Six");
            }
            else if (num == 7)
            {
                Console.WriteLine("Seven");
            }
            else if (num == 8)
            {
                Console.WriteLine("Eight");
            }
            else if (num == 9)
            {
                Console.WriteLine("Nine");
            }
            else
            {
                Console.WriteLine("Invalid number");
            }

            Console.ReadKey();

        }
    }
}
