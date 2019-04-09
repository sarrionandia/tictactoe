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

            for (int i = 0; i < cellValues.Length; i++)
            {
                if (_persistence.IsThereAnXInPosition(i))
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