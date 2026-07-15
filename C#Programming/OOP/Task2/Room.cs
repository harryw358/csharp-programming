using System.Collections.Generic;

public class Room {
	private int number;
	private int size;
	private List<Customer> occupants;
	private bool clean;
	
    public Room(int number, int size, bool clean) {
        this.number = number;
        this.size = size;
        this.occupants = new List<Customer>();
        this.clean = clean;
    }
    
	//1 Mark for implementing addOccupant in the Room class
	//1 Mark for appropriately changing how class attributes are accessed in addOccupant
    public void addOccupant(Customer occupantIn) {
        if (this.occupants.Count < this.size) {
            this.occupants.Add(occupantIn);
            occupantIn.positiveExperience();
        }
        else {
            occupantIn.negativeExperience();
            return;
        }
        if (this.clean == true)
            occupantIn.positiveExperience();
        else
            occupantIn.negativeExperience();
        this.clean = false;
    }
    
	//1 Mark for implementing removeOccupant in the Room class
	//1 Mark for appropriately changing how class attributes are accessed in removeOccupant
    public void removeOccupant(Customer occupantOut) {
        int index = -1;
        for (int i = 0; i < this.occupants.Count; i++) {
            if (string.Equals(occupantOut.getName(), this.occupants[i].getName()))
                index = i;
        }
        if (index != -1)
            this.occupants.RemoveAt(index);
    }
    
	/*1 Mark for creating accessors and mutators (or equivalent methods) to pass access the values of the Room class' 
	private attributes outside of the Room class*/
    public int getNumber() {
        return this.number;
    }
    
    public bool isEmpty() {
        if (this.occupants.Count == 0)
            return true;
        else
            return false;
    }

    public void makeClean() {
        this.clean = true;
    }
}