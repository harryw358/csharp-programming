using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionQuiz02
{
    class Program
    {
        static void Main(string[] args)
        {
            int rndNum = GenerateRndNum();
            Console.WriteLine(rndNum);
            Console.ReadKey();
        }
        static int GenerateRndNum()
        {
            Random rnd = new Random();
            return rnd.Next(1, 256);
        }
    }
}
