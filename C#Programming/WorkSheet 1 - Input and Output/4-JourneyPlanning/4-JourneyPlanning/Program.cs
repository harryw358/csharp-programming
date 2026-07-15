using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_JourneyPlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            int startHours, hoursTaken, startMinutes, minutesTaken, finalHours, finalMinutes;

            Console.WriteLine("What was the start time of your journey?");
            Console.Write("Hours: ");
            startHours = int.Parse(Console.ReadLine());
            Console.Write("Minutes: ");
            startMinutes = int.Parse(Console.ReadLine());

            Console.WriteLine("How long did it take? ");
           
            Console.Write("Hours: ");
            hoursTaken = int.Parse(Console.ReadLine());
            
            Console.Write("Minutes: ");
            minutesTaken = int.Parse(Console.ReadLine());

            finalMinutes = (startMinutes + minutesTaken) % 60;
            finalHours = (startHours + hoursTaken) + ((finalMinutes + startMinutes) / 60);
            finalHours = finalHours % 12;


            if (finalMinutes < 10) 
            {
                Console.WriteLine("The finishing time is " + finalHours + ":0" + finalMinutes);
            }
            else
            {
                Console.WriteLine("The finishing time is " + finalHours + ":" + finalMinutes);
            }

            Console.ReadKey();
             // Console.WriteLine("The finishing time is " + finalHours + ":" + finalMinutes);
            // Console.ReadKey(); 





        }
    }
}
