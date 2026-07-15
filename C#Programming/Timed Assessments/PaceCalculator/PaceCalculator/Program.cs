using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string distance, timeTaken;
            int distanceResult, timeTakenResult;

            Console.WriteLine("Runners' Pace Calculator");
            Console.WriteLine("This program will calculate your pace per mile");
            Console.WriteLine();

            do
            {
                Console.Write("Enter the distance you ran in miles: ");
                distance = Console.ReadLine();
                int.TryParse(distance, out distanceResult);
                if ((distanceResult == 0) || (Convert.ToDouble(distance) < 1))
                {
                    Console.WriteLine("Please enter a whole number");
                }
            }
            while ((distanceResult == 0) || (Convert.ToDouble(distance) < 1));
            do
            {
                Console.Write("Enter the time taken in minutes: ");
                timeTaken = Console.ReadLine();
                int.TryParse(timeTaken, out timeTakenResult);
                if ((timeTakenResult == 0) || (Convert.ToDouble(timeTaken) < 1))
                {
                    Console.WriteLine("Please enter a whole number");
                }
            }
            while ((timeTakenResult == 0) || (Convert.ToDouble(timeTaken) < 1));

            double pace = Convert.ToDouble(timeTaken) / Convert.ToDouble(distance);
            Console.WriteLine("Your current pace per mile is " + Math.Round(pace, 3) + " minutes to a mile.");
            Console.ReadKey();
        }
    }
}
