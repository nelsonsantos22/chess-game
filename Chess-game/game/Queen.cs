using System;
using System.Collections.Generic;
using System.Text;
using board;


namespace game
{
    class Queen : Piece
    {
        public Queen(Board gameBoard, Color color) : base(gameBoard, color)
        {
        }

        public override string ToString()
        {
            return "D";
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

            // LEFT
            pos.defineValues(position.line, position.column - 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                gameBoard[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defineValues(pos.line, pos.column - 1);
            }

            // RIGHT
            pos.defineValues(position.line, position.column + 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                gameBoard[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defineValues(pos.line, pos.column + 1);
            }

            // UP
            pos.defineValues(position.line - 1, position.column);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                gameBoard[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defineValues(pos.line - 1, pos.column);
            }

            // DOWN
            pos.defineValues(position.line + 1, position.column);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                gameBoard[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.defineValues(pos.line + 1, pos.column);
            }

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

            // SE
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
