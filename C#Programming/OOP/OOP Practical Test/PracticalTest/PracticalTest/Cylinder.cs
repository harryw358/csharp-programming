using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest
{
    public class Cylinder : Circle
    {
        protected int _height;
        public Cylinder(int _radius) : base(_radius)
        {
            _height = 5;
        }
        public override double Area()
        {
            return (Math.Pow(_radius, 2) * Math.PI * _height);
        }
    }
}
