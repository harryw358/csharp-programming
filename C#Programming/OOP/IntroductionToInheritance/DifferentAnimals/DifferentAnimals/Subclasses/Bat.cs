using System;
using DifferentAnimals.Subsuperclasses;

public class Bat : Mammal
{
    public Bat() : base()
    {
        tail = true;
        legs = 2;
        wings = 2;
    }
    protected override void move()
    {
        Console.WriteLine("This animal flies.");
    }
    protected override void eat()
    {
        Console.WriteLine("This animal is an omnivore.");
    }
    override public void getInfo()
    {
        Console.WriteLine("Bat:");
        base.getInfo();
        Console.WriteLine();
    }
}