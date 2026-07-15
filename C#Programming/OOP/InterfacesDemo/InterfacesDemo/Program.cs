using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var car = new Car();
            var mower = new LawnMower();

            // driven consistency across 2 objects
            // that would not really inherit from
            // the same base class

            // objects do not have to be related 
            // through inheritance
        }
    }
}
