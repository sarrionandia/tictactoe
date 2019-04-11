using System.Linq;
using System.Threading.Tasks.Dataflow;
using NUnit.Framework;
using TicTacToe.Boundary;
using static TicTacToe.Boundary.PlacePieceRequest.Move;

namespace TicTacToe.Test
{
    public class PlacePieceTest : IPersistence
    {
        private int? _positionOfSavedXPiece;
        private int? _positionOfSavedOPiece;

        private Grid _grid;
        
        public Grid Read()
        {
            var build = new GridBuilder();
            if (_positionOfSavedOPiece != null) build.WithOAt(_positionOfSavedOPiece ?? 0);
            if (_positionOfSavedXPiece != null) build.WithXAt(_positionOfSavedXPiece ?? 0);
            return _grid ?? build.Build();
        }

        public void Save(Grid grid)
        {
            _grid = grid;
        }
        
        private void PlacePiece(PlacePieceRequest request) 
            => new PlacePiece(this).Execute(request);
        
        [SetUp]
        public void SetUp()
        {
            _grid = null;
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
        public void PlacesXPieceInAnyPosition(int position)
        {
            PlacePiece(new PlacePieceRequest() {Position = position, Piece = X});
            
            Assert.AreEqual(Grid.PieceType.X, _grid.Pieces[position]);

            Assert.IsEmpty(_grid.Pieces.Where(t => t == Grid.PieceType.O));
        }

        [Test]
        public void PlacesOPieceInFirstPositionOnSecondMove()
        {
            _positionOfSavedXPiece = 1;
            PlacePiece(new PlacePieceRequest {Position = 0, Piece = O});
            Assert.AreEqual(Grid.PieceType.O, _grid.Pieces[0]);
        }
        
        [Test]
        public void PlacesOPieceInLastPositionOnSecondMove()
        {
            _positionOfSavedXPiece = 1;
            PlacePiece(new PlacePieceRequest {Position = 8, Piece = O});
            Assert.AreEqual(Grid.PieceType.O, _grid.Pieces[8]);
            Assert.AreEqual(Grid.PieceType.X, _grid.Pieces[1]);
        }

        [Test]
        public void ShouldNotSaveGridIfFirstMoveIsO()
        {
            PlacePiece(new PlacePieceRequest{Position = 3, Piece = O});
            Assert.IsNull(_positionOfSavedOPiece);
            Assert.IsNull(_grid);
        }

        [Test]
        public void ShouldNotSaveGridIfOClashesWithExistingX()
        {
            _positionOfSavedXPiece = 2;
            PlacePiece(new PlacePieceRequest{Position = 2, Piece = O});
            Assert.IsNull(_grid);
        }

        [Test]
        public void ShouldNotLetXPlayTheSecondMove()
        {
            _positionOfSavedXPiece = 2;
            PlacePiece(new PlacePieceRequest{Position = 5, Piece = X});
            Assert.IsNull(_grid);
        }
    }
}