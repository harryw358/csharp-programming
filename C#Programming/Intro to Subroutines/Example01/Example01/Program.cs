using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example01
{
    class Program
    {
        static string numberString;                               
        static void Main(string[] args)
        {
            double number01 = 0, number02 = 0, sum = 0, average = 0;

            InputData(ref number01, ref number02);
            CalculateResults(number01, number02, ref sum, ref average);
            OutputResults(sum, average);
            KeepConsoleOpen();
        }
        static void InputData(ref double number01, ref double number02)
        {
            Console.Write("First number? ");
            numberString = Console.ReadLine();
            number01 = Convert.ToDouble(numberString);

            Console.Write("Second number? ");
            numberString = Console.ReadLine();
            number02 = Convert.ToDouble(numberString);
        }
        static void CalculateResults(double number01, double number02, ref double sum, ref double average)
        {
            sum = number01 + number02;
            average = sum / 2;
        }
        static void OutputResults(double sum, double average)
        {
            Console.WriteLine("Their sum is {0}", sum);
            Console.WriteLine("Their average is {0}", Math.Round(average, 3));
        }
        static void KeepConsoleOpen()
        {
            Console.ReadKey();
        }
    }
}
