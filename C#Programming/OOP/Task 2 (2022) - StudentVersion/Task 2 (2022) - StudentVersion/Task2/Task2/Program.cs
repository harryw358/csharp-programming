using System;
using System.Collections.Generic;
    
public class Program {
	
	
	public static void Main() {
		Room room1 = new Room(1, 1, false);
		Room room2 = new Room(2, 2, false);
		Room room3 = new Room(3, 1, false);

		List<Room> hotel = new List<Room>();
		hotel.Add(room1);
		hotel.Add(room2);
		hotel.Add(room3);

		Customer customer1 = new Customer(1, "Mrs. White");
		Customer customer2 = new Customer(2, "Mr. Green");
		Customer customer3 = new Customer(2, "Miss. Scarlett");
		Customer customer4 = new Customer(3, "Mrs. Peacock");
		Customer customer5 = new Customer(2, "Prof. Plum");
		Customer customer6 = new Customer(3, "Col. Mustard");

		Receptionist receptionist = new Receptionist("Jane");
		Cleaner cleaner = new Cleaner("Michael");
		Manager manager = new Manager("Janhavi");

		receptionist.checkIn(hotel, customer1);
		receptionist.checkIn(hotel, customer2);
		receptionist.checkIn(hotel, customer3);
		receptionist.checkOut(hotel, customer1, manager);
 
		cleaner.cleanRooms(hotel);

        receptionist.checkIn(hotel, customer4);
		receptionist.checkOut(hotel, customer4, manager);
        receptionist.checkIn(hotel, customer5);
        receptionist.checkOut(hotel, customer5, manager);
        receptionist.checkOut(hotel, customer2, manager);
        receptionist.checkOut(hotel, customer3, manager);

        cleaner.cleanRooms(hotel);

        receptionist.checkIn(hotel, customer6);
        receptionist.checkOut(hotel, customer6, manager);
        Console.ReadLine();
    }
}