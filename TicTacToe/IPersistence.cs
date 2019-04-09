namespace TicTacToe
{
    public interface IPersistence
    {
        Grid Read();

        void Save(Grid grid);
    }
}