using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest
{
    public class Cylinder
    {
        protected int _height;
        protected int _radius;
        protected Circle _myCircle;
        public Circle MyCircle { get => _myCircle; }
        public Cylinder(int radius)
        {
            _height = 5;
            _radius = radius;
            _myCircle = new Circle(radius);
        }
        public double Area()
        {
            return (Math.Pow(_radius, 2) * Math.PI * _height);
        }
    }
}
