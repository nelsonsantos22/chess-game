namespace board
{
    abstract class Piece
    {

        public Position position { get; set; }
        public Color color { get; protected set; }

        public int moves { get; protected set; }
        public Board board { get; protected set; }


        public Piece(Board board, Color color)
        {
            this.position = null;
            this.color = color;
            this.board = board;
            this.moves = 0;
        }


        public void incrementMoves()
        {
            moves++;
        }


        public void decrementMoves()
        {
            moves--;
        }


        // confirms if is possible to move to the position wanted
        public bool isPossibleToMove()
        {
            bool[,] gameBoard = possibleMoves();

            for(int i = 0; i < board.lines; i++)
            {
                for(int j = 0; j < board.columns; j++)
                {
                    if(gameBoard[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public abstract bool[,] possibleMoves();

    }
}
