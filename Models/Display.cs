public class Display
{
    GameController gameController = new GameController(new Dice(6));
    private IBoard _board = new Board();
    public void ToConsole<T>(T input)
    {
        Console.Write(input);
    }

    public void PrintBoard()
    {
        _board.GenerateBoard();
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
                foreach (var item in gameController.GetPLayer())
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
                    if (_board.GetSnakeAndLadderPosition(iteratorLeftRight) > 0)
                    {
                        ToConsole("[" + _board.GetBoardPosition(iteratorLeftRight) + "]" + "   ");
                    }
                    else if (_board.GetSnakeAndLadderPosition(iteratorLeftRight) < 0)
                    {
                        ToConsole("{" + _board.GetBoardPosition(iteratorLeftRight) + "}" + "   ");
                    }
                    else
                    {
                        ToConsole(_board.GetBoardPosition(iteratorLeftRight) + "     ");
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
                foreach (var item in gameController.GetPLayer())
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
                    if (_board.GetSnakeAndLadderPosition(iteratorRightLeft) > 0)
                    {
                        ToConsole(iteratorRightLeft < 10 ? "[" + _board.GetBoardPosition(iteratorRightLeft) + "]" + "    " : "[" + _board.GetBoardPosition(iteratorRightLeft) + "]" + "   ");
                    }
                    else if (_board.GetSnakeAndLadderPosition(iteratorRightLeft) < 0)
                    {
                        ToConsole(iteratorRightLeft < 10 ? "{" + _board.GetBoardPosition(iteratorRightLeft) + "}" + "    " : "{" + _board.GetBoardPosition(iteratorRightLeft) + "}" + "   ");
                    }
                    else
                    {
                        ToConsole(iteratorRightLeft < 10 ? _board.GetBoardPosition(iteratorRightLeft) + "      " : _board.GetBoardPosition(iteratorRightLeft) + "     ");
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


    // private void StartDice()
    // {
    //     ToConsole("Set your maximum dice:  ");
    //     while (!int.TryParse(Console.ReadLine(), out _maxDice))
    //     {
    //         Console.WriteLine("Integers only allowed.");
    //         Console.Write("Enter a number: ");
    //     }
    //     _dice.SetMaxDice(_maxDice);
    // }

    private void StartExecuteGame()
    {
        while (!gameController.GetWinCondition())
        {
            foreach (var item in gameController.GetPLayer())
            {
                int diceRoll = gameController.diceRoll();
                ToConsole(item.Key + " please press enter to roll the dice\n");
                Console.ReadKey();
                gameController.MovePlayer(item.Key, diceRoll, _board);
                PrintBoard();
                ToConsole(item.Key + " got " + diceRoll + " now at " + gameController.GetPLayer()[item.Key] + "\n");

                if (gameController.GetPLayer()[item.Key] >= 100)
                {
                    ToConsole(item.Key + " win!");
                    gameController.GetPLayer().Clear();
                    gameController.SetWinCondition(true);
                    break;
                }
            }
        }
    }

    private void CheckPlayAgain()
    {
        ToConsole("\nDo You Want to play again?(y/n)");
        string check = Console.ReadLine()!;
        if (check.ToLower() == "y")
        {

            gameController.SetWinCondition(false);

            gameController.SetGameStatus(true);
        }
        else
        {
            ToConsole("\nThank you for playing!");
            gameController.SetGameStatus(false);
        }
    }

    private void DisplayText()
    {
        ToConsole("Snake and Ladder Game\n");
        ToConsole("Ladder are [] while snake are {}! \n");
    }

    private void StartPlayer()
    {
        int maxPlayer;
        ToConsole("How Many Players? ");
        while (!int.TryParse(Console.ReadLine(), out maxPlayer))
        {
            Console.WriteLine("Integers only allowed.");
            Console.Write("Enter a number: ");
        }
        gameController.CreatePlayer(maxPlayer);
    }

    public void StartGame()
    {
        while (gameController.GetGameStatus())
        {
            DisplayText();
            StartPlayer();
            // StartDice();
            StartExecuteGame();
            CheckPlayAgain();
        }
    }
}