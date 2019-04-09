namespace TicTacToe
{
    public class GridBuilder
    {
        private int? _xPosition;
        private int? _oPosition;

        public GridBuilder(Grid existingGrid)
        {
            _oPosition = existingGrid.PositionOfO;
            _xPosition = existingGrid.PositionOfX;
        }

        public Grid Build()
        {
            return new Grid {PositionOfX = _xPosition, PositionOfO = _oPosition};
        }

        public GridBuilder WithXAt(int rPosition)
        {
            _xPosition = rPosition;
            return this;
        }

        public GridBuilder WithOAt(int rPosition)
        {
            _oPosition = rPosition;
            return this;
        }
    }
}