using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoHalvesConcat
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Harry W - Write a program to read a string str from the keyboard, splits str into 2 halves
             and output each half separately */

            string str, firstHalf, secondHalf, concatenatedHalves;
            

            Console.Write("Write a sentence: ");
            str = Console.ReadLine();

            firstHalf = str.Substring(0, str.Length / 2);
            secondHalf = str.Remove(0, str.Length / 2); 
            Console.WriteLine("The first half of \"" + str + "' is '" + firstHalf + "' and the second half is '" + secondHalf + "'");

            concatenatedHalves = string.Concat(firstHalf, secondHalf);
            Console.WriteLine("The 2 halves put back together make '" + concatenatedHalves + "'");

            Console.ReadKey();
        }   
    }
}
