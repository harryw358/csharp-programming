using System;

public class Receptionist {
    private string name;
    
	public Receptionist(string name) {
        this.name = name;
	}
	
	//1 Mark for implementing checkIn in the Receptionist class
	//1 Mark for appropriately changing how class attributes are accessed in checkIn
    public void checkIn(Hotel hotel, Customer customer) {
        Room room = hotel.checkRooms()[customer.getRoom() - 1];
        room.addOccupant(customer);
        Console.WriteLine(this.name + " checked in " + customer.getName());
    }
    
	//1 Mark for implementing checkOut in the Receptionist class
	//1 Mark for appropriately changing how class attributes are accessed in checkOut
    public void checkOut(Hotel hotel, Customer customer, Manager manager) {
        Room room = hotel.checkRooms()[customer.getRoom() - 1];
        room.removeOccupant(customer);
        Console.WriteLine(this.name + " checked out " + customer.getName());
        manager.takeFeedback(customer);
    }
}