using System.Collections.Generic;

public class Hotel {
    private List<Room> rooms;

    public List<Room> Rooms { get => rooms; set => rooms = value; }
	
    public Hotel(List<Room> rooms) {
        this.rooms = rooms;
    }
}