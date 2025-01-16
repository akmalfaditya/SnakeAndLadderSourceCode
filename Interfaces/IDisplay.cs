public interface IDisplay
{
    void ToConsole<T>(T input);
    void PrintBoard(Dictionary<Player, int> playerPositions, IBoard board);
}