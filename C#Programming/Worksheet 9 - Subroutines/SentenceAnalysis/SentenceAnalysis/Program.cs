using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sentence Analysis");

            //function to enter a sentence
            string sentence = EnterSentence();

            //function to get to word count
            int wordCount = WordCount(sentence);
            Console.WriteLine("\nYour sentence contains " + wordCount + " words.");

            //function to get the vowel count
            int vowelCount = VowelCount(sentence);
            Console.WriteLine("Your sentence contains " + vowelCount + " vowels.");

            //function to get the consonant count
            int consonantCount = ConsonantCount(sentence, vowelCount);
            Console.WriteLine("Your sentence contains " + consonantCount + " consonants.");

            //function to get the puncuation count
            int punctuationCount = PunctuationCount(sentence);
            Console.WriteLine("Your sentence contains " + punctuationCount + " lots of punctuation.");


            Console.ReadKey();
        }
        static string EnterSentence(string sentence = " ")
        {
            Console.WriteLine("\nEnter a sentence, then press 'Enter'");
            Console.WriteLine();
            sentence = Console.ReadLine();
            return sentence;
        }
        static int WordCount(string sentence, int wordCount = 0)
        {
            foreach(char c in sentence)
            {
                if (c == ' ')
                    wordCount++;
            }
            return wordCount + 1;
        }
        static int VowelCount(string sentence, int vowelCount = 0)
        {
            char[] vowels = new char[10] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            foreach(char c in sentence)
            {
                for(int i = 0; i < vowels.Length; i++)
                {
                    if (c == vowels[i])
                        vowelCount++;
                }
            }
            return vowelCount;
        }
        static int ConsonantCount(string sentence, int vowelCount, int count = 0)
        {
            foreach(char c in sentence)
            {
                if (c == ' ')
                    count++;
            }
            return sentence.Length - count - vowelCount;
        }
        static int PunctuationCount(string sentence, int punctuationCount = 0)
        {
            foreach(char c in sentence)
            {
                if (char.IsPunctuation(c))
                    punctuationCount++;
            }
            return punctuationCount;
        }
    }
}
