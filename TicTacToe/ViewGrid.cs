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
            var cellValues = new[]
            {
                Blank, Blank, Blank,
                Blank, Blank, Blank,
                Blank, Blank, Blank
            };
            
            if (_persistence.IsThereAnXInPosition(0)) cellValues[0] = X;
            if (_persistence.IsThereAnXInPosition(1)) cellValues[1] = X;
            if (_persistence.IsThereAnXInPosition(2)) cellValues[2] = X;
            if (_persistence.IsThereAnXInPosition(3)) cellValues[3] = X;
            if (_persistence.IsThereAnXInPosition(4)) cellValues[4] = X;
            if (_persistence.IsThereAnXInPosition(5)) cellValues[5] = X;
            if (_persistence.IsThereAnXInPosition(6)) cellValues[6] = X;
            if (_persistence.IsThereAnXInPosition(7)) cellValues[7] = X;
            if (_persistence.IsThereAnXInPosition(8)) cellValues[8] = X;
            
            return new ViewGridResponse
            {
                Grid = cellValues
            };
        }
    }
}