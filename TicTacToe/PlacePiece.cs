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

            var grid = _persistence.Read();
            
            _persistence.Save(
                r.Piece == X 
                    ? new Grid {PositionOfX = r.Position, PositionOfO = grid.PositionOfO} 
                    : new Grid {PositionOfO = r.Position, PositionOfX = grid.PositionOfX}
            );
        }

        private bool NobodyHasYetMoved()
        {
            return _persistence.Read().WhoMovedLast() == null;
        }
    }
}