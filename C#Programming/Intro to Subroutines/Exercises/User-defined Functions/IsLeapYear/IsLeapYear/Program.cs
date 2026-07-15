using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsLeapYear
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a year: ");
            int year = int.Parse(Console.ReadLine());

            bool _IsLeapYear = IsLeapYear(year);
            if(_IsLeapYear == true)
            {
                Console.WriteLine("It is a leap year");
            }
            else
            {
                Console.WriteLine("It is not a leap year");
            }
            Console.ReadKey();
        }
        static bool IsLeapYear(int year)
        {
            if((year % 4 == 0) || (year % 400 == 0) && (year % 100 != 0))
            {
                return true;
            }
            return false;
        }
    }
}
