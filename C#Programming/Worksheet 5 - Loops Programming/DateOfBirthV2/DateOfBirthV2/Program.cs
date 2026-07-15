using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateOfBirthV2
{
    class Program
    {
        static void Main(string[] args)
        {
            int year, month, day;

            Console.WriteLine("In this program you should enter your date of birth, entering the day, month and year separately when prompted.");

            do
            {
                Console.Write("Please enter the year you were born: ");
                year = int.Parse(Console.ReadLine());
            }
            while ((year > 1900) && (year < 2022));
            year = year + 0;
            do
            {
                Console.Write("Please enter the month you were born: ");
                month = int.Parse(Console.ReadLine());
            }
            while ((month > 0) && (month < 12));
            month = month + 0;
            do
            {
                Console.Write("Please enter the day you were born: ");
                day = int.Parse(Console.ReadLine());
            }
            while ((day > 0) && (day < 32));
            day = day + 0;
            Console.WriteLine("Your date of birth has been validated and is: " + day + "/" + month + "/" + year);
            Console.ReadKey();
            
        }
    }
}
