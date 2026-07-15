using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCollections;

namespace Sets
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList set1 = new ArrayList ();
            int[] intialSet = { 3, 4, 5 };
            set1.Add(7);
            set1.AddRange(intialSet);
            set1.Add(2);

            if (set1.Contains(7))
            { Console.WriteLine("true"); }
            for (int i = 0; i <= 4; i++)
            { Console.WriteLine(set1[i]); }

            Console.ReadKey();
        }
    }
}
