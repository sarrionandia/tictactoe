using System;

namespace TicTacToe
{
    public class Grid
    {
        public int? PositionOfX { get; set; }

        public bool IsThereAnXInPosition(int position)
        {
            return PositionOfX == position;
        }

        public Object WhoMovedLast()
        {
            return null;
        }
    }
}