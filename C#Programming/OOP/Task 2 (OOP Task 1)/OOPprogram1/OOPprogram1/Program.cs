using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPprogram1
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Red");
            Console.WriteLine(car.Describe());

            Car car2 = new Car("Blue");
            car2.Colour = "Green";
            Console.WriteLine(car2.Describe());

            Console.ReadKey();
        }
    }
}
