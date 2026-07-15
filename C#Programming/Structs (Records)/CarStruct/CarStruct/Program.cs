using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStruct
{
    class Program
    {
        struct Car
        {
            public string Brand;
            public string Model;
            public int Year;
            public float Price;
        }
        struct Employee
        {
            public string FirstName;
            public string LastName;
            public float HourlyWage;
            public bool CompletedTraining;
        }


        static void Main(string[] args)
        {
            Car car1;

            Console.Write("What's the brand? ");
            car1.Brand = Console.ReadLine();

            Console.Write("What's the model? ");
            car1.Model = Console.ReadLine();

            Console.Write("What's the year? ");
            car1.Year = int.Parse(Console.ReadLine());

            Console.Write("What's the price? ");
            car1.Price = float.Parse(Console.ReadLine());

            //What they are
            // * custom data type 
            //Example Car
            // * Brand  - string
            // * Model - string
            // * Year - int
            // * Price - float

            Employee employee1;
            employee1.FirstName = "Nicholas";
            employee1.LastName = "Dingle";
            employee1.HourlyWage = 35.7f;
            employee1.CompletedTraining = true; 
        }
    }
}
