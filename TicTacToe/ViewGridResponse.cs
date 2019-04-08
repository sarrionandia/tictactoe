namespace TicTacToe
{
    public class ViewGridResponse
    {
        public enum CellValue
        {
            Blank, X, O
        }

        public CellValue[] Grid { get; set; }
    }
}