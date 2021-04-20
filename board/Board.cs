﻿namespace board
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

        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public void startPiece(Piece p, Position pos)
        {
            pieces[pos.line, pos.column] = p;
            p.position = pos;
        }
    }
}
