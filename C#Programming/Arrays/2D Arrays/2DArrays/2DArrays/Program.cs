using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //an array with 5 rows and 2 columns
            int[,] myArray = new int[5, 2]
            {
                {0, 0},
                {1, 2},
                {2, 4},
                {3, 6},
                {4, 8}
            };

            //output each array elements value
            for(int r = 0; r < 5; r++)
            {
                for(int c = 0; c < 2; c++)
                {
                    Console.Write(myArray[r, c]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
