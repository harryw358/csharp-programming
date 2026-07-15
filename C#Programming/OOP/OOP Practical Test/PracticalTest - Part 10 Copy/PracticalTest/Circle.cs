using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest
{
    public class Circle
    {
        protected int _radius;
        public int Radius { get => _radius; set => _radius = value; }

        public Circle(int radius)
        {
            _radius = radius;
        }
        public virtual double Area()
        {
            return (Math.PI * Math.Pow(_radius, 2));
        }
        public double Circumference()
        {
            return (Math.PI * _radius * 2);
        }
    }
}
