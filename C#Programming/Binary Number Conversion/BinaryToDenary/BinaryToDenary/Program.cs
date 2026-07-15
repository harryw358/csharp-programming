using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryToDenary
{
    class Program
    {
        static void Main(string[] args)
        {
            string binaryString;
            int binaryLength, multiplier = 1, denaryValue = 0, digit;

            Console.Write("Enter a binary number: ");
            binaryString = Console.ReadLine();
            binaryLength = binaryString.Length;

            for (int n = binaryLength - 1; n >= 0; n--)
            {
                digit = Convert.ToInt32(binaryString.Substring(n, 1));
                denaryValue = denaryValue + digit * multiplier;
                multiplier = multiplier * 2;
            }

            Console.WriteLine("The denary equivalent is: " + denaryValue);
            Console.ReadKey();
        }
    }
}
