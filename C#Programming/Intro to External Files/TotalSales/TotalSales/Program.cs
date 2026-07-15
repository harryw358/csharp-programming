using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TotalSales
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = File.ReadAllText("D:/CS/C#Y1Programming/Intro to External Files/TotalSales/sales.txt");
            int[,] sales = new int[5, 3];
            int count = 0, rowTotal = 0, colTotal = 0;

            //move data into delimited array
            string[] delimited = file.Split(',');

            //move file into 2D array
            for(int r = 0; r < 5; r++)
            {
                for(int c  = 0; c < 3; c++)
                {
                    sales[r, c] = Convert.ToInt32(delimited[count]);
                    count++;
                }
            }

            //display the data in tabular format with totals for rows and columns
            Console.WriteLine("            Employee1    Employee2    Employee3          Total Sales Per Product");
            for (int r = 0; r < 5; r++)
            {
                Console.Write("Product{0:N0}", r + 1);
                for (int c = 0; c < 3; c++)
                {
                    Console.Write("    {0:C2}", sales[r, c]);
                    rowTotal += sales[r, c];
                }
                Console.Write("          {0:C2}", rowTotal);
                rowTotal = 0;
                Console.WriteLine();
            }

            //calculate column totals
            Console.WriteLine("Total per");
            Console.Write("Employee");
            for(int c = 0; c < 3; c++)
            {
                for(int r = 0; r < 5; r++)
                {
                    colTotal += sales[r, c];
                }
                Console.Write("    {0:C2}", colTotal);
                colTotal = 0;
            }

            Console.ReadKey();
        }
    }
}
