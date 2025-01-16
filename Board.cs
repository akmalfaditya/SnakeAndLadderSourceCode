public class Board()
{

    private int[] board = new int[101];
    private int[] snakeAndLadder = new int[101];




    public void GenerateSnakeAndLadder()
    {
        for (int i = 0; i <= 100; i++)
        {
            snakeAndLadder[i] = 0;
        }

        snakeAndLadder[6] = 40;
        snakeAndLadder[23] = -10;
        snakeAndLadder[45] = -7;
        snakeAndLadder[61] = -18;
        snakeAndLadder[65] = -8;
        snakeAndLadder[77] = 5;
        snakeAndLadder[98] = -10;

    }

    public int GetSnakeAndLadderPosition(int position)
    {
        if (position>=101){
            return snakeAndLadder[0];
        }else{
            return snakeAndLadder[position];

        }
        
    }



    public void GenerateBoard()
    {
        for (int i = 1; i <= 100; i++)
        {
            board[i] = i;
        }
    }

    public int GetBoard(int index)
    {
        return board[index];
    }






}