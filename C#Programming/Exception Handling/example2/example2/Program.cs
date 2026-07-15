using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int value = 1 / int.Parse("0");
                Console.WriteLine(value);
            }
            catch ( Exception ex )
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // any cleanup code
            }
            Console.ReadLine();
        }
    }
}
