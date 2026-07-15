using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengthOfSentence
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Harry W - Enter a sentence and display the length of the character string entered */

            string sentence;
            int num;

            Console.Write("Write a sentence: ");
            sentence = Console.ReadLine();

            num = sentence.Length;

            Console.WriteLine("There are " + num + " characters in the sentence: " + sentence);

            Console.ReadKey();
        }
    }
}
