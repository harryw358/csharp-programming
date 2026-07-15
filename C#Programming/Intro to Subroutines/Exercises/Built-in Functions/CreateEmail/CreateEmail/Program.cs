using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            string name, firstInitial, surname;
            int indexOfSpace, numOfSpaces = 0;

            Console.Write("Enter your full name: ");
            name = Console.ReadLine();

            foreach(char c in name)
            {
                if(c == ' ')
                {
                    numOfSpaces++;
                }
            }
            if (numOfSpaces > 1)
            {
                Console.WriteLine("Are you sure you have 2 spaces in your name?");
            }
            else if(numOfSpaces == 0)
            {
                Console.WriteLine("You should enter your full name.");
            }
            else
            {
                firstInitial = name.Substring(0, 1).ToLower();
                indexOfSpace = (name.IndexOf(' ')) + 1;
                surname = name.Substring(indexOfSpace).ToLower();

                Console.WriteLine("\nYour generated e-mail address is: " + firstInitial + "." + surname + "@mail.co.uk");
            }
            Console.ReadKey();
        }
    }
}
