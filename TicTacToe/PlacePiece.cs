using System;
using TicTacToe.Boundary;
using static TicTacToe.Boundary.CellValue;

namespace TicTacToe
{
    public class PlacePiece
    {
        private readonly IPersistence _persistence;

        public PlacePiece(IPersistence persistence)
        {
            _persistence = persistence;
        }

        public void Execute(PlacePieceRequest r)
        {
            if (r == null) return;

            if (r.Piece == O && NobodyHasYetMoved()) return;
            
            _persistence.Save(new Grid {PositionOfX = r.Position});
        }

        private bool NobodyHasYetMoved()
        {
            return _persistence.Read().WhoMovedLast() == null;
        }
    }
}