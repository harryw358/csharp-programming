using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle myCircle = new Circle(5);

            Console.WriteLine(string.Format(myCircle.Area().ToString("0.##")) + " metres squared");
            Console.WriteLine(string.Format(myCircle.Circumference().ToString("0.00")) + " metres");

            Cylinder myCylinder = new Cylinder(3);
            Console.WriteLine("Volume of the cylinder " + string.Format(myCylinder.Area().ToString("0.00")));

            Console.ReadKey();
        }
    }
}
