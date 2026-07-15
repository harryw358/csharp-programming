using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramString1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Harry W */
            /* using the Length function to display the number of characters in the string */

            string aWord;
            int aNum;

            Console.Write("Enter a word: ");
            aWord = Console.ReadLine();

            aNum = aWord.Length;

            Console.WriteLine("There are " + aNum + " letters in the word " + aWord);
            Console.ReadKey();
        }
    }
}
