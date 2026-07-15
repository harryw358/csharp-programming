using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDemo
{
    public class LawnMower : IMachine
    {
        public bool Start()
        {
            Console.WriteLine("Lawnmower started.");
            return true;
        }

        public bool Stop()
        {
            Console.WriteLine("Lownmower stopped.");
            return true;
        }
    }
}
