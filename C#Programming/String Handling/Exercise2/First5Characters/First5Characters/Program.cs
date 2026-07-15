using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First5Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Harry Wray - Display the first 5 characters of a sentence */

            string sentence, finalSentence;

            Console.Write("Write a sentence: ");
            sentence = Console.ReadLine();

            finalSentence = sentence.Substring(0, 5);

            Console.WriteLine("The first 5 characters of the sentence '" + sentence + "' are: '" + finalSentence + "'");

            Console.ReadKey();
        }
    }
}
