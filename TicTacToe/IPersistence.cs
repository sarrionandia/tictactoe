namespace TicTacToe
{
    public interface IPersistence
    {
        bool IsThereAnXInPosition(int i);

        void SaveXInPosition(int position);

        void Save(Grid grid);
    }
}