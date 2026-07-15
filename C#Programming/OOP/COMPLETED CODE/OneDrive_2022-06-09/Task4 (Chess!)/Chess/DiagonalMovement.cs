using System;

public class DiagonalMovement {
    //1 Mark for working for movement in some diagonal directions (ETO)
    //1 Mark extra for working for movement in all diagonal directions (ETO)
    public bool validMove(String colour, Board board, int[] startPos, int[] endPos, int pieceRange) {
        if (Math.Abs(endPos[0] - startPos[0]) != Math.Abs(endPos[1] - startPos[1]))
            return false;

        int length = Math.Abs(endPos[0] - startPos[0]);
        int columnChange = 1;
        int rowChange = 1;

        if (endPos[0] < startPos[0])
            rowChange = -1;

        if (endPos[1] < startPos[1])
            columnChange = -1;

        if (pieceRange >= length) {
            for (int r = 1; r < Math.Abs(endPos[0] - startPos[0]); r++) {
                int[] tempPos = {startPos[0] + r * rowChange, startPos[1] + r * columnChange};
                if (board.pieceAt(tempPos) != null)
                    return false;
            }
            return true;
        }
        return false;
    }
}