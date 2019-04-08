using static TicTacToe.ViewGridResponse.CellValue;

namespace TicTacToe
{
    public class ViewGrid
    {
        private readonly IPersistence _persistence;

        public ViewGrid(IPersistence persistence)
        {
            _persistence = persistence;
        }

        public ViewGridResponse Execute()
        {
            if (_persistence.IsThereAnXInPosition(4))
            {
                return new ViewGridResponse
                {
                    Grid = new[]
                    {
                        Blank, Blank, Blank,
                        Blank, X, Blank,
                        Blank, Blank, Blank
                    }
                };
            }
            
            return _persistence.IsThereAnXInPosition(0)
                ? new ViewGridResponse
                {
                    Grid = new[]
                    {
                        X, Blank, Blank,
                        Blank, Blank, Blank,
                        Blank, Blank, Blank
                    }
                }
                : new ViewGridResponse
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