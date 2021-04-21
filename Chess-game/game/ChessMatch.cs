using board;
using System;
using System.Collections.Generic;


namespace game
{
    class ChessMatch
    {

        public Board gameBoard { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool matchFinnished { get; private set; }
        private HashSet<Piece> gamePieces;
        private HashSet<Piece> piecesCaptured;
        public bool check { get; private set; }
        public Piece enPassant { get; private set; }

        public ChessMatch()
        {
            gameBoard = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            matchFinnished = false;
            check = false;
            enPassant = null;
            gamePieces = new HashSet<Piece>();
            piecesCaptured = new HashSet<Piece>();
            drawPiecesOnBoard();
        }

        public Piece move(Position origin, Position destiny)
        {


            Piece piece = gameBoard.removePiece(origin);
            piece.incrementMoves();
            Piece lostPiece = gameBoard.removePiece(destiny);
            gameBoard.drawPieceOnBoard(piece, destiny);

            if (lostPiece != null)
            {
                piecesCaptured.Add(lostPiece);
            }

            if (piece is King && destiny.column == origin.column + 2)
            {
                Position origemT = new Position(origin.line, origin.column + 3);
                Position destinoT = new Position(origin.line, origin.column + 1);
                Piece T = gameBoard.removePiece(origemT);
                T.incrementMoves();
                gameBoard.drawPieceOnBoard(T, destinoT);
            }

            if (piece is King && destiny.column == origin.column - 2)
            {
                Position originT = new Position(origin.line, origin.column - 4);
                Position destinyT = new Position(origin.line, origin.column - 1);
                Piece T = gameBoard.removePiece(originT);
                T.incrementMoves();
                gameBoard.drawPieceOnBoard(T, destinyT);
            }

            if (piece is Pawn)
            {
                if (origin.column != destiny.column && lostPiece == enPassant)
                {
                    Position posP;
                    if (piece.color == Color.White)
                    {
                        posP = new Position(destiny.line + 1, destiny.column);
                    }
                    else
                    {
                        posP = new Position(destiny.line - 1, destiny.column);
                    }
                    lostPiece = gameBoard.removePiece(posP);
                    piecesCaptured.Add(lostPiece);
                }
            }

            return lostPiece;
        }

        public void undoMove(Position origin, Position destiny, Piece pieceCaptured)
        {
            Piece piece = gameBoard.removePiece(destiny);
            piece.decrementMoves();


            if (pieceCaptured != null)
            {
                gameBoard.drawPieceOnBoard(pieceCaptured, destiny);
                piecesCaptured.Remove(pieceCaptured);
            }
            gameBoard.drawPieceOnBoard(piece, origin);


            if (piece is King && destiny.column == origin.column + 2)
            {
                Position originT = new Position(origin.line, origin.column + 3);
                Position destinyT = new Position(origin.line, origin.column + 1);
                Piece T = gameBoard.removePiece(destinyT);
                T.decrementMoves();
                gameBoard.drawPieceOnBoard(T, originT);
            }


            if (piece is King && destiny.column == origin.column - 2)
            {
                Position originT = new Position(origin.line, origin.column - 4);
                Position destinyT = new Position(origin.line, origin.column - 1);
                Piece T = gameBoard.removePiece(destinyT);
                T.decrementMoves();
                gameBoard.drawPieceOnBoard(T, originT);
            }


            if (piece is Pawn)
            {
                if (origin.column != destiny.column && pieceCaptured == enPassant)
                {
                    Piece gamePawn = gameBoard.removePiece(destiny);
                    Position positionP;
                    if (piece.color == Color.White)
                    {
                        positionP = new Position(3, destiny.column);
                    }
                    else
                    {
                        positionP = new Position(4, destiny.column);
                    }
                    gameBoard.drawPieceOnBoard(gamePawn, positionP);
                }
            }
        }



        public void yourTurn(Position origin, Position destiny)
        {


            Piece lostPiece = move(origin, destiny);

            if (isChecked(currentPlayer))
            {
                undoMove(origin, destiny, lostPiece);
                throw new BoardException("You can't put you on check position!");
            }

            Piece piece = gameBoard.piece(destiny);

            if (piece is Pawn)
            {
                if ((piece.color == Color.White && destiny.line == 0) || (piece.color == Color.Black && destiny.line == 7))
                {
                    piece = gameBoard.removePiece(destiny);
                    gamePieces.Remove(piece);
                    Piece queen = new Queen(gameBoard, piece.color);
                    gameBoard.drawPieceOnBoard(queen, destiny);
                    gamePieces.Add(queen);
                }
            }

            if (isChecked(opponent(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (testCheckMate(opponent(currentPlayer)))
            {
                matchFinnished = true;
            }
            else
            {
                turn++;
                changePlayer();
            }

            if (piece is Pawn && (destiny.line == origin.line - 2 || destiny.line == origin.line + 2))
            {
                enPassant = piece;
            }
            else
            {
                enPassant = null;
            }

        }

        public void validateOriginPosition(Position position)
        {
            if (gameBoard.piece(position) == null)
            {
                throw new BoardException("Piece not found!");
            }
            if (currentPlayer != gameBoard.piece(position).color)
            {
                throw new BoardException("Piece in that position is not yours!");
            }
            if (!gameBoard.piece(position).isTherePossibleMoves())
            {
                throw new BoardException("No movements allowed to that position!");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny)
        {
            if (!gameBoard.piece(origin).possibleMove(destiny))
            {
                throw new BoardException("Invalid postiion!");
            }
        }

        private void changePlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in piecesCaptured)
            {
                if (piece.color == color)
                {
                    aux.Add(piece);
                }
            }
            return aux;
        }

        public HashSet<Piece> availablePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in gamePieces)
            {
                if (piece.color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        private Color opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece piece in availablePieces(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool isChecked(Color color)
        {
            Piece R = king(color);

            if (R == null)
            {
                throw new BoardException("King from color " + color + " not found!");
            }

            foreach (Piece gamePiece in availablePieces(opponent(color)))
            {
                bool[,] gameBoard = gamePiece.possibleMoves();

                if (gameBoard[R.position.line, R.position.column])
                {
                    return true;
                }
            }

            return false;
        }

        public bool testCheckMate(Color color)
        {
            if (!isChecked(color))
            {
                return false;
            }

            foreach (Piece pieces in availablePieces(color))
            {
                bool[,] boardGame = pieces.possibleMoves();

                for (int i = 0; i < gameBoard.lines; i++)
                {
                    for (int j = 0; j < gameBoard.columns; j++)
                    {
                        if (boardGame[i, j])
                        {
                            Position origin = pieces.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = move(origin, destiny);
                            bool testeXeque = isChecked(color);
                            undoMove(origin, destiny, capturedPiece);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void drawNewPiece(char column, int line, Piece piece)
        {
            gameBoard.drawPieceOnBoard(piece, new ChessPosition(column, line).toPosition());
            gamePieces.Add(piece);
        }

        private void drawPiecesOnBoard()
        {
            drawNewPiece('a', 1, new Tower(gameBoard, Color.White));
            drawNewPiece('b', 1, new Horse(gameBoard, Color.White));
            drawNewPiece('c', 1, new Bishop(gameBoard, Color.White));
            drawNewPiece('d', 1, new Queen(gameBoard, Color.White));
            drawNewPiece('e', 1, new King(gameBoard, Color.White, this));
            drawNewPiece('f', 1, new Bishop(gameBoard, Color.White));
            drawNewPiece('g', 1, new Horse(gameBoard, Color.White));
            drawNewPiece('h', 1, new Tower(gameBoard, Color.White));
            drawNewPiece('a', 2, new Pawn(gameBoard, Color.White, this));
            drawNewPiece('b', 2, new Pawn(gameBoard, Color.White, this));
            drawNewPiece('c', 2, new Pawn(gameBoard, Color.White, this));
            drawNewPiece('d', 2, new Pawn(gameBoard, Color.White, this));
            drawNewPiece('e', 2, new Pawn(gameBoard, Color.White, this));
            drawNewPiece('f', 2, new Pawn(gameBoard, Color.White, this));
            drawNewPiece('g', 2, new Pawn(gameBoard, Color.White, this));
            drawNewPiece('h', 2, new Pawn(gameBoard, Color.White, this));

            drawNewPiece('a', 8, new Tower(gameBoard, Color.Black));
            drawNewPiece('b', 8, new Horse(gameBoard, Color.Black));
            drawNewPiece('c', 8, new Bishop(gameBoard, Color.Black));
            drawNewPiece('d', 8, new Queen(gameBoard, Color.Black));
            drawNewPiece('e', 8, new King(gameBoard, Color.Black, this));
            drawNewPiece('f', 8, new Bishop(gameBoard, Color.Black));
            drawNewPiece('g', 8, new Horse(gameBoard, Color.Black));
            drawNewPiece('h', 8, new Tower(gameBoard, Color.Black));
            drawNewPiece('a', 7, new Pawn(gameBoard, Color.Black, this));
            drawNewPiece('b', 7, new Pawn(gameBoard, Color.Black, this));
            drawNewPiece('c', 7, new Pawn(gameBoard, Color.Black, this));
            drawNewPiece('d', 7, new Pawn(gameBoard, Color.Black, this));
            drawNewPiece('e', 7, new Pawn(gameBoard, Color.Black, this));
            drawNewPiece('f', 7, new Pawn(gameBoard, Color.Black, this));
            drawNewPiece('g', 7, new Pawn(gameBoard, Color.Black, this));
            drawNewPiece('h', 7, new Pawn(gameBoard, Color.Black, this));
        }

    }
}
