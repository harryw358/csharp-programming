using System;

public class Manager {
	private string name;
	
    public Manager(string name) {
        this.name = name;
    }
    
	//1 Mark for implementing takeFeedback in the Manager class
	//1 Mark for appropriately changing how class attributes are accessed in takeFeedback
    public void takeFeedback(Customer customer) {
        if (customer.getFeedback() > 0)
            Console.WriteLine(this.name + " says: " + customer.getName() + " was happy with their stay!");
        else if (customer.getFeedback() < 0)
            Console.WriteLine(this.name + " says: " + customer.getName() + " was unhappy with their stay!");
        else
            Console.WriteLine(this.name + " says: " + customer.getName() + " found their stay ok.");
    }
}