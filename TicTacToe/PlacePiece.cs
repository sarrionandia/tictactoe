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

            var builder = new GridBuilder(_persistence.Read());

            if (r.Piece == X)
                builder.WithXAt(r.Position);
            else
                builder.WithOAt(r.Position);

            _persistence.Save(builder.Build());
        }

        private bool NobodyHasYetMoved()
        {
            return _persistence.Read().WhoMovedLast() == null;
        }
    }
}