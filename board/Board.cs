using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_game.board
{
    class Board
    {

        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            this.pieces = new Piece[lines, columns];
        }
    }
}
