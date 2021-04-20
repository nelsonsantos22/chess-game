using System;
using board;
using game;

namespace Chess_game
{
    class Program
    {
        static void Main(string[] args)
        {

            Position p;
            p = new Position(3, 4);

            

            Board b = new Board(8, 8);

            

            b.startPiece(new Tower(b, Color.Black), new Position(0, 0));
            b.startPiece(new Tower(b, Color.Black), new Position(1, 3));
            b.startPiece(new King(b, Color.Black), new Position(2, 4));

            Screen.printBoard(b);

        }
    }
}
