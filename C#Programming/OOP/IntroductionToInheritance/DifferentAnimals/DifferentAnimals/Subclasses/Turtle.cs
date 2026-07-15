using System;
using DifferentAnimals.Subsuperclasses;

public class Turtle : Reptile
{
    public Turtle() : base()
    {
        legs = 4;
    }
    protected override void move()
    {
        Console.WriteLine("This animal crawls and swims.");
    }
    protected override void eat()
    {
        Console.WriteLine("This animal is a omnivore.");
    }
    override public void getInfo()
    {
        Console.WriteLine("Turtle:");
        base.getInfo();
        Console.WriteLine();
    }
}