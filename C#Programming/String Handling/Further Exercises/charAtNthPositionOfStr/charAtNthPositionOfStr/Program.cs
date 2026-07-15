using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charAtNthPositionOfStr
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Harry W - Write a program to read a string s and an integer n from the keyboard and output the character at the nth position of s */

            string str;
            int num;
            char nthCharacter;

            Console.Write("Write a sentence: ");
            str = Console.ReadLine();

            Console.Write("Enter a number (n) : ");
            num = int.Parse(Console.ReadLine());

            nthCharacter =(str[num-1]);

            Console.WriteLine("The nth character in " + str + " is '" + nthCharacter + "'");

            Console.ReadKey();
        }
    }
}
