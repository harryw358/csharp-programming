using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an amount of money: ");
            double money = Convert.ToDouble(Console.ReadLine());

            int twenties = Convert.ToInt32(money) / 20;
            money = money - twenties;
            int tens = Convert.ToInt32(money) / 10;
            money = money - tens;
            int fivers = Convert.ToInt32(money) / 5;
            money = money - fivers;
            int twoPoundCoins = Convert.ToInt32(money) / 2;
            money = money - twoPoundCoins;
            int onePoundCoins = Convert.ToInt32(money) / 1;
            money = money - onePoundCoins;

            Console.WriteLine("That would be: ");
            Console.WriteLine(twenties + " x £20");
            Console.WriteLine(tens + " x £10");
            Console.WriteLine(fivers + " x £5");
            Console.WriteLine(twoPoundCoins + " x £2");
            Console.WriteLine(onePoundCoins + " x £1");
            Console.WriteLine("That leaves £" + money + " change.");
            Console.ReadKey();
        }
    }
}

