public class Board : IBoard
{
    private int[] _board = new int[101];
    private int[] _snakeAndLadder = new int[101];

    public void GenerateBoard()
    {
        for (int i = 1; i <= 100; i++)
        {
            _board[i] = i;
        }
    }

    public int GetBoardPosition(int index)
    {
        if (index > 100 || index < 1) 
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 1 and 100.");
        }
        return _board[index];
    }

    public void GenerateSnakeAndLadder()
    {
        for (int i = 0; i <= 100; i++)
        {
            _snakeAndLadder[i] = 0;
        }

        _snakeAndLadder[6] = 40;
        _snakeAndLadder[23] = -10;
        _snakeAndLadder[45] = -7;
        _snakeAndLadder[61] = -18;
        _snakeAndLadder[65] = -8;
        _snakeAndLadder[77] = 5;
        _snakeAndLadder[98] = -10;
    }

    public int GetSnakeAndLadderPosition(int position)
    {
        if (position > 100 || position < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position must be between 1 and 100.");
        }
        return _snakeAndLadder[position];
    }
}