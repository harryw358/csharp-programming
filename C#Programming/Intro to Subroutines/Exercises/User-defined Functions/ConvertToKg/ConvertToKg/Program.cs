using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToKg
{
    class Program
    {
        static void Main(string[] args)
        {
            double pounds;

            Console.Write("Enter the weight in pounds: ");
            pounds = double.Parse(Console.ReadLine());

            Console.Write("That is " + Math.Round(ConvertToKg(pounds), 2) + "kg");
            Console.ReadKey();
        }
        static double ConvertToKg(double pounds)
        {
            return pounds /= 2.2;
        }
    }
}
