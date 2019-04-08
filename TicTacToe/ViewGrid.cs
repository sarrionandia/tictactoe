using static TicTacToe.ViewGridResponse.CellValue;

namespace TicTacToe
{
    public class ViewGrid
    {
        public ViewGrid(IPersistence newGameTest)
        {
        }

        public ViewGridResponse Execute()
        {
            return new ViewGridResponse
            {
                Grid = new[]
                {
                    Blank, Blank, Blank,
                    Blank, Blank, Blank,
                    Blank, Blank, Blank
                }
            };
        }
    }
}