namespace TicTacToe.Boundary
{
    public class PlacePieceRequest
    {
        public enum Move
        {
            X, O
        } 
        public int Position { get; set; }
        public Move Piece { get; set; }
    }
}