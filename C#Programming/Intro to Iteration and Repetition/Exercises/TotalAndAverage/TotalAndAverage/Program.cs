using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalAndAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            int number, total = 0, count = -1;
            double average;

            Console.WriteLine("Enter a series of whole numbers, 0 to stop: ");
            do
            {
                try
                {
                    number = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Whole numbers please.");
                    number = int.Parse(Console.ReadLine());
                }
                count++;
                total = total + number;
            }
            while (number != 0);

            average = Convert.ToDouble(total) / Convert.ToDouble(count);
            Console.WriteLine("The total of the numbers entered = " + total);
            Console.WriteLine("The average of the numbers entered (not including the 0) = " + Math.Round(average, 3));
            Console.ReadKey();
        }
        
    }
}
