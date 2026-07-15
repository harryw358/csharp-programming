using System;

public class Board {
    private int columns;
    private int rows;
    private Piece[, ] board;
    private bool gameOver;
	
	//1 Mark for defining a constructor for the class Board with appropriate attributes
    public Board() {
        this.columns = 8;
        this.rows = 8;
        this.board = new Piece[this.rows, this.columns];
        for (int r=0; r < this.rows; r++) {
		    for (int c=0; c < this.columns; c++)
		        board[r, c] = null;
		}
        this.gameOver = false;
        this.setUp();
    }
    
    //1 Mark for implementing the display method as described (ETO)
    public  void display() {
    	string y = "";
    	string z = "";
        string firstLine = "   ";
        string breakLine = "";
        for (int i = 0; i < (5*this.columns)+4; i ++)
			breakLine += "-";
        		
        for (int c=0; c < this.columns; c++)
            firstLine += ("| " + (c+1) + "  ");

        firstLine += "|";
        Console.WriteLine(firstLine);
        		
        Console.WriteLine(breakLine);
        for (int r=0; r < this.rows; r++) {
            Console.Write(" " + (char)(r+65) + " ");
            for (int c=0; c < this.columns; c++) {
                if (this.board[r, c] == null) {
                    y = " ";
                    z = "   ";
                }
                else {
                    y = this.board[r, c].getType()[0].ToString();
                    z = "(" + this.board[r, c].getColour().ToLower()[0]  + ")";
                }
                Console.Write("|" + y + z);
            }
            Console.WriteLine("|");
            Console.WriteLine(breakLine);
        }
        Console.WriteLine();
    }
    
    //1 Mark for creating relevant accessor methods to access Board's private attributes
    public int getWidth() {
        return this.columns;
    }
    
    public int getHeight() {
        return this.rows;
    }
    
    public bool getGameOver() {
        return this.gameOver;
    }
    
    //1 Mark for implementing the pieceAt method as described
    public Piece pieceAt(int[] location) {
        try {
            return this.board[location[0], location[1]];
        }
        catch {
            return null;
        }
    }
			
    //1 Mark for implementing the movePiece method as described (ETO)
    public bool movePiece(string colour,int[] startPos,int[] endPos) {
        Piece startPiece = this.board[startPos[0], startPos[1]];
        Piece endPiece = this.board[endPos[0], endPos[1]];
        if (startPiece != null) {
            if (string.Equals(startPiece.getColour(), colour)) {
                if (startPiece.validMove(this, startPos, endPos)) {
                    Console.WriteLine(colour + "'s " + startPiece.getType() + " was moved to " + (char)(endPos[0]+65) + 
					(endPos[1]+1) + ".");
                    this.takePiece(startPiece, endPiece);
                    this.board[startPos[0], startPos[1]] = null;
                    this.board[endPos[0], endPos[1]] = startPiece;
                    this.upgradePiece(startPiece, endPos);
                    Console.WriteLine();
                    return true;
                }
            }
    	}
        Console.WriteLine("That is not a valid move! Please try again.");
        return false;
    }
    
    //1 Mark for implementing the takePiece method as described
    private void takePiece(Piece startPiece, Piece endPiece) {
        if (endPiece != null) {
            Console.WriteLine(startPiece.getColour() + "'s " + startPiece.getType() + " took " + endPiece.getColour() + 
			"'s " + endPiece.getType() + ".");
            if (string.Equals(endPiece.getType(), "King")) {
                Console.WriteLine(startPiece.getColour() + " has won the game!");
                this.gameOver = true;
            }
        }
    }
     
    //1 Mark for implementing the upgradePiece method as described
    private void upgradePiece(Piece startPiece, int[] endPos) {
        if (string.Equals(startPiece.getType(), "pawn")) {
            if (string.Equals(startPiece.getColour(), "White") && endPos[0] == 0)
                this.board[endPos[0], endPos[1]] = new Queen("White");
            else if (string.Equals(startPiece.getColour(), "Black") && endPos[0] == this.rows - 1)
                this.board[endPos[0], endPos[1]] = new Queen("Black");
            else
                return;
            Console.WriteLine(startPiece.getColour() + "'s pawn became a Queen!");
        }
    }
    
    //1 Mark for implementing the setUp method as described
    private void setUp() {
    	for (int c=0; c < this.columns; c++) {
            this.board[1, c] = new Pawn("Black");
            this.board[this.rows - 2, c] = new Pawn("White");
            if (c == 0 || c == this.columns - 1) {
                this.board[0, c] = new Rook("Black");
                this.board[this.rows - 1, c] = new Rook("White");
            }
            else if (c == 1 || c == this.columns - 2) {
                this.board[0, c] = new Knight("Black");
                this.board[this.rows - 1, c] = new Knight("White");
            }
            else if (c == 2 || c == this.columns - 3) {
                this.board[0, c] = new Bishop("Black");
                this.board[this.rows - 1, c] = new Bishop("White");
            }
            else if (c == 3) {
                this.board[0, c] = new King("Black");
                this.board[this.rows - 1, c] = new King("White");
            }
            else if (c == this.columns - 4) {
                this.board[0, c] = new Queen("Black");
                this.board[this.rows - 1, c] = new Queen("White");
            }
    	}
    }
}