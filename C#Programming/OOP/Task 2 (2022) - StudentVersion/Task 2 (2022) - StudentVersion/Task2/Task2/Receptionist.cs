using System;
using System.Collections.Generic;

public class Receptionist {
    private string name;
    
    public string Name { get => name; set => name = value; }
    
	public Receptionist(string name) {
        this.name = name;
	}

    public void checkIn(List<Room> hotel, Customer customer)
    {
        hotel[customer.RoomBooking - 1].addOccupant(customer);
        Console.WriteLine(name + " checked in " + customer.Name);
    }

    public void checkOut(List<Room> hotel, Customer customer, Manager manager)
    {
        hotel[customer.RoomBooking - 1].removeOccupant(customer);
        Console.WriteLine(name + " checked out " + customer.Name);
        manager.takeFeedback(customer);
    }


}