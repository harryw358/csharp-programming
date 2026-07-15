using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03CathedralTowns
{
    class Program
    {
        struct Town
        {
            public string Name, County;
            public int Population;
        }
        static void Main(string[] args)
        {
            Console.Write("How many cathedral towns would you like to enter? ");
            int num = int.Parse(Console.ReadLine());
            Town[] town = new Town[num];
            Console.WriteLine();
            for (int count = 0; count < num; count++)
            {
                Console.Write("Enter the name cathedral town " + (count + 1) + ": ");
                town[count].Name = Console.ReadLine();
                town[count].Population = 0;
                do
                {
                    Console.Write("What's the population of this town? ");
                    try
                    {
                        town[count].Population = int.Parse(Console.ReadLine());
                        if (town[count].Population < 1)
                            throw new Exception();
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a whole number.");
                    }
                }
                while (town[count].Population < 1);


                Console.Write("Which county is this in? ");
                town[count].County = Console.ReadLine();
                Console.WriteLine();
            }
            string county = " ";
            do
            {
                Console.Write("\nEnter the name of a county (STOP to end): ");
                county = Console.ReadLine();

                bool townsFound = false;
                if (county != "stop" && county != "STOP")
                {
                    Console.WriteLine("Cathedral Towns in " + county);
                    Console.WriteLine();
                    for (int count = 0; count < num; count++)
                    {
                        if (county == town[count].County)
                        {
                            Console.WriteLine("     " + town[count].Name + ", population " + town[count].Population);
                            townsFound = true;
                        }
                    }
                    if (townsFound == false)
                    {
                        Console.WriteLine("     There were no cathedral towns found in " + county);
                    }
                }
            }
            while (county.ToLower() != "stop");
        }
    }
}
