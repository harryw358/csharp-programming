using System;
using System.Collections.Generic;

public class Manager {
    private string name;

    public string Name { get => name; set => name = value; }

    public Manager(string name) {
        this.name = name;
    }

    public void takeFeedback(Customer customer)
    {
        if (customer.Feedback > 0)
            Console.WriteLine(name + " says: " + customer.Name + " was happy with their stay!");
        else if (customer.Feedback < 0)
            Console.WriteLine(name + " says: " + customer.Name + " was unhappy with their stay!");
        else
            Console.WriteLine(name + " says: " + customer.Name + " found their stay ok.");
    }
}