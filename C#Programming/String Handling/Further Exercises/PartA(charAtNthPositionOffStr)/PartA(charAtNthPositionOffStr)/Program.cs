using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartA_charAtNthPositionOffStr_
{
    class Program
    {
        static void Main(string[] args)
        {

            string str;
            int num;
            char nthCharacterFromEndOfStr;

            Console.Write("Write a sentence: ");
            str = Console.ReadLine();

            Console.Write("Enter a number (n) : ");
            num = int.Parse(Console.ReadLine());

            nthCharacterFromEndOfStr = (str[str.Length - num]);

            Console.WriteLine("The nth character from the end of " + str + " is '" + nthCharacterFromEndOfStr + "'");

            Console.ReadKey();
        }
    }
}
