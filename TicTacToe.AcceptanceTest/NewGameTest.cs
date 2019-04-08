using NUnit.Framework;
using static TicTacToe.ViewGridResponse.CellValue;

namespace TicTacToe.AcceptanceTest
{
    public class NewGameTest : IPersistence
    {
        [Test]
        public void PlayerSeesEmptyGridAtBeginningOfTheGame()
        {
            var viewGrid = new ViewGrid(this);
            ViewGridResponse viewGridResponse = viewGrid.Execute();
            
            Assert.AreEqual(new []
            {
                Blank, Blank, Blank,
                Blank, Blank, Blank,
                Blank, Blank, Blank
            }, viewGridResponse.Grid);
        }
    }
}