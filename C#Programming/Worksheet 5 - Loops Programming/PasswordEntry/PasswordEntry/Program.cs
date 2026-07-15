using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordEntry
{
    class Program
    {
        static void Main(string[] args)
        {
            string password;

            Console.Write("Enter the password: ");
            password = Console.ReadLine();

            if (password == "secret")
            {
                Console.WriteLine("You are in!");
            }
            else
            {
                while (password != "secret")
                {
                    Console.WriteLine("Please try again.");
                    Console.Write("Enter the password: ");
                    password = Console.ReadLine();
                    if(password == "secret")
                    {
                        Console.WriteLine("You are in!");
                    }
                }
            }

            Console.ReadKey();
            
        }
    }
}
