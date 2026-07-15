using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ISBN = new int[13];
            int count;
            for (count = 0; count < 13; count++)
            {
                Console.Write("Please enter next digit of ISBN: ");
                ISBN[count] = int.Parse(Console.ReadLine());
            }
            int calculatedDigit = 0;
            count = 0;
            while (count < 13)
            {
                calculatedDigit += ISBN[count];
                count++;
                calculatedDigit += ISBN[count] * 3;
                count++;
            }
            while (calculatedDigit >= 10)
            {
                calculatedDigit -= 10;
            }
            calculatedDigit = 10 - calculatedDigit;
            if (calculatedDigit == 10)
            {
                calculatedDigit = 0;
            }
            if (calculatedDigit == ISBN[12])
            {
                Console.WriteLine("Valid ISBN");
            }
            else
            {
                Console.WriteLine("Invalid ISBN");
            }
            Console.ReadKey();
        }
    }
}
