using System;
using DifferentAnimals.Subsuperclasses;

public class Gorilla : Mammal
{
    public Gorilla() : base()
    {
        legs = 2;
        arms = 2;
    }
    protected override void move()
    {
        Console.WriteLine("This animal walks and climbs.");
    }
    protected override void eat()
    {
        Console.WriteLine("This animal is an herbivoire.");
    }
    override public void getInfo()
    {
        Console.WriteLine("Gorilla:");
        base.getInfo();
        Console.WriteLine();
    }
}