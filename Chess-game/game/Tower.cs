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

        public override bool[,] possibleMoves()
        {
            throw new System.NotImplementedException();
        }
    }
}

