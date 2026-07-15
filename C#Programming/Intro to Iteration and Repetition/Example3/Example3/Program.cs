using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            //FOREACH using an ArrayList data type

            ArrayList list = new ArrayList();
            list.Add("John Doe");
            list.Add("Jane Doe");
            list.Add("Someone Else");
            foreach (string name in list)
            {
                Console.WriteLine(name);
            }
            Console.ReadKey();
        }
    }
}
