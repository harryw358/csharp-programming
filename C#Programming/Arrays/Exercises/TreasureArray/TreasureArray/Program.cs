using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //creates and displays a 10x10 grid of 0s
            int[,] grid = new int[10, 10];
            for(int row = 0; row < 10; row++)
            {
                for(int col = 0; col < 10; col++)
                {
                    grid[row, col] = 0;
                    Console.Write(grid[row, col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("The treasure has been hidden!");
            Console.WriteLine();
            //displays the new grid containing the treasure (the 1)
            Random rnd = new Random();
            int rndRow = rnd.Next(10), rndCol = rnd.Next(10);
            grid[rndRow, rndCol] = 1;
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    Console.Write(grid[row, col] + " ");
                }
                Console.WriteLine();
            }
            //finds the coordinates of the treasure
            for(int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if(grid[x, y] == 1)
                    {
                        Console.WriteLine("The treasure is at column " + (y+1) + " and row " + (x+1));
                    } 
                }
            }
            Console.ReadKey();
        }
    }
}
