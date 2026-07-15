using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            //takes a list of menu items from the user and adds spam to the end of every item

            Console.WriteLine("Enter a list of menu items, x to stop: ");
            int itemNumber = 0;
            string item;
            do
            {
                itemNumber++;
                Console.Write(itemNumber + ": ");
                item = Console.ReadLine();
            }
            while ((item != "x") && (item != "X"));
        }
    }
}
