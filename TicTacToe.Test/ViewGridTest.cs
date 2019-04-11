using System.Collections.Immutable;
using System.Linq;
using NUnit.Framework;
using TicTacToe.Boundary;
using static TicTacToe.Boundary.CellValue;

namespace TicTacToe.Test
{
    public class ViewGridTest : IGridReader
    {
        private Grid _grid;

        public Grid Read()
        {
            return _grid;
        }

        private int NumberOfPiecesInGrid(CellValue piece, CellValue[] grid)
        {
            return grid.Where(value => value == piece).ToImmutableList().Count;
        }

        private bool IsXOnlyInPosition(int position, CellValue[] grid)
        {
            var xIsInPosition = grid[position] == X;
            var everythingElseIsBlank = NumberOfPiecesInGrid(Blank, grid) == 8;

            return xIsInPosition && everythingElseIsBlank;
        }

        private bool IsOOnlyInPosition(int position, CellValue[] grid)
        {
            var oIsInPosition = grid[position] == O;
            var onlyOneO = NumberOfPiecesInGrid(O, grid) == 1;

            return oIsInPosition && onlyOneO;
        }

        [SetUp]
        public void SetUp()
        {
            _grid = null;
        }

        [Test]
        public void CanViewEmptyGrid()
        {
            _grid = new GridBuilder().Build();

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
            _grid = new GridBuilder()
                .WithXAt(position)
                .Build();

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
        [TestCase(8)]
        public void CanViewAGridWithAnOPiecePlacedAnywhereBlank(int position)
        {
            _grid = new GridBuilder()
                .WithXAt(7)
                .WithOAt(position)
                .Build();

            var viewGrid = new ViewGrid(this);
            var viewGridResponse = viewGrid.Execute();
            Assert.IsTrue(IsOOnlyInPosition(position, viewGridResponse.Grid));
        }

        [Test]
        public void CanViewAGridWithMultipleXPieces()
        {
            _grid = new GridBuilder()
                .WithOAt(7)
                .WithXAt(6)
                .WithXAt(8)
                .Build();
            
            var viewGrid = new ViewGrid(this);
            var viewGridResponse = viewGrid.Execute();
            Assert.AreEqual(new[]
            {
                Blank, Blank, Blank,
                Blank, Blank, Blank,
                X, O, X
            }, viewGridResponse.Grid);
        }
    }
}