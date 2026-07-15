using System;

public class Turtle : Reptile {
    override protected void move() {
        Console.WriteLine("This animal crawls and swims");
    }
    
    override protected void eat() {
        Console.WriteLine("This animal is an omnivore");
    }
    
    override public void getInfo() {
        Console.WriteLine("Turtle:");
        base.getInfo();
        Console.WriteLine();
    }
}