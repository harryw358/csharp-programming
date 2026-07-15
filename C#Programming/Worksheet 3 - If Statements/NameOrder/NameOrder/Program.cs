using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            string name1, name2, name3;
            
            Console.Write("Enter the first name: ");
            name1 = Console.ReadLine();
            Console.Write("Enter the second name: ");
            name2 = Console.ReadLine();
            Console.Write("Enter the third name: ");
            name3 = Console.ReadLine();
            
            if ((name1 == name2) || (name1 == name3) || (name2 == name3))
            {
                Console.WriteLine("All 3 names must be different.");
            }
            else if (string.Compare(name1, name2) < 0)
            {
                if (string.Compare(name1, name3) < 0)
                {
                    //name1, name2, name3
                    Console.WriteLine(name1 + name2 + name3);
                }
                else
                {
                    //name3, name1, name2
                    Console.WriteLine(name3 + name1 + name2);
                }
            }
            else
            {
                if (string.Compare(name1, name3) < 0)
                {
                    //name2, name1, name3
                    Console.WriteLine(name2 + name1 + name3);
                }
                else
                {
                    //name2, name3, name1
                    Console.WriteLine(name2 + name3 + name1);
                }
            }
            Console.ReadKey();
        
    }
    }
}
