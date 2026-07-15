using System;

public class Otter : Mammal {
	public Otter() : base() {
        this.legs = 4;
        this.tail = true;
	}
	
    override protected void move() {
        Console.WriteLine("This animal walks and swims");
    }

    override protected void eat() {
        Console.WriteLine("This animal is an omnivore");
    }

    override public void getInfo() {
        Console.WriteLine("Otter:");
        base.getInfo();
        Console.WriteLine();
    }
}