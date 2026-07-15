//1 Mark for including all classes given by the UML class diagram, with correct inheritance structure (ETO)
//1 Mark if all class attributes are made private/public/protected as specified by the UML class diagram
//1 Mark if all class methods are made private/public/protected as specified by the UML class diagram
using System;

public class Program {
	
	public static void Main() {
		Board board = new Board();
		HumanPlayer white = new HumanPlayer("White");
		HumanPlayer black = new HumanPlayer("Black");
		bool gameOver = false;
    
		while (!gameOver) { 
			Console.WriteLine();
			Console.WriteLine("It's White's turn to move:");
			gameOver = white.movePiece(board);
			if (gameOver)
				break;
			Console.WriteLine();
			Console.WriteLine("It's Black's turn to move:");
			gameOver = black.movePiece(board);
		}
		board.display();
		Console.ReadLine();
    }
}