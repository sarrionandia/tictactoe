using NUnit.Framework;

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
        public void PlacesPieceWhenCalled()
        {
            var placePiece = new PlacePiece(this);
            placePiece.Execute(new PlacePieceRequest() {Position = 0});
            
            Assert.AreEqual(0, _positionOfSavedPiece);
            
        }
        
        public bool IsThereAnXInPosition(int i)
        {
            throw new System.NotImplementedException();
        }

        public void SaveXInPosition(int position)
        {
            _positionOfSavedPiece = position;
        }
    }
}