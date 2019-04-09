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
        public void PlayerXSeesTheirPieceOnTheGridAfterPlacingIt()
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
        
                
        [Test]
        [Ignore("WIP")]
        public void PlayerOCanNotGoFirst()
        {
            _positionOfSavedX = null;
            var placePiece = new PlacePiece(this);
            placePiece.Execute(new PlacePieceRequest { Position = 4, Piece = O });
            
            var viewGrid = new ViewGrid(this);
            ViewGridResponse viewGridResponse = viewGrid.Execute();
            
            Assert.AreEqual(new []
            {
                Blank, Blank, Blank,
                Blank, Blank, Blank,
                Blank, Blank, Blank
            }, viewGridResponse.Grid);
        }

        public Grid Read()
        {
            return new Grid() { PositionOfX = _positionOfSavedX};
        }

        public void Save(Grid grid)
        {
            _positionOfSavedX = grid.PositionOfX;
        }
    }
}