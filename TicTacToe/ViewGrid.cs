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
            var cellValues = EmptyGrid();
            var grid = _persistence.Read();
            
            for (int i = 0; i < cellValues.Length; i++)
            {
                if (grid.PositionOfX == i)
                {
                    cellValues[i] = X;
                }
            }

            return new ViewGridResponse
            {
                Grid = cellValues
            };
        }

        private static ViewGridResponse.CellValue[] EmptyGrid() => new[]
            {
                Blank, Blank, Blank,
                Blank, Blank, Blank,
                Blank, Blank, Blank
            };
    }
}