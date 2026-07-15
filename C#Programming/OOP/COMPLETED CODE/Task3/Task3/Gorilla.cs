using System;

public class Gorilla : Mammal {
	public Gorilla() : base() {
        this.legs = 2;
        this.arms = 2;
	}

    override protected void move() {
        Console.WriteLine("This animal walks and climbs");
    }

    override protected void eat() {
        Console.WriteLine("This animal is a herbivore");
    }

    override public void getInfo() {
        Console.WriteLine("Gorilla:");
        base.getInfo();
        Console.WriteLine();
    }
}