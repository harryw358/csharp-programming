using System;

public class Knight : Piece {
	public Knight(string colour) : base(colour){
        this.type = "knight";
	}
        
    //1 Mark for implementing the validMove method as described  
    override public bool validMove(Board board, int[] startPos, int[] endPos) {
        if (!base.validMove(board, startPos, endPos))
            return false;
        if (Math.Abs(endPos[0] - startPos[0]) == 2) {
            if (Math.Abs(endPos[1] - startPos[1]) != 1)
                return false;
        }
        else if (Math.Abs(endPos[0] - startPos[0]) == 1) {
            if (Math.Abs(endPos[1] - startPos[1]) != 2)
                return false;
        }
        else
            return false;
            
        return true;
    }
}