using System;
using System.Collections.Generic;
using System.Text;
using board;


namespace game
{
    class Pawn : Piece
    {
        private ChessMatch match;

        public Pawn(Board boardGame, Color color, ChessMatch chessMatch) : base(boardGame, color)
        {
            this.match = chessMatch;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool isThereEnemy(Position position)
        {
            Piece gamePiece = board.piece(position);
            return gamePiece != null && gamePiece.color != color;
        }

        private bool isFree(Position position)
        {
            return board.piece(position) == null;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] gameBoard = new bool[board.lines, board.columns];

            Position gamePosition = new Position(0, 0);

            if (color == Color.White)
            {
                gamePosition.defineValues(position.line - 1, position.column);
                if (board.isValidPosition(gamePosition) && isFree(gamePosition))
                {
                    gameBoard[gamePosition.line, gamePosition.column] = true;
                }
                gamePosition.defineValues(position.line - 2, position.column);
                Position p2 = new Position(position.line - 1, position.column);
                if (board.isValidPosition(p2) && isFree(p2) && board.isValidPosition(gamePosition) && isFree(gamePosition) && movesQnt == 0)
                {
                    gameBoard[gamePosition.line, gamePosition.column] = true;
                }
                gamePosition.defineValues(position.line - 1, position.column - 1);
                if (board.isValidPosition(gamePosition) && isThereEnemy(gamePosition))
                {
                    gameBoard[gamePosition.line, gamePosition.column] = true;
                }
                gamePosition.defineValues(position.line - 1, position.column + 1);
                if (board.isValidPosition(gamePosition) && isThereEnemy(gamePosition))
                {
                    gameBoard[gamePosition.line, gamePosition.column] = true;
                }

                if (position.line == 3)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (board.isValidPosition(left) && isThereEnemy(left) && board.piece(left) == match.enPassant)
                    {
                        gameBoard[left.line - 1, left.column] = true;
                    }
                    Position direita = new Position(position.line, position.column + 1);
                    if (board.isValidPosition(direita) && isThereEnemy(direita) && board.piece(direita) == match.enPassant)
                    {
                        gameBoard[direita.line - 1, direita.column] = true;
                    }
                }
            }
            else
            {
                gamePosition.defineValues(position.line + 1, position.column);
                if (board.isValidPosition(gamePosition) && isFree(gamePosition))
                {
                    gameBoard[gamePosition.line, gamePosition.column] = true;
                }
                gamePosition.defineValues(position.line + 2, position.column);
                Position p2 = new Position(position.line + 1, position.column);
                if (board.isValidPosition(p2) && isFree(p2) && board.isValidPosition(gamePosition) && isFree(gamePosition) && movesQnt == 0)
                {
                    gameBoard[gamePosition.line, gamePosition.column] = true;
                }
                gamePosition.defineValues(position.line + 1, position.column - 1);
                if (board.isValidPosition(gamePosition) && isThereEnemy(gamePosition))
                {
                    gameBoard[gamePosition.line, gamePosition.column] = true;
                }
                gamePosition.defineValues(position.line + 1, position.column + 1);
                if (board.isValidPosition(gamePosition) && isThereEnemy(gamePosition))
                {
                    gameBoard[gamePosition.line, gamePosition.column] = true;
                }

                if (position.line == 4)
                {
                    Position esquerda = new Position(position.line, position.column - 1);
                    if (board.isValidPosition(esquerda) && isThereEnemy(esquerda) && board.piece(esquerda) == match.enPassant)
                    {
                        gameBoard[esquerda.line + 1, esquerda.column] = true;
                    }
                    Position direita = new Position(position.line, position.column + 1);
                    if (board.isValidPosition(direita) && isThereEnemy(direita) && board.piece(direita) == match.enPassant)
                    {
                        gameBoard[direita.line + 1, direita.column] = true;
                    }
                }
            }

            return gameBoard;
        }
    }
}
