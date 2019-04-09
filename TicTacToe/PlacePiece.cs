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

            _persistence.Save(builder.UpdatedForRequest(r).Build());
        }

        private bool NobodyHasYetMoved()
        {
            return _persistence.Read().WhoMovedLast() == null;
        }
    }
    
    public static class GridBuilderExtensions
    {
        public static GridBuilder UpdatedForRequest(this GridBuilder builder, PlacePieceRequest r)
        {
            if (r.Piece == X)
                builder.WithXAt(r.Position);
            else
                builder.WithOAt(r.Position);

            return builder;
        }
    }
}