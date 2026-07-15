using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPprogram1
{
    class Car
    {
        private string colour;
        public Car(string colour)
        {
            this.colour = colour;
        }
        public string Describe()
        {
            return "This car is " + colour;
        }
        public string Colour
        {
            get { return colour; }
            set { colour = value; }
        }
    }
}
