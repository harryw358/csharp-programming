using System;

public class Snake : Reptile {
	public Snake() : base() {
        this.legs = 0;
    }

    override protected void move() {
        Console.WriteLine("This animal slithers");
    }

    override protected void eat() {
        Console.WriteLine("This animal is a carnivore");
    }

    override public void getInfo() {
        Console.WriteLine("Snake:");
        base.getInfo();
        Console.WriteLine();
    }
}