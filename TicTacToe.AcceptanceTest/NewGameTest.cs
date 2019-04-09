using NUnit.Framework;
using static TicTacToe.ViewGridResponse.CellValue;

namespace TicTacToe.AcceptanceTest
{
    public class NewGameTest : IPersistence
    {
        private int? _positionOfSavedX;

        [Test]
        public void PlayerSeesEmptyGridAtBeginningOfTheGame()
        {
            _positionOfSavedX = null;
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
        public void PlayerSeesTheirPieceOnTheGridAfterPlacingIt()
        {
            _positionOfSavedX = null;
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
            return _positionOfSavedX == i;
        }

        public void SaveXInPosition(int position)
        {
            _positionOfSavedX = position;
        }
    }
}