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
            var existingGrid = _persistence.Read();
            
            switch (r?.Piece)
            {
                case null:
                case PlacePieceRequest.Move.O when existingGrid.WhoMovedLast() == Grid.Player.Nobody:
                case PlacePieceRequest.Move.X when existingGrid.WhoMovedLast() == Grid.Player.PlayerX:
                    return;
            }

            if (r.Position == existingGrid.PositionOfX) return;
            
            var builder = new GridBuilder(existingGrid);
            _persistence.Save(builder.UpdatedForRequest(r).Build());
        }
    }
        
    public static class GridBuilderExtensions
    {
        public static GridBuilder UpdatedForRequest(this GridBuilder builder, PlacePieceRequest r)
        {
            if (r.Piece == PlacePieceRequest.Move.X)
                builder.WithXAt(r.Position);
            else
                builder.WithOAt(r.Position);

            return builder;
        }
    }
}