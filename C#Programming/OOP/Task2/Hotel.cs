using System.Collections.Generic;

public class Hotel {
	private List<Room> rooms;
	
    public Hotel(List<Room> rooms) {
        this.rooms = rooms;
    }
    
    public List<Room> checkRooms() {
        return this.rooms;
    }
}