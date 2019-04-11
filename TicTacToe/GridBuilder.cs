using System;
using System.Linq;
using static TicTacToe.Grid.PieceType;

namespace TicTacToe
{
    public class GridBuilder
    {
        private Grid.PieceType[] _pieces;

        [Obsolete]
        public GridBuilder(Grid existingGrid) : this()
        {
            _pieces = existingGrid.Pieces.ToArray();
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
            return new Grid {Pieces = _pieces};
        }

        public GridBuilder WithXAt(int rPosition)
        {
            _pieces[rPosition] = X;
            return this;
        }

        public GridBuilder WithOAt(int rPosition)
        {
            _pieces[rPosition] = O;
            return this;
        }
    }
}