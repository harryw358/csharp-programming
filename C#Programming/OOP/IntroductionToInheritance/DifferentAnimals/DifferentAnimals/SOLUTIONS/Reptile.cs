using System;

//1 Mark for inheriting from Animal	
public abstract class Reptile : Animal {
	//1 Mark for setting appropriate default values for attributes
    public Reptile() : base(){
        this.coldBlooded = true;
        this.skinType = "scales";
        this.legs = 4;
        this.tail = true;
    }
    
	//1 Mark for implementing birth for reptiles
    override protected void birth() {
        Console.WriteLine("This animal lays eggs");
    }
    
	//1 Mark for implementing hibernate for reptiles	 
    protected void hibernate() {
        Console.WriteLine("This animal hibernates");
    }
    
	//1 Mark for calling super method and adding call to hibernate
    override public void getInfo() {
        base.getInfo();
        this.hibernate();
    }
}