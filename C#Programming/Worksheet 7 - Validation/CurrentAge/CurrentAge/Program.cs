using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("In this program you should enter your date of birth, entering the day month and year separately when prompted.");
            int year = 0;
             Console.Write("Please enter the year you were born: ");
             try
             {
                 year = int.Parse(Console.ReadLine());
             }
             catch
             {
                 Console.WriteLine("I don't think that can be possible. It needs to be in YYYY. Please try again.");
               
             }
             if ((year >= 2022) || (year < 1900))
             {
                 do
                 {
                     Console.WriteLine("I don't think that can be possible. Please try again.");
                     try
                     {
                         year = int.Parse(Console.ReadLine());
                     }
                     catch
                     {
                         Console.WriteLine("I don't think that can be possible. It needs to be in YYYY. Please try again.");
                     }
                 }
                 while ((year >= 2022) || (year < 1900));
             }

             int month = 0;
             Console.Write("Please enter the month you were born: ");
             try
             {
                 month = int.Parse(Console.ReadLine());
             }
             catch
             {
                 Console.WriteLine("I don't think that can be possible. It needs to be in MM. Please try again.");
             }
             if ((month > 12) || (month < 1))
             {
                 do
                 {
                     Console.WriteLine("I don't think that can be possible. Please try again.");
                     try
                     {
                         month = int.Parse(Console.ReadLine());
                     }
                     catch
                     {
                         Console.WriteLine("I don't think that can be possible. It needs to be in MM. Please try again.");
                     }
                 }
                 while ((month > 12) || (month < 1));
             }

             int day = 0;
             Console.Write("Please enter the day you were born: ");
             try
             {
                 day = int.Parse(Console.ReadLine());
             }
             catch
             {
                 Console.WriteLine("I don't think that can be possible. It needs to be in DD. Please try again.");
       
             }
             if ((day > 31) || (day < 1))
             {
                 do
                 {
                     Console.WriteLine("I don't think that can be possible. Please try again.");
                     try
                     {
                         day = int.Parse(Console.ReadLine());
                     }
                     catch
                     {
                         Console.WriteLine("I don't think that can be possible. It needs to be in DD. Please try again.");
                     }
                 }
                 while ((day > 31)  || (day < 1));
             }

             string birthday = day + "/" + month + "/" + year;

             Console.WriteLine("Your date of birth has been validated and is: " + birthday);
             Console.ReadKey();
        }
        
    }
}
