using System;

//1 Mark for inheriting from Animal	  
public abstract class Mammal : Animal {
    //1 Mark for setting appropriate default values for attributes
    public Mammal() : base() {
        this.skinType = "fur";
    }
    
	//1 Mark for implementing birth for mammals
    override protected void birth() {
        Console.WriteLine("This animal gives birth to live young");
    }
}