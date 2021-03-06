using System.Collections.Generic;
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

        private static int NumberOfPiecesInGrid(CellValue piece, IEnumerable<CellValue> grid)
        {
            return grid.Where(value => value == piece).ToImmutableList().Count;
        }

        private static bool IsXOnlyInPosition(int position, IReadOnlyList<CellValue> grid)
        {
            var xIsInPosition = grid[position] == X;
            var everythingElseIsBlank = NumberOfPiecesInGrid(Blank, grid) == 8;

            return xIsInPosition && everythingElseIsBlank;
        }

        private static bool IsOOnlyInPosition(int position, IReadOnlyList<CellValue> grid)
        {
            var oIsInPosition = grid[position] == O;
            var onlyOneO = NumberOfPiecesInGrid(O, grid) == 1;

            return oIsInPosition && onlyOneO;
        }
        
        private ViewGridResponse ViewGrid() => new ViewGrid(this).Execute();

        [SetUp]
        public void SetUp()
        {
            _grid = null;
        }

        [Test]
        public void CanViewEmptyGrid()
        {
            _grid = new GridBuilder().Build();

            var response = ViewGrid();

            Assert.AreEqual(new[]
            {
                Blank, Blank, Blank,
                Blank, Blank, Blank,
                Blank, Blank, Blank
            }, response.Grid);
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

            var response = ViewGrid();
            
            Assert.IsTrue(IsXOnlyInPosition(position, response.Grid));
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

            var response = ViewGrid();

            Assert.IsTrue(IsOOnlyInPosition(position, response.Grid));
        }

        [Test]
        public void CanViewAGridWithMultipleXPieces()
        {
            _grid = new GridBuilder()
                .WithOAt(7)
                .WithXAt(6)
                .WithXAt(8)
                .Build();
            
            var response = ViewGrid();

            Assert.AreEqual(new[]
            {
                Blank, Blank, Blank,
                Blank, Blank, Blank,
                X, O, X
            }, response.Grid);
        }
    }
}