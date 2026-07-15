using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramString4
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Harry W */
            /* using functions: Copy, Substring, IndexOf, Remove, Insert, Replace */

            int position;
            string sentence, copied, word;

            sentence = "The cat sat on the mat";
            Console.WriteLine(sentence);

            copied = string.Copy(sentence);
            Console.WriteLine(copied);

            word = sentence.Substring(4, 3);
            Console.WriteLine(word);

            position = sentence.IndexOf("s");
            Console.WriteLine(position);

            sentence = sentence.Remove(8, 4);
            Console.WriteLine(sentence);

            sentence = sentence.Insert(8, "is ");
            Console.WriteLine(sentence);

            sentence = sentence.Replace("cat", "dog");
            Console.WriteLine(sentence);

            Console.ReadKey();
        }
    }
}
