namespace TicTacToe
{
    public class PlacePiece
    {
        private readonly IPersistence _persistence;

        public PlacePiece(IPersistence persistence)
        {
            _persistence = persistence;
        }

        public void Execute(PlacePieceRequest placePieceRequest)
        {
            if (placePieceRequest != null)
            {
                _persistence.SaveXInPosition(placePieceRequest.Position);
            }
        }
    }
}