using board;
using System;
using System.Collections.Generic;


namespace game
{
    class ChessMatch
    {

        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finnished { get; private set; }
        private HashSet<Piece> gamePieces;
        private HashSet<Piece> lostPieces;
        public bool check { get; private set; }
        public Piece possibleEnPassantMove { get; private set; }

        public ChessMatch()
        {
            this.board = new Board(8,8);
            this.turn = 1;
            this.currentPlayer = Color.White;
            this.finnished = false;
            this.gamePieces = new HashSet<Piece>();
            this.lostPieces = new HashSet<Piece>();
            this.check = false;
            this.possibleEnPassantMove = null;
            drawAllPiecesInBoard();
        }
        

        public Piece movePiece(Position origin, Position destiny)
        {
            Piece chessPiece = board.removePiece(origin);
            chessPiece.incrementMoves();
            Piece lostPiece = board.removePiece(destiny);
            board.drawPiece(chessPiece, destiny);

            if(lostPiece != null)
            {
                lostPieces.Add(lostPiece);
            }

            if(chessPiece is King && destiny.column == origin.column - 2)
            {
                Position originT = new Position(origin.line, origin.column - 4);
                Position destinyT = new Position(destiny.line, destiny.column - 1);
                Piece T = board.removePiece(originT);
                T.incrementMoves();
                board.drawPiece(T, destinyT);
            }

            return lostPiece;
        }


        // draw new piece in a taken position
        private void drawNewPiece(char column, int line, Piece chessPiece)
        {
            board.drawPiece(chessPiece, new ChessPosition(column, line).toPosition());
        }


        private void drawAllPiecesInBoard()
        {
            drawNewPiece('a', 1, new Tower(board, Color.White));
        }

    }
}
