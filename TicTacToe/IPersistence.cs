namespace TicTacToe
{
    public interface IPersistence
    {
        bool IsThereAnXInPosition(int i);

        void Save(Grid grid);
    }
}