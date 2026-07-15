using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCases
{
    class Program
    {
        
        static void Main(string[] args)
        {
            double[] storageCasePrice = new double[11];
            int index = 0;
            for (int i = 0; i < storageCasePrice.Length; i++)
            {
                storageCasePrice[index] = 3.50 + (index * 0.82);
                index++;
            }
            Console.WriteLine("Storage case prices");
            string yesOrNo;
            do
            {
                int dividers = -1;
                do
                {
                    Console.Write("How many dividers do you require? (up to 10): ");
                    try
                    {
                        dividers = int.Parse(Console.ReadLine());
                        if ((dividers < 0) || (dividers > 10))
                        {
                            Console.WriteLine("Please enter a whole number between 0 and 10.");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a whole number between 0 and 10.");
                    }
                }
                while ((dividers < 0) || (dividers > 10));
                Console.WriteLine("That will cost " + storageCasePrice[dividers].ToString("C"));
                Console.Write("Do you want to find out another price? (Y/N): ");
                yesOrNo = Console.ReadLine();
            }
            while (yesOrNo.ToUpper() == "Y");
        }
    }
}
