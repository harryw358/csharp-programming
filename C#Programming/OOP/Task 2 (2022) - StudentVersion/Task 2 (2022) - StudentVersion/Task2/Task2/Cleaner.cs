using System.Collections.Generic;
using System;

public class Cleaner {
    private string name;

    public string Name { get => name; set => name = value; }
    public Cleaner(string name) {
        this.name = name;
    }


    public void cleanRooms(List<Room> hotel)
    {
        for (int i = 0; i < hotel.Count; i++)
        {
            if (hotel[i].Occupants.Count == 0)
            {
                hotel[i].Clean = true;
                Console.WriteLine( name + " cleaned Room " + hotel[i].Number);
            }
        }
    }
}