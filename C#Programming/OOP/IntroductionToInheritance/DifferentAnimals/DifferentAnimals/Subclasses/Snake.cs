using System;
using DifferentAnimals.Subsuperclasses;

public class Snake : Reptile
{
    public Snake() : base()
    {

    }
    protected override void move()
    {
        Console.WriteLine("This animal slithers.");
    }
    protected override void eat()
    {
        Console.WriteLine("This animal is a carnivore.");
    }
    override public void getInfo()
    {
        Console.WriteLine("Snake:");
        base.getInfo();
        Console.WriteLine();
    }
}