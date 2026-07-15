using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingAgeCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());

            if(age >= 17)
            {
                Console.WriteLine("You are old enough to drive.");
            }
            else if(age == 16)
            {
                Console.WriteLine("You'll be able to drive after your next birthday.");
            }
            else if((age > 0) && (age < 16))
            {
                Console.WriteLine("You aren't old enough to drive yet but you can in " + (17 - age) + " years.");
            }
            else
            {
                Console.WriteLine("Please enter a valid age.");
            }
            Console.ReadKey();
        }
    }
}
