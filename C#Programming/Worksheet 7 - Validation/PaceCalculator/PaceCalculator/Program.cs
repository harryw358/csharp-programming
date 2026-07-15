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
            /*
                Instead of using try/catch, I used Int.TryParse. This means that the user can enter
                anything from the keyboard that is a string. Int.TryParse will return 1 if the user
                enters an integer, which is what we want. It will return 0 if it is not an integer, and
                the program will keep looping asking for a whole number while Int.TryParse returns 0.
            */

            string distance, timeTaken;
            int distanceResult = 0, timeTakenResult;
            double pace;

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
                Console.Write("Enter time taken in minutes: ");
                timeTaken = Console.ReadLine();
                int.TryParse(timeTaken, out timeTakenResult);
                if ((timeTakenResult == 0) || (Convert.ToDouble(timeTaken) < 1))
                {
                    Console.WriteLine("Please enter a whole number: ");
                }
            }
            while ((timeTakenResult == 0) || (Convert.ToDouble(timeTaken) < 1));

            pace = Convert.ToDouble(timeTaken) / Convert.ToDouble(distance);
            Console.WriteLine("Your current pace per mile is " + Math.Round(pace, 3) + " minutes to a mile.");

            Console.ReadKey();
        }
    }
}
