namespace board
{
    abstract class Piece
    {

        public Position position { get; set; }
        public Color color { get; protected set; }
        public int movesQnt { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board gameBoard, Color color)
        {
            this.position = null;
            this.board = gameBoard;
            this.color = color;
            this.movesQnt = 0;
        }

        public void incrementMoves()
        {
            movesQnt++;
        }

        public void decrementMoves()
        {
            movesQnt--;
        }

        public bool isTherePossibleMoves()
        {
            bool[,] boardGame = possibleMoves();
            for (int i = 0; i < board.lines; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (boardGame[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool possibleMove(Position position)
        {
            return possibleMoves()[position.line, position.column];
        }

        public abstract bool[,] possibleMoves();

    }
}
