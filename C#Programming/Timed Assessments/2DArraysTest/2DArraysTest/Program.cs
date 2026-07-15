using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2DArraysTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0, rowTotal = 0, colTotal = 0;

            string file = File.ReadAllText(@"sales.txt");
            string[] delimited = file.Split(',');
            int[,] sales = new int[4, 4];

            for(int r = 0; r < 4; r++)
            {
                for(int c = 0; c < 4; c++)
                {
                    sales[r, c] = Convert.ToInt32(delimited[count]);
                    count++;
                }
            }

            Console.Write("             Branch1       Branch2       Branch3       Branch4");
            Console.WriteLine();
            for (int r = 0; r < 4; r++)
            {
                Console.Write("Quarter" + (r + 1));
                for(int c = 0; c < 4; c++)
                {
                    Console.Write("     {0:C2}", sales[r, c]);
                    rowTotal += sales[r, c];
                }
                Console.WriteLine();
            }
            Console.Write("Total   ");
            for(int c = 0; c < 4; c++)
            {
                for(int r = 0; r < 4; r++)
                {
                    colTotal += sales[r, c];
                }
                Console.Write("     {0:C2}", colTotal);
                colTotal = 0;
            }

            Console.Write("\n\nWhich branch do you want to see? ");
            int branchChoice = int.Parse(Console.ReadLine());
            DisplayBranch(branchChoice, sales);
            Console.ReadKey();
        }
        static void DisplayBranch(int branchChoice, int[,] sales)
        {
            Console.WriteLine();
            for(int r = 0; r < 4; r++)
            {
                Console.WriteLine("{0:C2}", sales[r, branchChoice - 1]);
            }
        }
    }
}
