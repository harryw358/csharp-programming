public class Pawn : Piece {
	private StraightMovement straight;
	private DiagonalMovement diagonal;
	
	public Pawn(string colour) : base(colour){
        this.type = "pawn";
        this.range = 1;
        this.straight = new StraightMovement();
        this.diagonal = new DiagonalMovement();
	}
	
    override public bool validMove(Board board, int[] startPos, int[] endPos) {
        if (!base.validMove(board, startPos, endPos))
            return false;   
        //1 Mark for valid direction depending on the pawn's colour (ETO)
        if (string.Equals(this.colour, "White") && startPos[0] < endPos[0])
            return false;
        else if (string.Equals(this.colour, "Black") && startPos[0] > endPos[0])
            return false;
        /*1 Mark for only allowing diagonal movement if taking a piece and only allowing straight movement if not 
		taking a piece (ETO)*/
        if (startPos[1] == endPos[1]) {
            if (board.pieceAt(endPos) != null)
                return false;
            else {
                //1 Mark for allowing the pawn to move forward 2 spaces if it is in its starting location (ETO)
                if (string.Equals(this.colour, "White") && startPos[0] == board.getHeight() - 2 ||
                string.Equals(this.colour, "Black") && startPos[0] == 1) {
                    if (this.straight.validMove(this.colour, board, startPos, endPos, this.range + 1))
                        return true;
                }
                else if (this.straight.validMove(this.colour, board, startPos, endPos, this.range))
                    return true;
			}
        }        
        if (startPos[1] != endPos[1]) {
            if (board.pieceAt(endPos) == null)
                return false;
            else {
                if (this.diagonal.validMove(this.colour, board, startPos, endPos, this.range))
                    return true;
            }
        }    
        return false;
    }
}