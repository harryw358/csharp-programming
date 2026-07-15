using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattingDecimalNumbersExample
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal Time, Distance, speed;
            Console.Write("How many miles have you run? ");
            Distance = decimal.Parse(Console.ReadLine());

            Console.Write("How many minutes did it take? ");
            Time = decimal.Parse(Console.ReadLine());

            speed = Distance / Time;
            speed = decimal.Round(speed, 2);

            Console.WriteLine("The pace of your run is " + speed + " miles per minute");
            Console.ReadKey();
        }
    }
}
