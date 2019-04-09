using System.Collections.Immutable;
using System.Linq;
using NUnit.Framework;
using TicTacToe.Boundary;
using static TicTacToe.Boundary.ViewGridResponse;
using static TicTacToe.Boundary.CellValue;

namespace TicTacToe.Test
{
    public class ViewGridTest : IGridReader
    {
        private int? _positionOfX;
        private int? _positionOfO;

        public Grid Read()
        {
            return new Grid {PositionOfX = _positionOfX, PositionOfO = _positionOfO};
        }

        private int NumberOfPiecesInGrid(CellValue piece, CellValue[] grid)
        {
            return grid.Where(value => value == piece).ToImmutableList().Count;
        }

        private bool IsXOnlyInPosition(int position, CellValue[] grid)
        {
            bool xIsInPosition = grid[position] == X;
            bool everythingElseIsBlank = NumberOfPiecesInGrid(Blank, grid) == 8;

            return xIsInPosition && everythingElseIsBlank;
        }

        private bool IsOOnlyInPosition(int position, CellValue[] grid)
        {
            bool oIsInPosition = grid[position] == O;
            bool onlyOneO = NumberOfPiecesInGrid(O, grid) == 1;

            return oIsInPosition && onlyOneO;
        }

        [Test]
        public void CanViewEmptyGrid()
        {
            _positionOfX = null;
            _positionOfO = null;

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
            _positionOfO = null;

            var viewGrid = new ViewGrid(this);
            var viewGridResponse = viewGrid.Execute();
            Assert.IsTrue(IsXOnlyInPosition(position, viewGridResponse.Grid));
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
        public void CanViewAGridWithAnOPiecePlacedAnywhere(int position)
        {
            _positionOfX = 7;
            _positionOfO = position;

            var viewGrid = new ViewGrid(this);
            var viewGridResponse = viewGrid.Execute();
            Assert.IsTrue(IsOOnlyInPosition(position, viewGridResponse.Grid));
        }
    }
}