public class Rook : Piece {
    private StraightMovement straight;
    
	public Rook(string colour) : base(colour){
        this.type = "rook";
        this.straight = new StraightMovement();
	}
	
    //1 Mark for implementing the validMove method as described  
    override public bool validMove(Board board, int[] startPos, int[] endPos) {
        if (!base.validMove(board, startPos, endPos))
            return false;
        if (this.straight.validMove(this.colour, board, startPos, endPos, this.range))
            return true;
        return false;
    }
}