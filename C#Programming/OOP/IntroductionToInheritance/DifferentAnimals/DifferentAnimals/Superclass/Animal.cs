using System;

namespace DifferentAnimals.Superclass
{
    public abstract class Animal
    {
        protected bool coldBlooded, tail;
        protected string skinType;
        protected int legs, arms, wings;

        public Animal()
        {
            coldBlooded = false;
            skinType = null;
            tail = false;
            legs = 0;
            arms = 0;
            wings = 0;
        }
        protected abstract void move();
        protected abstract void eat();
        protected abstract void birth();
        virtual public void getInfo()
        {
            if (coldBlooded)
            {
                Console.WriteLine("This animal is cold blooded.");
            }
            else
            {
                Console.WriteLine("This animal is warm blooded.");
            }
            if(skinType != null)
            {
                Console.WriteLine("This animal is covered in " + skinType);
            }
            if (tail)
            {
                Console.WriteLine("This animal has a tail.");
            }
            if(legs > 0)
            {
                Console.WriteLine("This animal has " + legs + " legs.");
            }
            if(arms > 0)
            {
                Console.WriteLine("This animal has " + arms + " arms.");
            }
            if(wings > 0)
            {
                Console.WriteLine("This animal has " + wings + " wings.");
            }
            move();
            eat();
            birth();
        }
    }
}
