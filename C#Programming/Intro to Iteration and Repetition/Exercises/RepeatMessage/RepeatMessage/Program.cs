using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string message;
            int number;

            Console.Write("Enter a message: ");
            message = Console.ReadLine();
            Console.Write("How many times do you want it to be displayed? ");
            try
            {
                number = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a whole number.");
                Console.Write("How many times do you want it to be displayed? ");
                number = int.Parse(Console.ReadLine());
            }
            for(int count = 0; count < number; count++)
            {
                Console.WriteLine(count + 1 + ". " + message);
            }
            Console.ReadKey();
        }
    }
}
