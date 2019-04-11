using System;
using static TicTacToe.Grid.PieceType;

namespace TicTacToe
{
    public class GridBuilder
    {
        [Obsolete] private int? _xPosition;
        [Obsolete] private int? _oPosition;

        private Grid.PieceType[] _pieces;
        
        [Obsolete]
        public GridBuilder(Grid existingGrid)
        {
            _oPosition = existingGrid.PositionOfO;
            _xPosition = existingGrid.PositionOfX;
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
            if (_pieces != null)
            {
                return new Grid { Pieces = _pieces };
            }
            
            return new Grid {PositionOfX = _xPosition, PositionOfO = _oPosition};
        }

        public GridBuilder WithXAt(int rPosition)
        {
            _xPosition = rPosition;
            if(_pieces != null) _pieces[rPosition] = X;
            return this;
        }

        public GridBuilder WithOAt(int rPosition)
        {
            _oPosition = rPosition;
            if(_pieces != null) _pieces[rPosition] = O;
            return this;
        }
    }
}