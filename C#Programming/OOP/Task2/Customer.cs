public class Customer {
	private int roomBooking;
	private string name;
	private int feedback;
	
    public Customer(int roomBooking, string name) {
        this.roomBooking = roomBooking;
        this.name = name;
        this.feedback = 0;
    }
    
	//1 Mark for creating mutators to change the value of feedback from outside the Customer class
    public void positiveExperience() {
        this.feedback += 1;
	}
    
    public void negativeExperience() {
        this.feedback -= 1;
    }
    
	//1 Mark for creating accessors to pass the values of the Customer class' private attributes outside of the Customer class
    public int getFeedback() {
        return this.feedback;
    }
    
    public int getRoom() {
        return this.roomBooking;
    }
    
    public string getName() {
        return this.name;
    }
}