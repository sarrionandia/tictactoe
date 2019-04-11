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
            var numberOfXs = Pieces
                .Where(type => type == PieceType.X)
                .ToArray()
                .Length;
            var isXsTurn = numberOfXs % 2 != 0;
            
            return isXsTurn ? Player.PlayerX : Player.Nobody;
        }
    }
}