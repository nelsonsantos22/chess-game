using board;

namespace game
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }


        public override bool[,] possibleMoves()
        {
            throw new System.NotImplementedException();
        }
    }
}
