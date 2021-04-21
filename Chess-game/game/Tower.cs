using board;

namespace game
{
    class Tower : Piece
    {
        public Tower(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "T";
        }


        public bool canMove(Position position)
        {
            Piece piece = board.piece(position);
            return piece == null || piece.color != color;
        }


        public override bool[,] possibleMoves()
        {
            bool[,] gameBoard = new bool[board.lines, board.columns];

            Position position = new Position(0, 0);

            //UP
            position.defineValues(position.line - 1, position.column);
            while(board.isValidPosition(position) && canMove(position))
            {
                gameBoard[position.line, position.column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }

                position.line = position.line - 1;
            }

            //DOWN
            position.defineValues(position.line + 1, position.column);
            while (board.isValidPosition(position) && canMove(position))
            {
                gameBoard[position.line, position.column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }

                position.line = position.line + 1;
            }

            //RIGHT
            position.defineValues(position.line, position.column + 1);
            while (board.isValidPosition(position) && canMove(position))
            {
                gameBoard[position.line, position.column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }

                position.column = position.column + 1;
            }

            //LEFT
            position.defineValues(position.line, position.column - 1);
            while (board.isValidPosition(position) && canMove(position))
            {
                gameBoard[position.line, position.column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }

                position.column = position.column - 1;
            }


            return gameBoard;

        }
    }
}

