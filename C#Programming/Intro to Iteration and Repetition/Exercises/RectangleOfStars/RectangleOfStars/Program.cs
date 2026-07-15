using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int stars, rows, starCount = 0, rowCount = 0;

            Console.Write("How many stars would you like in a row? ");
            try
            {
                stars = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a whole number.");
                Console.Write("How many stars would you like in a row? ");
                stars = int.Parse(Console.ReadLine());
            }
            Console.Write("How many rows would you like to see? ");
            try
            {
                rows = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a whole number.");
                Console.Write("How many rows would you like to see? ");
                rows = int.Parse(Console.ReadLine());
            }

            while (rowCount < rows)
            {
                while (starCount < stars)
                {
                    Console.Write('*');
                    starCount++;
                }
                rowCount++;
                starCount = 0;
                Console.WriteLine();
            }



            Console.ReadKey();
        }
    }
}
