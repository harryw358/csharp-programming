using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatchProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bird Watch Program

            string[] birdName = new string[] { "robin", "blackbird", "pigeon", "magpie", "bluetit", "thrush", "wren", "starling" };
            int[] birdCount = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };

            Console.WriteLine("Please input name of bird, x to stop.");
            string bird = Console.ReadLine();
            while(bird != "x")
            {
                bool birdFound = false;
                for(int count = 1; count <= 8; count++)
                {
                    if(bird == birdName[count - 1])
                    {
                        birdFound = true;
                        Console.Write("Number observed: ");
                        int birdsObserved;
                        try
                        {
                            birdsObserved = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.Write("Number observed: ");
                            birdsObserved = int.Parse(Console.ReadLine());
                        }
                        birdCount[count - 1] = birdCount[count - 1] + birdsObserved;
                    }
                }
                if(birdFound == false)
                {
                    Console.WriteLine("Bird species not in array.");
                }
                Console.Write("Please enter name of bird: ");
                bird = Console.ReadLine();
            }
            Console.WriteLine(); 
            for (int count = 1; count <= 8; count++)
            {
                Console.WriteLine(birdName[count - 1] + " was observed " + birdCount[count - 1] + " times.");
            }
            Console.ReadKey();
        }
    }
}
