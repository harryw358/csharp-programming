using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartB_CharAtNthPositionOfStr_
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Harry W - Re-write the program to output the first, last, middle characters of s */

            string str;
            int length;
            char first, middle, last;

            Console.Write("Write a sentence: ");
            str = Console.ReadLine();

            first = str[0];
            length = str.Length;
            middle = str[length / 2];
            last = str[length - 1];

            Console.WriteLine("The first character of " + str + " is '" + first + "'.");
            Console.WriteLine("The middle character of " + str + " is '" + middle + "'.");
            Console.WriteLine("The last character of " + str + " is '" + last + "'.");

            Console.ReadKey();

        }
    }
}
