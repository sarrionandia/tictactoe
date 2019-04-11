using System;
using System.Linq;
using static TicTacToe.Grid.PieceType;

namespace TicTacToe
{
    public class GridBuilder
    {
        [Obsolete] private int? _xPosition;
        [Obsolete] private int? _oPosition;

        private Grid.PieceType[] _pieces;
        
        [Obsolete]
        public GridBuilder(Grid existingGrid) : this()
        {
            if (existingGrid.Pieces != null) _pieces = existingGrid.Pieces.ToArray();
            if (existingGrid.PositionOfO != null) WithOAt(existingGrid.PositionOfO ?? 0);
            if (existingGrid.PositionOfX != null) WithXAt(existingGrid.PositionOfX ?? 0);
        }

        public GridBuilder()
        {
            _pieces = new[]
            {
                Blank, Blank, Blank,
                Blank, Blank, Blank,
                Blank, Blank, Blank
            };    
        }

        public Grid Build()
        {
                return new Grid { Pieces = _pieces };
            
        }

        public GridBuilder WithXAt(int rPosition)
        {
            _xPosition = rPosition;
            _pieces[rPosition] = X;
            return this;
        }

        public GridBuilder WithOAt(int rPosition)
        {
            _oPosition = rPosition;
            _pieces[rPosition] = O;
            return this;
        }
    }
}