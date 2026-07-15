using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YearsInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;

            Console.Write("Enter a year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter another year: ");
            int year2 = int.Parse(Console.ReadLine());

            if (year > year2)
            {
                Console.WriteLine("Year 2 must be bigger than year 1.");
            }
            else
            {
                for (int currentYear = year; currentYear <= year2; currentYear++)
                {
                    bool isRepeated = false;
                    for (int x = 0; x < currentYear.ToString().Length; x++)
                    {
                        //       currentYear.ToString()[x]; 
                        for (int y = 0; y < currentYear.ToString().Length; y++)
                        {
                            if (currentYear.ToString()[x] == currentYear.ToString()[y] && (x != y))
                                isRepeated = true;
                        }
                    }
                    if (isRepeated)
                    {
                        Console.WriteLine(currentYear);
                        count++;
                    }
                }
            }
            Console.WriteLine("There are " + count + " years that have a repeated digit.");
            Console.ReadKey();
        }
    }
}
