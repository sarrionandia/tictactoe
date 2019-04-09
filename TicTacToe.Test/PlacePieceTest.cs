using NUnit.Framework;

namespace TicTacToe.Test
{
    public class PlacePieceTest : IPersistence
    {
        private bool _called;

        [SetUp]
        public void SetUp()
        {
            _called = false;
        }
        
        [Test]
        public void DoesNotPlaceGivenNullRequest()
        {
            var placePiece = new PlacePiece(this);
            placePiece.Execute(null);
            
            Assert.IsFalse(_called);
        }
        
        public bool IsThereAnXInPosition(int i)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            
        }
    }
}