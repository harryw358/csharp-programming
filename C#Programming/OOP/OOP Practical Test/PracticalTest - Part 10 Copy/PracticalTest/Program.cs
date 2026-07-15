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
            Cylinder myCylinder = new Cylinder(3);
            Console.WriteLine(string.Format(myCylinder.MyCircle.Area().ToString("0.##")) + " metres squared");
            Console.WriteLine(string.Format(myCylinder.MyCircle.Circumference().ToString("0.00")) + " metres");
            Console.WriteLine("Volume of the cylinder " + string.Format(myCylinder.Area().ToString("0.00")));

            Console.ReadKey();
        }
    }
}
