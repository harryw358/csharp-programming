using System;
using DifferentAnimals.Superclass;

namespace DifferentAnimals.Subsuperclasses
{
    public abstract class Reptile : Animal
    {
        public Reptile() : base()
        {
            coldBlooded = true;
            skinType = "scales";
            tail = true;
        }
        protected override void birth()
        {
            Console.WriteLine("This animal lays eggs.");
        }
    }
}