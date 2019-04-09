using System.Collections.Immutable;
using System.Linq;
using NUnit.Framework;
using static TicTacToe.ViewGridResponse;
using static TicTacToe.ViewGridResponse.CellValue;

namespace TicTacToe.Test
{
    public class ViewGridTest : IGridReader
    {
        private int? _positionOfX;

        public Grid Read()
        {
            return new Grid {PositionOfX = _positionOfX};
        }

        private bool IsXOnlyInPosition(int position, CellValue[] grid)
        {
            bool xIsInPosition = grid[position] == X;

            var onlyTheBlanks = grid
                .Where(value => value == Blank)
                .ToImmutableList();
            bool everythingElseIsBlank = onlyTheBlanks.Count == 8;

            return xIsInPosition && everythingElseIsBlank;
        }

        [Test]
        public void CanViewEmptyGrid()
        {
            _positionOfX = null;
            var viewGrid = new ViewGrid(this);
            var viewGridResponse = viewGrid.Execute();
            Assert.AreEqual(new[]
            {
                Blank, Blank, Blank,
                Blank, Blank, Blank,
                Blank, Blank, Blank
            }, viewGridResponse.Grid);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void CanViewAGridWithPiecePlacedAnywhere(int position)
        {
            _positionOfX = position;
            var viewGrid = new ViewGrid(this);
            var viewGridResponse = viewGrid.Execute();
            Assert.IsTrue(IsXOnlyInPosition(position, viewGridResponse.Grid));
        }
    }
}