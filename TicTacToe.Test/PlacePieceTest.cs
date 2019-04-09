using NUnit.Framework;
using TicTacToe.Boundary;

namespace TicTacToe.Test
{
    public class PlacePieceTest : IPersistence
    {
        private int? _positionOfSavedPiece;

        [SetUp]
        public void SetUp()
        {
            _positionOfSavedPiece = null;
        }
        
        [Test]
        public void DoesNotPlaceGivenNullRequest()
        {
            var placePiece = new PlacePiece(this);
            placePiece.Execute(null);
            
            Assert.IsNull(_positionOfSavedPiece);
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
        [TestCase(9)]
        public void PlacesPieceInAnyPosition(int position)
        {
            var placePiece = new PlacePiece(this);
            placePiece.Execute(new PlacePieceRequest() {Position = position});
            
            Assert.AreEqual(position, _positionOfSavedPiece);
        }

        public Grid Read()
        {
            return new Grid {PositionOfX = _positionOfSavedPiece};
        }

        public void Save(Grid grid)
        {
            _positionOfSavedPiece = grid.PositionOfX;
        }
    }
}