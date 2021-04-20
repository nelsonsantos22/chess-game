using board;

namespace Chess_game.board
{
    class Piece
    {

        public Position position { get; set; }
        public Color color { get; protected set; }

        public int movementNr { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Position position, Color color, Board board)
        {
            this.position = position;
            this.color = color;
            this.board = board;
            this.movementNr = 0;
        }
    }
}
