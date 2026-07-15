public abstract class Player {
	protected string colour;
	
    //1 Mark for defining a constructor for the class Player with appropriate attributes
    public Player(string colour){
        this.colour = colour;
    }
    
    //1 Mark for creating relevant accessor methods to access Player's private attributes
    public string getColour() {
        return this.colour;
    }
    
    //1 Mark for defining appropriate abstract method
    public abstract bool movePiece(Board board);
}