namespace TicTacToe
{
    public class PlacePieceRequest
    {
        public int Position { get; set; }
        public ViewGridResponse.CellValue Piece { get; set; }
    }
}