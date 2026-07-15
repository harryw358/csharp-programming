//1 Mark for defining constructors for all of the child classes of Piece with appropriate attributes
/*1 Mark for adding relevant movement classes (if any are needed) to all of the child classes of
Piece to make composite classes*/
public class Piece {
	protected string colour;
	protected string type;
	protected int range;
	protected BasicMovement basic;
	
    //1 Mark for defining a constructor for the class Piece with appropriate attributes
    public Piece(string colour) {
        this.colour = colour;
        this.type = null;
        this.range = 7;
        this.basic = new BasicMovement();
	}

    //1 Mark for creating relevant accessor methods to access Piece's private attributes    
    public string getType() {
        return this.type;
    }
    
    public string getColour() {
        return this.colour;
    }
    
    //1 Mark for implementing the validMove method as described (ETO)
    virtual public bool validMove(Board board, int[] startPos, int[] endPos) {
        if (this.basic.validMove(this.colour, board, startPos, endPos))
            return true;
        else
            return false;
    }
}