using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VATPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Harry W - VAT @ 17.5% for adults

            //declaring variables needed
            double price;
            char adultOrChild;

            //asks for price of clothing and is it for adult or child
            Console.Write("What's the price of the clothing? ");
            price = double.Parse(Console.ReadLine());
            Console.Write("Is it for an adult or child? (A/C) ");
            adultOrChild = char.Parse(Console.ReadLine());

            //processes the price of the clothing depending on what was entered
            if (adultOrChild == 'A')
            {
                price = price * 1.175;
                Console.WriteLine("The price of the clothing is " + price.ToString("C"));   //.ToString("C") formats
            }                                                                               //the price as GBP (£x.xx)
            else if (adultOrChild == 'C')   
            {
                price = price * 1;
                Console.WriteLine("The price of the clothing is " + price.ToString("C"));
            }
            else
            {
                Console.WriteLine("Sorry, I don't understand.");
            }
            Console.ReadKey();
        }
    }
}
