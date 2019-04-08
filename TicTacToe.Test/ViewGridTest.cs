using NUnit.Framework;
using static TicTacToe.ViewGridResponse.CellValue;

namespace TicTacToe.Test
{
    public class ViewGridTest : IPersistence
    {
        private int? _positionOfX;

        [Test]
        public void CanViewEmptyGrid()
        {
            _positionOfX = null;
            var viewGrid = new ViewGrid(this);
            var viewGridResponse = viewGrid.Execute();
            Assert.AreEqual(new []
            {
                Blank,Blank,Blank,
                Blank,Blank,Blank,
                Blank,Blank,Blank
            }, viewGridResponse.Grid);
        }

        [Test]
        [TestCase(0, new []
        {
            X,Blank,Blank,
            Blank,Blank,Blank,
            Blank,Blank,Blank
        })]
        [TestCase(1, new []
        {
            Blank,X,Blank,
            Blank,Blank,Blank,
            Blank,Blank,Blank
        })]
        [TestCase(2, new []
        {
            Blank,Blank, X,
            Blank,Blank,Blank,
            Blank,Blank,Blank
        })]
        [TestCase(3, new []
        {
            Blank,Blank,Blank,
            X,Blank,Blank,
            Blank,Blank,Blank
        })]
        [TestCase(4, new []
        {
            Blank,Blank,Blank,
            Blank,X,Blank,
            Blank,Blank,Blank
        })]
        [TestCase(5, new []
        {
            Blank,Blank,Blank,
            Blank,Blank,X,
            Blank,Blank,Blank
        })]
        [TestCase(6, new []
        {
            Blank,Blank,Blank,
            Blank,Blank,Blank,
            X,Blank,Blank
        })]
        [TestCase(7, new []
        {
            Blank,Blank,Blank,
            Blank,Blank,Blank,
            Blank,X,Blank
        })]
        [TestCase(8, new []
        {
            Blank,Blank,Blank,
            Blank,Blank,Blank,
            Blank,Blank,X
        })]
        public void CanViewAGridWithPiecePlacedInTopLeftCorner(
            int position, ViewGridResponse.CellValue[] expectedGrid
        )
        {
            _positionOfX = position;
            var viewGrid = new ViewGrid(this);
            var viewGridResponse = viewGrid.Execute();
            Assert.AreEqual(expectedGrid, viewGridResponse.Grid);
        }
        
        [Test]
        public void CanViewAGridWithOnePiecePlacedSomewhereInMiddleOfGrid()
        {
            _positionOfX = 4;
            var viewGrid = new ViewGrid(this);
            var viewGridResponse = viewGrid.Execute();
            Assert.AreEqual(new []
            {
                Blank,Blank,Blank,
                Blank,X,Blank,
                Blank,Blank,Blank
            }, viewGridResponse.Grid);
        }
        
        [Test]
        public void CanViewAGridWithOnePiecePlacedSomewhereInMiddleOfGrid2()
        {
            _positionOfX = 8;
            var viewGrid = new ViewGrid(this);
            var viewGridResponse = viewGrid.Execute();
            Assert.AreEqual(new []
            {
                Blank,Blank,Blank,
                Blank,Blank,Blank,
                Blank,Blank,X
            }, viewGridResponse.Grid);
        }
        
        public bool IsThereAnXInPosition(int i)
        {
            return _positionOfX == i;
        }
    }
}