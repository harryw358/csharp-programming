using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinibusDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            //Harry Wray - Check for over 21 and passed driving test to drive a minibus

            int age;
            string passedDrivingTest;

            Console.Write("Enter your age: ");
            age = int.Parse(Console.ReadLine());

            Console.Write("Have you passed your driving test? (Y/N) ");
            passedDrivingTest = Console.ReadLine();

            if ((age > 21) && (passedDrivingTest == "Y"))
            {
                Console.WriteLine("You can drive the minibus.");
            }
            else
            {
                Console.WriteLine("You cannot drive the minibus.");
            }

            Console.ReadKey();
        }
    }
}
