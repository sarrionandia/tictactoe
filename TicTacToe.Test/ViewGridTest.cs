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
        public void CanViewAGridWithPiecePlacedInTopLeftCorner()
        {
            _positionOfX = 0;
            var viewGrid = new ViewGrid(this);
            var viewGridResponse = viewGrid.Execute();
            Assert.AreEqual(new []
            {
                X,Blank,Blank,
                Blank,Blank,Blank,
                Blank,Blank,Blank
            }, viewGridResponse.Grid);
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


        public bool IsThereAnXInPosition(int i)
        {
            return _positionOfX == i;
        }
    }
}