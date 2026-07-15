using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrienteeringEvent
{
    class Program
    {
        struct TCompetitor
        {
            public string Name;
            public int Time1, Time2, Time3, Time4;
        }
        static void Main(string[] args)
        {
            TCompetitor[] competitor = new TCompetitor[2];
            int i;

            i = 0;
            Console.WriteLine("Please enter the details of first Orienteerer");
            InputDetails(competitor, i);

            i = 1;
            Console.WriteLine("Please enter the details of second Orienteerer");
            InputDetails(competitor, i);

            DisplayDetails(competitor);
            Console.ReadKey();
        }
        static void InputDetails(TCompetitor[] competitor, int i)
        {
            Console.Write("Enter the name of Orienteerer: ");
            competitor[i].Name = Console.ReadLine();
            Console.Write("Enter time (mins) for leg 1: ");
            competitor[i].Time1 = int.Parse(Console.ReadLine());
            Console.Write("Enter time (mins) for leg 2: ");
            competitor[i].Time2 = int.Parse(Console.ReadLine());
            Console.Write("Enter time (mins) for leg 3: ");
            competitor[i].Time3 = int.Parse(Console.ReadLine());
            Console.Write("Enter time (mins) for leg 4: ");
            competitor[i].Time4 = int.Parse(Console.ReadLine());
        }
        static void DisplayDetails(TCompetitor[] competitor)
        {
            Console.WriteLine("Results for " + competitor[0].Name);
            Console.WriteLine("Leg")
        }
    }
}
