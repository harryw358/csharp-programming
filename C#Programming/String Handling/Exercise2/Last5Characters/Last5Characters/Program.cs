using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last5Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Harry Wray - Display the last 5 characters of a sentence */

            string sentence, last5Characters;

            Console.Write("Enter a sentence: ");
            sentence = Console.ReadLine();

            last5Characters = sentence.Substring(sentence.Length - 5);

            Console.WriteLine("The last 5 characters of " + sentence + " are " +last5Characters);
            Console.ReadLine();
            

        }
    }
}
