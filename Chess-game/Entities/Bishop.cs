using board;


namespace game
{
    class Bishop : Piece
    {
        public Bishop(Board gameBoard, Color color) : base(gameBoard, color)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        private bool canMove(Position position)
        {
            Piece gamePiece = board.piece(position);
            return gamePiece == null || gamePiece.color != color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] gameBoard = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            // NO
            pos.defineValues(position.line - 1, position.column - 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                gameBoard[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defineValues(pos.line - 1, pos.column - 1);
            }

            // NE
            pos.defineValues(position.line - 1, position.column + 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                gameBoard[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defineValues(pos.line - 1, pos.column + 1);
            }

            // column
            pos.defineValues(position.line + 1, position.column + 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                gameBoard[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defineValues(pos.line + 1, pos.column + 1);
            }

            // SO
            pos.defineValues(position.line + 1, position.column - 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                gameBoard[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defineValues(pos.line + 1, pos.column - 1);
            }

            return gameBoard;
        }
    }
}
