using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a temperature: ");
            double temp = Convert.ToDouble(Console.ReadLine());
            
            Console.Write("Is this in Celsius or Fahrenheit? (C/F): ");
            string decision = Console.ReadLine();
            switch (decision.ToLower())
            {
                case "c":
                    temp = temp * 1.8 + 32;
                    Console.WriteLine("That would be " + temp + "°F.");
                    break;
                case "f":
                    temp = (temp - 32) / 1.8;
                    Console.WriteLine("That would be " + temp + "°C.");
                    break;
                default:
                    temp = 0;
                    break;
            }
            Console.ReadKey();
                    
        }
    }
}
