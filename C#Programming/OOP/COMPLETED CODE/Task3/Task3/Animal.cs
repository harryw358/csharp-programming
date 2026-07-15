using System;

public abstract class Animal {
	//1 Mark for implementing the generic attributes that apply to all other classes
	protected bool coldBlooded;
	protected string skinType;
	protected bool tail;
	protected int legs;
	protected int arms;
	protected int wings;
	
    public Animal() {
        this.coldBlooded = false;
        this.skinType = null;
        this.tail = false;
        this.legs = 0;
        this.arms = 0;
        this.wings = 0;
    }
    
	//1 Mark for creating an abstract move method
    protected abstract void move();
    
	//1 Mark for creating an abstract eat method
    protected abstract void eat();
    
	//1 Mark for creating an abstract birth method
    protected abstract void birth();
    
	//1 Mark for implementing the generic aspects of getInfo that apply to all other classes
    virtual public void getInfo() {
        if (this.coldBlooded)
            Console.WriteLine("This animal is cold-blooded");
        else
            Console.WriteLine("This animal is warm-blooded");
        if (this.skinType != null)
            Console.WriteLine("This animal is covered in " + this.skinType);
        if (this.tail)
            Console.WriteLine("This animal has a tail");
        if (this.legs > 0)
            Console.WriteLine("This animal has " + this.legs + " legs");
        if (this.arms > 0)
            Console.WriteLine("This animal has " + this.arms + " arms");
        if (this.wings > 0)
            Console.WriteLine("This animal has " + this.wings + " wings");
        this.move();
        this.eat();
        this.birth();
    }
}