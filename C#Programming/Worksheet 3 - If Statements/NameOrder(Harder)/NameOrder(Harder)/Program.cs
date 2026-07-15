using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameOrder_Harder_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Harry Wray - Ask for 3 names and display them in alphabetical order

            string name1, name2, name3;
            
            Console.Write("Enter the first name: ");
            name1 = Console.ReadLine();
            Console.Write("Enter the second name: ");
            name2 = Console.ReadLine();
            Console.Write("Enter the third name: ");
            name3 = Console.ReadLine();

            //name1, name2, name3
            if (string.Compare(name1, name2) < 0)
            {
                if(string.Compare(name2, name3) < 0)
                {
                    Console.WriteLine(name1 + name2 + name3);
                }
            }
            //name1, name3, name2
            if (string.Compare(name1, name2) < 0)
            {
                if(string.Compare(name3, name2) < 0)                 //this one BCA
                {
                    Console.WriteLine(name1 + name3 + name2);
                }
            }
            //name2, name1, name3
            if (string.Compare(name2, name1) < 0)
            {
                if(string.Compare(name1, name3) < 0)
                {
                    Console.WriteLine(name2 + name1 + name3);
                }
            }
            //name2, name3, name1
            if (string.Compare(name2, name3) < 0)
            {
                if(string.Compare(name3, name1) < 0)
                {
                    Console.WriteLine(name2 + name3 + name1);
                }
            }
            //name3, name1, name2
            if (string.Compare(name3, name1) < 0)
            {
                if (string.Compare(name1, name2) < 0)
                {
                    Console.WriteLine(name3 + name1 + name2);
                }
            }
            //name3, name2, name1
            if (string.Compare(name3, name2) < 0)
            {
                if (String.Compare(name2, name1) < 0)
                {
                    Console.WriteLine(name3 + name2 + name1);
                }
            }
            //names are equal
            if ((name1 == name2) || (name1 == name3) || (name2 == name3))
            {
                Console.WriteLine("The names have to be different.");
            }
               


            Console.ReadKey();
        }
    }
}
