public class Bishop : Piece {
    private DiagonalMovement diagonal;
	
	public Bishop(string colour) : base(colour) {
        this.type = "bishop";
        this.diagonal = new DiagonalMovement();
	}
	
    //1 Mark for implementing the validMove method as described  
    override public bool validMove(Board board, int[] startPos, int[] endPos) {
        if (!base.validMove(board, startPos, endPos))
            return false;
        if (this.diagonal.validMove(this.colour, board, startPos, endPos, this.range))
            return true;
        return false;
    }
}