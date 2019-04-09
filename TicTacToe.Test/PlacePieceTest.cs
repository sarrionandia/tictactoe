using NUnit.Framework;
using TicTacToe.Boundary;
using static TicTacToe.Boundary.CellValue;

namespace TicTacToe.Test
{
    public class PlacePieceTest : IPersistence
    {
        private int? _positionOfSavedXPiece;
        private int? _positionOfSavedOPiece;
        
        public Grid Read()
        {
            return new Grid
            {
                PositionOfX = _positionOfSavedXPiece, 
                PositionOfO = _positionOfSavedOPiece
            };
        }

        public void Save(Grid grid)
        {
            _positionOfSavedXPiece = grid.PositionOfX;
            _positionOfSavedOPiece = grid.PositionOfO;
        }
        
        private void PlacePiece(PlacePieceRequest request) 
            => new PlacePiece(this).Execute(request);
        
        [SetUp]
        public void SetUp()
        {
            _positionOfSavedXPiece = null;
            _positionOfSavedOPiece = null;
        }
        
        [Test]
        public void DoesNotPlaceGivenNullRequest()
        {
            PlacePiece(null);
            
            Assert.IsNull(_positionOfSavedXPiece);
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
        public void PlacesXPieceInAnyPosition(int position)
        {
            PlacePiece(new PlacePieceRequest() {Position = position, Piece = X});
            
            Assert.AreEqual(position, _positionOfSavedXPiece);
            Assert.IsNull(_positionOfSavedOPiece);
        }

        [Test]
        public void PlacesOPieceInFirstPositionOnSecondMove()
        {
            _positionOfSavedXPiece = 1;
            PlacePiece(new PlacePieceRequest {Position = 0, Piece = O});
            Assert.AreEqual(0, _positionOfSavedOPiece);
        }
        
        [Test]
        public void PlacesOPieceInLastPositionOnSecondMove()
        {
            _positionOfSavedXPiece = 1;
            PlacePiece(new PlacePieceRequest {Position = 8, Piece = O});
            Assert.AreEqual(8, _positionOfSavedOPiece);
            Assert.AreEqual(1, _positionOfSavedXPiece);
        }

        [Test]
        public void ShouldNotSaveGridIfFirstMoveIsO()
        {
            PlacePiece(new PlacePieceRequest{Position = 3, Piece = O});
            Assert.IsNull(_positionOfSavedOPiece);
        }
    }
}