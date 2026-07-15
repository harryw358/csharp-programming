using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Harry W*/

            const double pi = 3.14;


            double area;
            int myAge;
            String myName;

            Console.Write("What is your name? ");

            myName = Console.ReadLine();

            Console.Write("What is your age? ");

            myAge = int.Parse(Console.ReadLine());

            area = (pi * pi * myAge);


            Console.WriteLine("Hello " + myName + ", you are " + myAge + " years old.");

            Console.WriteLine("A circle of " + myAge + " radius has an area of " + area);

            Console.ReadLine();
               
        }
    }
}
