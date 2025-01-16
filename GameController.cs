using System.Linq;


public class GameController
{

    int maxPlayer = 0;
    int maxDice = 0;
    bool won = false;

    bool gameStart = true;

    Board board = new();

    Dictionary<Player, int> player = new();

    Display display = new();

    Dice dice = new();

    private void PrintBoard()
    {
        board.GenerateBoard();
        int alt = 0;
        int iteratorLeftRight = 101;
        int iteratorRightLeft = 80;
        int value = 100;


        while (value <= 100)
        {
            bool containPlayer = false;
            if (alt == 0)
            {
                string holdPlayerKey = "";
                iteratorLeftRight--;
                foreach (var item in player)
                {
                    if (iteratorLeftRight == item.Value)
                    {
                        containPlayer = true;
                        holdPlayerKey = item.Key + "     ";
                        // display.ToConsole(item.Key + "     ");
                    }
                }

                if (containPlayer == true)
                {
                    display.ToConsole(holdPlayerKey);
                }

                if (containPlayer == false)
                {
                    if (board.GetSnakeAndLadderPosition(iteratorLeftRight) > 0)
                    {
                        display.ToConsole("[" + board.GetBoard(iteratorLeftRight) + "]" + "   ");
                    }
                    else if (board.GetSnakeAndLadderPosition(iteratorLeftRight) < 0)
                    {
                        display.ToConsole("{" + board.GetBoard(iteratorLeftRight) + "}" + "   ");
                    }
                    else
                    {
                        display.ToConsole(board.GetBoard(iteratorLeftRight) + "     ");
                    }
                }

                if (iteratorLeftRight % 10 == 1)
                {
                    display.ToConsole("\n\n");
                    alt = 1;
                    iteratorLeftRight -= 10;
                }
            }
            else
            {
                iteratorRightLeft++;
                string holdPlayerKey = "";
                foreach (var item in player)
                {
                    if (iteratorRightLeft == item.Value)
                    {
                        containPlayer = true;
                        holdPlayerKey = item.Key + "     ";
                        // display.ToConsole(item.Key + "     ");
                    }
                }

                if (containPlayer == true)
                {
                    display.ToConsole(holdPlayerKey);
                }

                if (containPlayer == false)
                {
                    if (board.GetSnakeAndLadderPosition(iteratorRightLeft) > 0)
                    {

                        if (iteratorRightLeft < 10)
                        {
                            display.ToConsole("[" + board.GetBoard(iteratorRightLeft) + "]" + "    ");
                        }
                        else
                        {
                            display.ToConsole("[" + board.GetBoard(iteratorRightLeft) + "]" + "   ");

                        }
                    }
                    else if (board.GetSnakeAndLadderPosition(iteratorRightLeft) < 0)
                    {

                        if (iteratorRightLeft < 10)
                        {
                            display.ToConsole("{" + board.GetBoard(iteratorRightLeft) + "}" + "    ");
                        }
                        else
                        {
                            display.ToConsole("{" + board.GetBoard(iteratorRightLeft) + "}" + "   ");

                        }
                    }
                    else
                    {
                        if (iteratorRightLeft < 10)
                        {
                            display.ToConsole(board.GetBoard(iteratorRightLeft) + "      ");
                        }
                        else
                        {
                            display.ToConsole(board.GetBoard(iteratorRightLeft) + "     ");
                        }

                    }
                }


                if (iteratorRightLeft % 10 == 0)
                {
                    display.ToConsole("\n\n");
                    alt = 0;
                    iteratorRightLeft -= 30;
                }

            }
            value--;
            if (value == 0)
            {
                break;
            }
            if (iteratorRightLeft == 10)
            {
                break;
            }
        }
    }

    private void CreatePlayer(int numberOfUser)
    {

        for (int i = 1; i <= numberOfUser; i++)
        {
            Player playerClass = new Player("P" + i);
            player.Add(playerClass, 1);

        }

        display.ToConsole("Successfully add " + numberOfUser + " players\n");

    }
    private void MovePlayer(Player key, int dice)
    {
        board.GenerateSnakeAndLadder();

        int newPosition = player[key] + dice;
        int newPositionTotal;


        newPositionTotal = newPosition + board.GetSnakeAndLadderPosition(newPosition);

        if (newPositionTotal > 100)
        {
            player[key] = 100;
        }
        else
        {
            player[key] = newPositionTotal;

        }


    }

    private void StartPlayer()
    {
        display.ToConsole("How Many Players? ");
        while (!int.TryParse(Console.ReadLine(), out maxPlayer))
        {
            Console.WriteLine("Integers only allowed.");
            Console.Write("Enter a number: ");

        }

        CreatePlayer(maxPlayer);
    }

    private void StartDice()
    {
        display.ToConsole("Set your maximum dice:  ");
        while (!int.TryParse(Console.ReadLine(), out maxDice))
        {
            Console.WriteLine("Integers only allowed.");
            Console.Write("Enter a number: ");

        }

        dice.SetMaxDice(maxDice);
    }

    private void StartExecuteGame()
    {
        while (!won)
        {

            //foreach dictionarynya
            foreach (var item in player)
            {
                int diceRoll = dice.GetDice();
                display.ToConsole(item.Key + " please press enter to roll the dice\n");
                Console.ReadKey();

                MovePlayer(item.Key, diceRoll);
                PrintBoard();
                display.ToConsole(item.Key + " got " + diceRoll + " now at " + player[item.Key] + "\n");

                if (player[item.Key] >= 100)
                {

                    display.ToConsole(item.Key + " win!");
                    player.Clear();
                    won = true;
                    break;
                }

            }
        }
    }

    private void CheckPlayAgain()
    {
        string Check;
        display.ToConsole("\nDo You Want to play again?(y/n)");
        Check = Console.ReadLine()!;
        if (Check.ToLower() == "y")
        {
            won = false;
            gameStart = true;
        }
        else
        {
            display.ToConsole("\nThank you for playing!");
            gameStart = false;
        }
    }

    private void DisplayText()
    {
        display.ToConsole("Snake and Ladder Game\n");
        display.ToConsole("Ladder are [] while snake are {}! \n");
    }
    public void StartGame()
    {
        while (gameStart)
        {
            DisplayText();
            StartPlayer();
            StartDice();
            StartExecuteGame();
            CheckPlayAgain();
        }
        //console ditaruh di class baru
    }
}