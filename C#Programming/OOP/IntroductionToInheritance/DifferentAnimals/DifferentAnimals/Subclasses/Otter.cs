using System;
using DifferentAnimals.Subsuperclasses;

public class Otter : Mammal
{
    public Otter() : base()
    {
        tail = true;
        legs = 4;
    }
    protected override void move()
    {
        Console.WriteLine("This animal walks and swims.");
    }
    protected override void eat()
    {
        Console.WriteLine("This animal is an omnivore.");
    }
    override public void getInfo()
    {
        Console.WriteLine("Otter:");
        base.getInfo();
        Console.WriteLine();
    }
}