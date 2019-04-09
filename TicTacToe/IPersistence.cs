namespace TicTacToe
{
    public interface IPersistence : IGridReader
    {
        void Save(Grid grid);
    }
}