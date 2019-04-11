using System;
using System.Linq;

namespace TicTacToe
{
    public class Grid
    {
        public PieceType[] Pieces { get; set; }

        public enum Player
        {
            PlayerX,
            PlayerO,
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
            return Pieces[position] == PieceType.X;
        }

        public bool IsThereAnOInPosition(int position)
        {
            return Pieces[position] == PieceType.O;
        }

        public Player WhoMovedLast()
        {
            var numberOfMoves = Pieces
                .Where(type => type != PieceType.Blank)
                .ToArray()
                .Length;

            if (numberOfMoves == 0) return Player.Nobody;
            
            var xMovedLast = numberOfMoves % 2 != 0;
            
            return xMovedLast ? Player.PlayerX : Player.PlayerO;
        }
    }
}