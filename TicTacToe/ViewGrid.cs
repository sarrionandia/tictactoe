using TicTacToe.Boundary;
using static TicTacToe.Boundary.CellValue;

namespace TicTacToe
{
    public class ViewGrid
    {
        private readonly IGridReader _persistence;

        public ViewGrid(IGridReader persistence)
        {
            _persistence = persistence;
        }

        public ViewGridResponse Execute()
        {
            var cellValues = EmptyGrid();
            var grid = _persistence.Read();
            
            for (int i = 0; i < cellValues.Length; i++)
            {
                if (grid.IsThereAnXInPosition(i))
                {
                    cellValues[i] = X;
                }
            }

            return new ViewGridResponse
            {
                Grid = cellValues
            };
        }

        private static CellValue[] EmptyGrid() => new[]
            {
                Blank, Blank, Blank,
                Blank, Blank, Blank,
                Blank, Blank, Blank
            };
    }
}