using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100thBirthday
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Harry W */

            string name;
            int age, currentYear, howManyYears, endYear;

            Console.Write("Enter your name: ");
            name = Console.ReadLine();

            Console.Write("Enter your age: ");
            age = int.Parse(Console.ReadLine());

            Console.Write("Enter the current year: ");
            currentYear = int.Parse(Console.ReadLine());

            howManyYears = (100 - age);
            endYear = (currentYear + howManyYears);

            Console.WriteLine("Nice to meet you " + name);
            Console.WriteLine("In the year " + endYear + " you will be 100 years old");

            Console.ReadKey();



        }
    }
}
