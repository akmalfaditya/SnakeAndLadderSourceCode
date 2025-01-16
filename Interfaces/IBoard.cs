public interface IBoard
{
    void GenerateBoard();
    int GetBoardPosition(int index);
    void GenerateSnakeAndLadder();
    int GetSnakeAndLadderPosition(int position);
}