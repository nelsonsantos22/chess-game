using System;
using board;

namespace Chess_game
{
    class Program
    {
        static void Main(string[] args)
        {

            Position p;
            p = new Position(3, 4);

            

            Board b = new Board(8, 8);

            Screen.printBoard(b);

            
        }
    }
}
