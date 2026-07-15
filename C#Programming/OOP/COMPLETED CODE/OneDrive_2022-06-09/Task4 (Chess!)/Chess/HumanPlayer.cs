using System;

class HumanPlayer : Player {	
    public HumanPlayer(string colour) : base(colour) {
	}
    
	override public bool movePiece(Board board) {
        bool end = false;
        int[] startPos = null;
        string startDisplay = "";
        
        while (end != true) {
            //1 Mark for getting move from user (ETO)
            bool posSet = false;
            while (!posSet) {
                board.display();
                Console.WriteLine();
                Console.WriteLine(this.colour + "'s turn:");
                Console.WriteLine("Enter the location of the piece you would like to move (e.g. A1):");
                startDisplay = Console.ReadLine();
                Console.WriteLine();
                startPos = this.getPos(board, this.colour, startDisplay);
                if (startPos != null && board.pieceAt(startPos) != null && board.pieceAt(startPos).getColour() == this.colour)
                    posSet = true;
                else {
                    Console.WriteLine("You don't have a piece at " + startDisplay + " to move! Please try again.");
                    Console.WriteLine();
                }
            }
            board.display();
            Console.WriteLine();
            Console.WriteLine(this.colour + "'s turn:");
            Console.WriteLine("Where would you like to move the " + board.pieceAt(startPos).getType() + " from " + 
			startDisplay.ToUpper() + " to?:");
            string endPos = Console.ReadLine();
            Console.WriteLine();
            //1 Mark for ending only once a move is successfully made (ETO)
            end = this.getPos(board, this.colour, startPos, endPos);
        }
        Console.WriteLine();
        Console.WriteLine();
        //1 Mark for returning the value of whether or not the game is over (ETO)
        return board.getGameOver();
    }
        
    //1 Mark for overriding getPos to allow it to work with either one or two positions given (ETO)
    private int[] getPos(Board board, string colour, string startPos) {
       int[] checkPos = {-1, -1};
        
        //1 Mark for accepting input in the form LetterNumber (A5, E5, E2 etc.) (ETO)
        if (startPos.Length > 2)
            return null;
            
        try {
            int startRow = (int)(startPos.ToUpper()[0]) - 65;
            int startColumn = Convert.ToInt32(startPos.Substring(1)) - 1;
            if (startRow < 0 || startRow >= board.getHeight() || startColumn < 0 || startColumn >= board.getHeight())
            	return null;
            else {
            	checkPos[0] = startRow;
            	checkPos[1] = startColumn;
            }
        }
        catch {
            return null;
        }
        
        if (board.pieceAt(checkPos) == null)
            return null;
        //1 Mark for returning an integer array of the location if only the start position is given (ETO)
        else
            return checkPos;
    }
    
	private bool getPos(Board board, string colour, int[] startPos, string endPos) {
		int[] checkPos = {-1, -1};
            	        
		//1 Mark for accepting input in the form LetterNumber (A5, E5, E2 etc.) (ETO)
        if (endPos.Length > 2)
        	return false;
            	            
        try {
        	int endRow = (int)(endPos.ToUpper()[0]) - 65;
            int endColumn = Convert.ToInt32(endPos.Substring(1)) - 1;
            if (endRow < 0 || endRow >= board.getHeight() || endColumn < 0 || endColumn >= board.getHeight())
            	return false;
            else {
            	checkPos[0] = endRow;
            	checkPos[1] = endColumn;
            }
        }
        catch {
        	return false;
        }  
        //1 Mark for making the move if both the start and end positions are given (ETO)
        return board.movePiece(colour, startPos, checkPos);
    }
}