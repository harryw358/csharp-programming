using System;

public class Tortoise : Reptile {
    override protected void move() {
        Console.WriteLine("This animal walks");
    }

    override protected void eat() {
        Console.WriteLine("This animal is a herbivore");
    }
    
    override public void getInfo() {
        Console.WriteLine("Tortoise:");
        base.getInfo();
        Console.WriteLine();
	}
}