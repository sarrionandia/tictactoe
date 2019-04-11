using System;
using System.Linq;
using static TicTacToe.Grid.PieceType;

namespace TicTacToe
{
    public class GridBuilder
    {
        private readonly Grid.PieceType[] _pieces;

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

        public GridBuilder WithXAt(int position)
        {
            _pieces[position] = X;
            return this;
        }

        public GridBuilder WithOAt(int position)
        {
            _pieces[position] = O;
            return this;
        }
    }
}