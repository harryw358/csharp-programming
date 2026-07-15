using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a message: ");
            string message = Console.ReadLine();

            Console.Write("Enter the secret key: ");
            int secretKey;
            try
            {
                secretKey = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a whole number.");
                secretKey = int.Parse(Console.ReadLine());
            }

            Console.Write("Do you want to encrypt or decrypt this message? (e/d): ");
            string choice = Console.ReadLine();
            switch (choice.ToLower())
            {
                case "e":
                    foreach(char character in message)
                        {
                            if(character == ' ')
                            {
                                continue;
                            }
                            Console.Write((char)(character + secretKey));
                        }
                    break;
                case "d":
                    foreach (char character in message)
                    {
                        if (character == ' ')
                        {
                            continue;
                        }
                        Console.Write((char)(character - secretKey));
                    }
                    break;
            }
            Console.ReadKey();
        }
    }
}
