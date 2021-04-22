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
            pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece piece(Position position)
        {
            return pieces[position.line, position.column];
        }

        public bool isThereAPiece(Position position)
        {
            validatePosition(position);
            return piece(position) != null;
        }

        public void drawPieceOnBoard(Piece piece, Position position)
        {
            if (isThereAPiece(position))
            {
                throw new BoardException("There's no longer a piece in this position!");
            }
            pieces[position.line, position.column] = piece;
            piece.position = position;
        }

        public Piece removePiece(Position position)
        {
            if (piece(position) == null)
            {
                return null;
            }
            Piece aux = piece(position);
            aux.position = null;
            pieces[position.line, position.column] = null;
            return aux;
        }

        public bool isValidPosition(Position position)
        {
            if (position.line < 0 || position.line >= lines || position.column < 0 || position.column >= columns)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position position)
        {
            if (!isValidPosition(position))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
