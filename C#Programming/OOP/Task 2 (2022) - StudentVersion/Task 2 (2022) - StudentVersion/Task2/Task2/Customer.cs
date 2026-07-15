public class Customer {
    private int roomBooking;
    private string name;
    private int feedback;

    public int RoomBooking { get => roomBooking; set => roomBooking = value; }
    public string Name { get => name; set => name = value; }
    public int Feedback { get => feedback; set => feedback = value; }

    public Customer(int roomBooking, string name) {
        this.roomBooking = roomBooking;
        this.name = name;
        feedback = 0;
    } 	
}