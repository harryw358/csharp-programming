using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4SwitchCaseStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            //Harry Wray - Case/Switch Statement
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Do you enjoy C#? (yes/ no /maybe / a bit)");
            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "yes":
                    Console.WriteLine("Great!");
                    break;
                case "maybe":
                case "a bit":
                    Console.WriteLine("Well okay");
                    break;
                case "no":
                    Console.WriteLine("Too bad!");
                    break;
                default:
                    Console.WriteLine("I don't understand that!");
                    break;
            }

            Console.ReadKey();
        }
    }
}
