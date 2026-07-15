using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] birdName = new string[] { "robin", "blackbird", "pigeon", "magpie", "bluetit", "thrush", "wren", "starling" };

            string bird = Console.ReadLine();
            bool birdFound = false;
            int numSpecies = birdName.Length, birdIndex;
            for(int count = 1; count <= numSpecies; count++)
            {
                if(bird == birdName[count - 1])
                {
                    birdIndex = count;
                    birdFound = true;
                    Console.WriteLine("This bird is at position " + birdIndex + " in the array.");
                }
            }
            if(birdFound == false)
            {
                Console.WriteLine("Bird species not in array.");
            }
            Console.ReadKey();
        }
    }
}
