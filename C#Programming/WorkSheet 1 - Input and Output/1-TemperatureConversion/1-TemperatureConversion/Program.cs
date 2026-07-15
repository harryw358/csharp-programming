using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_TemperatureConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            double f;
            double c;

            Console.Write("Enter the temperature in Fahrenheit: ");
            f = double.Parse(Console.ReadLine()); // allows the user to enter text into the console and stores inside f ,
                                                  // double.Parse checks that the data entered is a double //

            c = 5 * (f - 32) / 9;

            Console.WriteLine(f + " degrees fahrenheit is " + c + " degrees celsius");
            Console.ReadKey();
        }
    }
}
 