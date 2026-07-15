using System;

public class StraightMovement {
    public bool validMove(String colour, Board board, int[] startPos, int[] endPos, int pieceRange) {
    	int direction = 1;
    	if (endPos[0] < startPos[0] || endPos[1] < startPos[1])
    		direction = -1;
        //1 Mark for working correctly for horizontal movement (ETO)
        if (startPos[0] == endPos[0]) {
            if (pieceRange >= Math.Abs(endPos[1] - startPos[1])) {
                for (int i = 1; i < (endPos[1] - startPos[1]); i++) {
                    int[] tempPos = {startPos[0], startPos[1] + i * direction};
                    if (board.pieceAt(tempPos) != null)
                        return false;
                }
                return true;
            }
        }
        //1 Mark for working correctly for vertical movement (ETO)
        if (startPos[1] == endPos[1]) {
            if (pieceRange >= Math.Abs(endPos[0] - startPos[0])) {
            	for (int i = 1; i < Math.Abs(endPos[0] - startPos[0]); i++) {
                    int[] tempPos = {startPos[0] + i * direction, startPos[1]};
                    if (board.pieceAt(tempPos) != null)
                        return false;
            	}
                return true;
            }
        }
        return false;
    }
}