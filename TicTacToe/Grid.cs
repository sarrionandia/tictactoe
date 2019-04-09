using System;

namespace TicTacToe
{
    public class Grid
    {
        public int? PositionOfX { get; set; }
        public int? PositionOfO { get; set; }

        public enum Player
        {
            PlayerX,
            Nobody
        }
        
        public bool IsThereAnXInPosition(int position)
        {
            return PositionOfX == position;
        }

        public Player WhoMovedLast()
        {
            return PositionOfX != null ? Player.PlayerX : Player.Nobody;
        }

        public bool IsThereAnOInPosition(int position)
        {
            return PositionOfO == position;
        }
    }
}