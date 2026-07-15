using System.Collections.Generic;
using System;


public class Room {
	private int number;
    private int size;
    private List<Customer> occupants;
    private bool clean;
    
    public int Number { get => number; set => number = value; }
    public int Size { get => size; set => size = value; }
    public List<Customer> Occupants { get => occupants; set => occupants = value; }
    public bool Clean { get => clean; set => clean = value; }
	
    public Room(int number, int size, bool clean) {
        this.number = number;
        this.size = size;
        occupants = new List<Customer>();
        this.clean = clean;
    }

    public void addOccupant(Customer occupantIn)
    {
        if (occupants.Count < size)
        {
            occupants.Add(occupantIn);
            occupantIn.Feedback++;
        }
        else
        {
            occupantIn.Feedback--;
            return;
        }
        if (clean == true)
            occupantIn.Feedback++;
        else
            occupantIn.Feedback--;
            clean = false;
    }

    public void removeOccupant(Customer occupantOut)
    {
        int index = -1;
        for (int i = 0; i < occupants.Count; i++)
        {
            if (string.Equals(occupants[i], occupantOut))
                index = i;
        }
        if (index != -1)
            occupants.RemoveAt(index);
    }
}