using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerated_Types
{
    class Program
    {
        enum days { Sun, Mon, Tue, Wed, Thu, Fri, Sat };
        static void Main(string[] args)
        {
            int x = (int)days.Wed;
            int y = (int)days.Sun;

            Console.WriteLine("Wednesday = {0}", x);
            Console.WriteLine("Sunday = {0}", y);

            Console.ReadKey();
        }
    }
}
// an enumerated type defines an ordered set of values; each has on ordinal value, starting at 0