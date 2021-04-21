using board;

namespace game
{
    internal class ChessPosition
    {
        private char column { get; set; }
        private int line { get; set; }

        public ChessPosition(char column, int line)
        {
            this.column = column;
            this.line = line;
        }


        public Position toPosition()
        {
            return new Position(8 - line, column - 'a');
        }


        public override string ToString()
        {
            return "" + column + line;
        }
    }
}