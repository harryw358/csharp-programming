using System;
using System.Threading;
using WarriorWars.Enum;

namespace WarriorWars
{
    class EntryPoint
    {
        static Random rng = new Random();
        static void Main()
        {

            Warrior goodGuy = new Warrior("Bob", Faction.Goodguy);
            Warrior badGuy = new Warrior("Joe", Faction.Badguy);

            Fight(goodGuy, badGuy);
        }

        private static void Fight(Warrior goodGuy, Warrior badGuy) // ctrl + R + M extracts as method.
        {
            while (goodGuy.IsAlive && badGuy.IsAlive)
            {
                if (rng.Next(0, 10) < 5)
                {
                    goodGuy.Attack(badGuy);
                }
                else
                {
                    badGuy.Attack(goodGuy);
                }

                Thread.Sleep(200);
            }
        }
    }
}
