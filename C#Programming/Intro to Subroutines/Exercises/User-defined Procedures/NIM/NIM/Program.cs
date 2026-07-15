using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIM
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = EnterNumber();
            int[] randomCounters = RandomCounters(num);
            PrintArray(randomCounters);
            
            Console.ReadKey();
        }
        static int EnterNumber()
        {
            int num = 0;
            do
            {
                Console.Write("How many columns do you want to play with, up to 5: ");
                try
                {
                    num = int.Parse(Console.ReadLine());
                    if (num < 1 || num > 5)
                        throw new Exception();
                }
                catch
                {
                    Console.WriteLine("Please enter a whole number up to 5.");
                }
            }
            while (num < 1 || num > 5);
            return num;
        }
        static int[] RandomCounters(int num)
        {
            int[] randomCounters = new int[num];
            Random rnd = new Random();
            for(int i = 0; i < randomCounters.Length; i++)
            {
                randomCounters[i] = rnd.Next(1, 11);
            }
            return randomCounters;
        }
        static void PrintArray(int[] randomCounters)
        {
            Console.WriteLine();
            for (int j = 0; j < randomCounters.Length; j++)
            {
                Console.WriteLine("Column " + (j + 1) + " has " + randomCounters[j] + " counters.");
            }
        }
    }
}
