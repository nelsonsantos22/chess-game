using System;
using System.Collections.Generic;
using System.Text;
using board;


namespace game
{
    class Horse : Piece
    {
        public Horse(Board boardGame, Color color) : base(boardGame, color)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        private bool podeMover(Position pos)
        {
            Piece gamePiece = board.piece(pos);
            return gamePiece == null || gamePiece.color != color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] gameBoard = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            pos.defineValues(position.line - 1, position.column - 2);
            if (board.isValidPosition(pos) && podeMover(pos))
            {
                gameBoard[pos.line, pos.column] = true;
            }
            pos.defineValues(position.line - 2, position.column - 1);
            if (board.isValidPosition(pos) && podeMover(pos))
            {
                gameBoard[pos.line, pos.column] = true;
            }
            pos.defineValues(position.line - 2, position.column + 1);
            if (board.isValidPosition(pos) && podeMover(pos))
            {
                gameBoard[pos.line, pos.column] = true;
            }
            pos.defineValues(position.line - 1, position.column + 2);
            if (board.isValidPosition(pos) && podeMover(pos))
            {
                gameBoard[pos.line, pos.column] = true;
            }
            pos.defineValues(position.line + 1, position.column + 2);
            if (board.isValidPosition(pos) && podeMover(pos))
            {
                gameBoard[pos.line, pos.column] = true;
            }
            pos.defineValues(position.line + 2, position.column + 1);
            if (board.isValidPosition(pos) && podeMover(pos))
            {
                gameBoard[pos.line, pos.column] = true;
            }
            pos.defineValues(position.line + 2, position.column - 1);
            if (board.isValidPosition(pos) && podeMover(pos))
            {
                gameBoard[pos.line, pos.column] = true;
            }
            pos.defineValues(position.line + 1, position.column - 2);
            if (board.isValidPosition(pos) && podeMover(pos))
            {
                gameBoard[pos.line, pos.column] = true;
            }

            return gameBoard;
        }
    }
}
