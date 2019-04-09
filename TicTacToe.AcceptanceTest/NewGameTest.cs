using NUnit.Framework;
using TicTacToe.Boundary;
using static TicTacToe.Boundary.CellValue;

namespace TicTacToe.AcceptanceTest
{
    public class NewGameTest : IPersistence
    {
        private Grid _grid;

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
            _grid = new Grid();
        }

        [Test]
        public void PlayerSeesEmptyGridAtBeginningOfTheGame()
        {
            var viewGrid = new ViewGrid(this);
            ViewGridResponse viewGridResponse = viewGrid.Execute();

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
            var placePiece = new PlacePiece(this);
            placePiece.Execute(new PlacePieceRequest {Position = 4});

            var viewGrid = new ViewGrid(this);
            ViewGridResponse viewGridResponse = viewGrid.Execute();

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
            var placePiece = new PlacePiece(this);
            placePiece.Execute(new PlacePieceRequest {Position = 4, Piece = O});

            var viewGrid = new ViewGrid(this);
            ViewGridResponse viewGridResponse = viewGrid.Execute();

            Assert.AreEqual(new[]
            {
                Blank, Blank, Blank,
                Blank, Blank, Blank,
                Blank, Blank, Blank
            }, viewGridResponse.Grid);
        }

        [Test]
        [Ignore("WIP")]
        public void PlayerOCanGoSecond()
        {
            var placePiece = new PlacePiece(this);
            placePiece.Execute(new PlacePieceRequest {Position = 4, Piece = X});
            placePiece.Execute(new PlacePieceRequest {Position = 5, Piece = O});

            var viewGrid = new ViewGrid(this);
            ViewGridResponse viewGridResponse = viewGrid.Execute();

            Assert.AreEqual(new[]
            {
                Blank, Blank, Blank,
                Blank, X, O,
                Blank, Blank, Blank
            }, viewGridResponse.Grid);
        }
    }
}