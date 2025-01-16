public class Display : IDisplay
{
    public void ToConsole<T>(T input)
    {
        Console.Write(input);
    }

    public void PrintBoard(Dictionary<Player, int> playerPositions, IBoard board)
    {
        board.GenerateBoard();
        int alt = 0;
        int iteratorLeftRight = 101;
        int iteratorRightLeft = 80;
        int value = 100;

        while (value <= 100)
        {
            bool containPlayer = false;
            string holdPlayerKey = "";
            if (alt == 0)
            {
                iteratorLeftRight--;
                foreach (var item in playerPositions)
                {
                    if (iteratorLeftRight == item.Value)
                    {
                        containPlayer = true;
                        holdPlayerKey = item.Key + "     ";
                    }
                }

                if (containPlayer)
                {
                    ToConsole(holdPlayerKey);
                }
                else
                {
                    if (board.GetSnakeAndLadderPosition(iteratorLeftRight) > 0)
                    {
                        ToConsole("[" + board.GetBoardPosition(iteratorLeftRight) + "]" + "   ");
                    }
                    else if (board.GetSnakeAndLadderPosition(iteratorLeftRight) < 0)
                    {
                        ToConsole("{" + board.GetBoardPosition(iteratorLeftRight) + "}" + "   ");
                    }
                    else
                    {
                        ToConsole(board.GetBoardPosition(iteratorLeftRight) + "     ");
                    }
                }

                if (iteratorLeftRight % 10 == 1)
                {
                    ToConsole("\n\n");
                    alt = 1;
                    iteratorLeftRight -= 10;
                }
            }
            else
            {
                iteratorRightLeft++;
                foreach (var item in playerPositions)
                {
                    if (iteratorRightLeft == item.Value)
                    {
                        containPlayer = true;
                        holdPlayerKey = item.Key + "     ";
                    }
                }

                if (containPlayer)
                {
                    ToConsole(holdPlayerKey);
                }
                else
                {
                    if (board.GetSnakeAndLadderPosition(iteratorRightLeft) > 0)
                    {
                        ToConsole(iteratorRightLeft < 10 ? "[" + board.GetBoardPosition(iteratorRightLeft) + "]" + "    " : "[" + board.GetBoardPosition(iteratorRightLeft) + "]" + "   ");
                    }
                    else if (board.GetSnakeAndLadderPosition(iteratorRightLeft) < 0)
                    {
                        ToConsole(iteratorRightLeft < 10 ? "{" + board.GetBoardPosition(iteratorRightLeft) + "}" + "    " : "{" + board.GetBoardPosition(iteratorRightLeft) + "}" + "   ");
                    }
                    else
                    {
                        ToConsole(iteratorRightLeft < 10 ? board.GetBoardPosition(iteratorRightLeft) + "      " : board.GetBoardPosition(iteratorRightLeft) + "     ");
                    }
                }

                if (iteratorRightLeft % 10 == 0)
                {
                    ToConsole("\n\n");
                    alt = 0;
                    iteratorRightLeft -= 30;
                }
            }
            value--;
            if (value == 0 || iteratorRightLeft == 10) break;
        }
    }
}