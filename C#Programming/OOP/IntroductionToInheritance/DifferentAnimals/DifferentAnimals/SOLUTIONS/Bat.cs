//1 Mark for avoiding code repetition in Bat, Gorilla, Otter, Snake, Tortoise and Turtle
//1 Mark for implementing move and eat in Bat, Gorilla, Otter, Snake, Tortoise and Turtle
//1 Mark for inheriting the appropriate parent class in Bat, Gorilla, Otter, Snake, Tortoise and Turtle

using System;

public class Bat : Mammal {
	public Bat( ) : base() {
        this.legs = 2;
        this.tail = true;
        this.wings = 2;
	}
	
	override protected void move() {
        Console.WriteLine("This animal flies");
    }
    
	override protected void eat() {
        Console.WriteLine("This animal is an omnivore");
	}
	
	//1 Mark for adding hibernate in Bat
	protected void hibernate() {
        Console.WriteLine("This animal hibernates");
	}
	
    override public void getInfo() {
        Console.WriteLine("Bat:");
        base.getInfo();
        this.hibernate();
        Console.WriteLine();
    }
}