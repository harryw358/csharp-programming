public class BasicMovement {
    //1 Mark for implementing the validMove method as described (ETO)
    public bool validMove(string colour, Board board, int[] startPos, int[] endPos) {
        if (endPos[0] >= 0 && endPos[0] < board.getHeight()) {
            if (endPos[1] >= 0 && endPos[1] < board.getWidth()) {
                if (startPos != endPos) {
                    if (board.pieceAt(endPos) != null) {
                        if (!string.Equals(board.pieceAt(endPos).getColour(), colour))
                            return true;
                    }
                    else
                        return true;
                }
            }
        }
        return false;
    }
}