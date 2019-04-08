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
        
        [Test]
        [Ignore("WIP")]
        public void PlayerSeesTheirPieceOnTheGridAfterPlacingIt()
        {
            var placePiece = new PlacePiece(this);
            placePiece.Execute(new PlacePieceRequest { Position = 4 });
            
            var viewGrid = new ViewGrid(this);
            ViewGridResponse viewGridResponse = viewGrid.Execute();
            
            Assert.AreEqual(new []
            {
                Blank, Blank, Blank,
                Blank, X, Blank,
                Blank, Blank, Blank
            }, viewGridResponse.Grid);
        }

        public bool IsThereAnXInPosition(int i)
        {
            return false;
        }
    }
}