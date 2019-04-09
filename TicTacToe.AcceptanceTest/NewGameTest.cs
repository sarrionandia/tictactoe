using NUnit.Framework;
using TicTacToe.Boundary;
using static TicTacToe.Boundary.CellValue;

namespace TicTacToe.AcceptanceTest
{
    public class NewGameTest : IPersistence
    {
        private Grid _grid;
        private PlacePiece _placePiece;
        private ViewGrid _viewGrid;

        public Grid Read()
        {
            return _grid;
        }

        public void Save(Grid grid)
        {
            _grid = grid;
        }

        [SetUp]
        public void SetUp()
        {
            _placePiece = new PlacePiece(this);
            _viewGrid = new ViewGrid(this);
            _grid = new Grid();
        }

        [Test]
        public void PlayerSeesEmptyGridAtBeginningOfTheGame()
        {
            ViewGridResponse viewGridResponse = _viewGrid.Execute();

            Assert.AreEqual(new[]
            {
                Blank, Blank, Blank,
                Blank, Blank, Blank,
                Blank, Blank, Blank
            }, viewGridResponse.Grid);
        }

        [Test]
        public void PlayerXSeesTheirPieceOnTheGridAfterPlacingIt()
        {
            _placePiece.Execute(new PlacePieceRequest {Position = 4, Piece = X});

            ViewGridResponse viewGridResponse = _viewGrid.Execute();

            Assert.AreEqual(new[]
            {
                Blank, Blank, Blank,
                Blank, X, Blank,
                Blank, Blank, Blank
            }, viewGridResponse.Grid);
        }


        [Test]
        public void PlayerOCanNotGoFirst()
        {
            _placePiece.Execute(new PlacePieceRequest {Position = 4, Piece = O});

            ViewGridResponse viewGridResponse = _viewGrid.Execute();

            Assert.AreEqual(new[]
            {
                Blank, Blank, Blank,
                Blank, Blank, Blank,
                Blank, Blank, Blank
            }, viewGridResponse.Grid);
        }

        [Test]
        public void PlayerOCanGoSecond()
        {
            _placePiece.Execute(new PlacePieceRequest {Position = 4, Piece = X});
            _placePiece.Execute(new PlacePieceRequest {Position = 5, Piece = O});

            ViewGridResponse viewGridResponse = _viewGrid.Execute();

            Assert.AreEqual(new[]
            {
                Blank, Blank, Blank,
                Blank, X, O,
                Blank, Blank, Blank
            }, viewGridResponse.Grid);
        }
        
        [Test]
        public void PlayerOCantPlacePieceOnTopOfX()
        {
            _placePiece.Execute(new PlacePieceRequest {Position = 6, Piece = X});
            _placePiece.Execute(new PlacePieceRequest {Position = 6, Piece = O});

            ViewGridResponse viewGridResponse = _viewGrid.Execute();

            Assert.AreEqual(new[]
            {
                Blank, Blank, Blank,
                Blank, Blank, Blank,
                X, Blank, Blank
            }, viewGridResponse.Grid);
        }
    }
}