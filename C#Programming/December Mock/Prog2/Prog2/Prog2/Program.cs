using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[4] { "Ben", "Thor", "Zoe", "Kate" };

            int max = 3, current = 0;
            bool found = false;
            Console.Write("What player are you looking for? ");
            string playerName = Console.ReadLine();

            while (found == false && current <= max)
            {
                if(names[current] == playerName)
                {
                    found = true;
                }
                else
                {
                    current++;
                }
            }
            if(found == true)
            {
                Console.WriteLine("Yes, they have a top score.");
            }
            else
            {
                Console.WriteLine("No, they do not have a top score.");
            }
            Console.ReadKey();
        }
    }
}
