using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplaySymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a symbol: ");
            char symbol = char.Parse(Console.ReadLine());
            Console.Write("How many times do you want to display this? ");
            int num = int.Parse(Console.ReadLine());

            _DisplaySymbols(num, symbol);

            Console.Write("\nEnter the length of the rectangle: ");
            int length = int.Parse(Console.ReadLine());
            Console.Write("Enter the width of the rectangle: ");
            int width = int.Parse(Console.ReadLine());

            DisplayRectangle(length, width, symbol);
            Console.ReadKey();
        }

        static void _DisplaySymbols(int num, char symbol)
        {
            for(int i = 0; i < num; i++)
            {
                Console.Write(symbol);
            }
        }

        static void DisplayRectangle(int width, int length, char symbol)
        {
            for(int j = 0; j < width; j++)
            {
                _DisplaySymbols(length, symbol);
                Console.WriteLine();
            }
        }
    }
}
