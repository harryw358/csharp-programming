public class King : Piece {
	private StraightMovement straight;
	private DiagonalMovement diagonal;
	
	public King(string colour) : base(colour){
        this.type = "King";
        this.range = 1;
        this.straight = new StraightMovement();
        this.diagonal = new DiagonalMovement();
	}
	
    //1 Mark for implementing the validMove method as described    
    override public bool validMove(Board board, int[] startPos, int[] endPos) {
        if (!base.validMove(board, startPos, endPos))
            return false;
        if (this.straight.validMove(this.colour, board, startPos, endPos, this.range))
            return true;
        else if (this.diagonal.validMove(this.colour, board, startPos, endPos, this.range))
            return true;
        return false;
    }
}