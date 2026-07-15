using System;

public class Cleaner {
	private string name;
	
    public Cleaner(string name) {
        this.name = name;
    }
    
	//1 Mark for implementing cleanRooms in the Cleaner class
	//1 Mark for appropriately changing how class attributes are accessed in cleanRooms
    public void cleanRooms(Hotel hotel) {
        for (int i = 0; i < hotel.checkRooms().Count; i++) {
        	Room room = hotel.checkRooms()[i];
            if (room.isEmpty()) {
                room.makeClean();
                Console.WriteLine(this.name + " cleaned Room " + room.getNumber());
        	}
        }
    }
}