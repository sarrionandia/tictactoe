namespace TicTacToe
{
    public interface IPersistence
    {
        bool IsThereAnXInPosition(int i);

        Grid Read();

        void Save(Grid grid);
    }
}