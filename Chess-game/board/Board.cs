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


        public Piece piece(Position position)
        {
            return pieces[position.line, position.column];
        }


        public bool positionOccupied(Position position)
        {
            validatePosition(position);
            return piece(position) != null;
        }

        // draw a pice in the board if the position doesn't contain a piece already
        public void drawPiece(Piece piece, Position position)
        {
            if (positionOccupied(position))
            {
                throw new BoardException("Position already contains a piece!");
            }
            pieces[position.line, position.column] = piece;
            piece.position = position;
        }


        public Piece removePiece(Position position)
        {
            if(piece(position) == null)
            {
                return null;
            }

            Piece aux = piece(position);

            aux.position = null;
            pieces[position.line, position.column] = null;

            return aux;
        }


        // return if the positon is between the board game borders
        public bool validPosition(Position position)
        {
            if(position.line < 0 || position.line > lines || position.column < 0 || position.column > columns)
            {
                return false;
            }

            return true;
        }


        // if valid position method returns false throws an exeception
        public void validatePosition(Position position)
        {
            if (!validPosition(position))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
