using System;
using DifferentAnimals.Superclass;

namespace DifferentAnimals.Subsuperclasses
{
    public abstract class Mammal : Animal
    {
        public Mammal() : base()
        {
            skinType = "fur";
        }
        protected override void birth()
        {
            Console.WriteLine("This animal gives birth to live young.");
        }
    }
}