namespace TicTacToe.Boundary
{
    public class PlacePieceRequest
    {
        public int Position { get; set; }
        public CellValue Piece { get; set; }
    }
}