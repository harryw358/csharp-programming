using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cylinders
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Harry W */

            const double pi = 3.1415926;
            double height, radius, volume, surfaceArea;

            Console.Write("Enter the radius of the cylinder: ");
            radius = double.Parse(Console.ReadLine());

            Console.Write("Enter the height of the cylinder: ");
            height = double.Parse(Console.ReadLine());

            volume = pi * radius * radius * height;
            volume = Math.Round(volume, 4);

            surfaceArea = 2 * pi * radius * (radius + height);
            surfaceArea = Math.Round(surfaceArea, 4);

            Console.WriteLine("The volume of the cylinder is " + volume);
            Console.WriteLine("The surface area of the cylinder is " + surfaceArea);

            Console.ReadKey();

            

        }
    }
}
