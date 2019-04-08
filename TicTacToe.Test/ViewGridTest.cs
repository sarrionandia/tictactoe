using NUnit.Framework;
using static TicTacToe.ViewGridResponse.CellValue;

namespace TicTacToe.Test
{
    public class ViewGridTest : IPersistence
    {
        [Test]
        public void CanViewEmptyGrid()
        {
            var viewGrid = new ViewGrid(this);
            var viewGridResponse = viewGrid.Execute();
            Assert.AreEqual(new []
            {
                Blank,Blank,Blank,
                Blank,Blank,Blank,
                Blank,Blank,Blank
            }, viewGridResponse.Grid);
        }
    }
}