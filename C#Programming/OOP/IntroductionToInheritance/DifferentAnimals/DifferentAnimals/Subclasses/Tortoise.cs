using System;
using DifferentAnimals.Subsuperclasses;

public class Tortoise : Reptile
{
    public Tortoise() : base()
    {
        legs = 4;
    }
    protected override void move()
    {
        Console.WriteLine("This animal walks.");
    }
    protected override void eat()
    {
        Console.WriteLine("This animal is a herbivoire.");
    }
    override public void getInfo()
    {
        Console.WriteLine("Tortoise:");
        base.getInfo();
        Console.WriteLine();
    }
}