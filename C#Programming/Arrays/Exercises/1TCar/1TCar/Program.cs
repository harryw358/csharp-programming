using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1TCar
{
    class Program
    {
        struct TCar
        {
            public string Make, Model;
            public int EngineSize;
            public double Price;
        }
        static void Main(string[] args)
        {
            TCar[] car = new TCar[5];

            car[0].Make = "Ford";
            car[0].Model = "Fiesta";
            car[0].EngineSize = 1100;
            car[0].Price = 15912d;

            car[1].Make = "Toyota";
            car[1].Model = "Corolla";
            car[1].EngineSize = 1794;
            car[1].Price = 25843d;

            car[2].Make = "BMW";
            car[2].Model = "3 Series";
            car[2].EngineSize = 2000;
            car[2].Price = 29990d;

            car[3].Make = "Renault";
            car[3].Model = "Arkana";
            car[3].EngineSize = 1300;
            car[3].Price = 18300d;

            car[4].Make = "Audi";
            car[4].Model = "A3";
            car[4].EngineSize = 2000;
            car[4].Price = 25375d;

            for(int count = 0; count < car.Length; count++)
            {
                Console.Write(car[count].Make);
                Console.WriteLine(" " + car[count].Model);
                Console.WriteLine("Engine size: " + car[count].EngineSize + "cc");
                Console.WriteLine("Price: " + car[count].Price.ToString("C"));
                Console.WriteLine();
            }

            double totalPrice = 0;
            for(int count = 0; count < car.Length; count++)
            {
                totalPrice += car[count].Price;
            }
            double averagePrice = totalPrice / 5;
            int aboveAveragePrice = 0, belowAveragePrice = 0;
            Console.WriteLine("The average price of these cars is " + averagePrice.ToString("C"));
            Console.WriteLine();
            
            for(int count = 0; count < car.Length; count++)
            {
                if(car[count].Price < averagePrice)
                {
                    Console.WriteLine("The " + car[count].Make + " " + car[count].Model + " is below average price.");
                    belowAveragePrice++;
                }
                else if (car[count].Price > averagePrice)
                {
                    Console.WriteLine("The " + car[count].Make + " " + car[count].Model + " is above average price.");
                    aboveAveragePrice++;
                }
                else if (car[count].Price == averagePrice)
                {
                    Console.WriteLine("The " + car[count].Make + " " + car[count].Model + " is equal to the average price.");
                }
            }
            Console.WriteLine("There are " + aboveAveragePrice + " cars above average price, and " + belowAveragePrice + " below average price.");
            Console.ReadKey();
        }
    }
}
