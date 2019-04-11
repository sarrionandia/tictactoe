using System;

namespace TicTacToe
{
    public class Grid
    {
        public int? PositionOfX { get; set; }
        public int? PositionOfO { get; set; }
        public PieceType[] Pieces { get; set; }

        public enum Player
        {
            PlayerX,
            Nobody
        }

        public enum PieceType
        {
            X,
            O,
            Blank
        }
        
        public bool IsThereAnXInPosition(int position)
        {
            if (Pieces != null) return Pieces[position] == PieceType.X;
            return PositionOfX == position;
        }

        public bool IsThereAnOInPosition(int position)
        {
            if (Pieces != null) return Pieces[position] == PieceType.O;
            return PositionOfO == position;
        }

        public Player WhoMovedLast()
        {
            return PositionOfX != null ? Player.PlayerX : Player.Nobody;
        }
    }
}