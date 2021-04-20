namespace board
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

        public Piece piece(Position pos)
        {
            return pieces[pos.line, pos.column];
        }

        public bool positionOccupied(Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }

        public void startPiece(Piece p, Position pos)
        {
            if (positionOccupied(pos))
            {
                throw new BoardException("Position already contains a piece!");
            }
            pieces[pos.line, pos.column] = p;
            p.position = pos;
        }

        public bool validPosition(Position pos)
        {
            if(pos.line < 0 || pos.line > lines || pos.column < 0 || pos.column > columns)
            {
                return false;
            }

            return true;
        }

        public void validatePosition(Position pos)
        {
            if (!validPosition(pos))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
