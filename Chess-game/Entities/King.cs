using board;

namespace game
{
    class King : Piece
    {
        public King(Board board, Color color, ChessMatch chessMatch) : base(board, color)
        {
        }


        public override string ToString()
        {
            return "K";
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

            if(board.isValidPosition(position) && canMove(position))
            {
                gameBoard[position.line, position.column] = true;
            }

            //UP & RIGHT
            position.defineValues(position.line - 1, position.column + 1);
            if (board.isValidPosition(position) && canMove(position))
            {
                gameBoard[position.line, position.column] = true;
            }

            //RIGHT
            position.defineValues(position.line, position.column + 1);
            if (board.isValidPosition(position) && canMove(position))
            {
                gameBoard[position.line, position.column] = true;
            }

            //DOWN & RIGHT
            position.defineValues(position.line + 1, position.column + 1);
            if (board.isValidPosition(position) && canMove(position))
            {
                gameBoard[position.line, position.column] = true;
            }

            //DOWN
            position.defineValues(position.line + 1, position.column);
            if (board.isValidPosition(position) && canMove(position))
            {
                gameBoard[position.line, position.column] = true;
            }

            //DOWN & LEFT
            position.defineValues(position.line + 1, position.column - 1);
            if (board.isValidPosition(position) && canMove(position))
            {
                gameBoard[position.line, position.column] = true;
            }

            //LEFT
            position.defineValues(position.line, position.column - 1);
            if (board.isValidPosition(position) && canMove(position))
            {
                gameBoard[position.line, position.column] = true;
            }

            //UP & LEFT
            position.defineValues(position.line - 1, position.column - 1);
            if (board.isValidPosition(position) && canMove(position))
            {
                gameBoard[position.line, position.column] = true;
            }


            return gameBoard;
        }
    }
}
