using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramString2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Harry W */
            /* using + to join 2 input strings*/

            string foreName, surName, fullName;

            Console.Write("Enter your first name: ");
            foreName = Console.ReadLine();

            Console.Write("Enter your surname: ");
            surName = Console.ReadLine();

            fullName = foreName + " " + surName;
            Console.WriteLine("Your full name is: " + fullName);

            Console.ReadKey();
        }
    }
}
