
// ditaruh di display, gamecontroller cm ngirim data mentah
//jadi IDice dari program main
//pakeaccessmodifier private & underscore

//better jd interface semua
//console ditaruh di class baru
public class GameController
{
    private int _maxPlayer;
   
    private bool _won = false;
    private bool _gameStart = true;
    private IBoard _board ;
    private Dictionary<Player, int> _player = new Dictionary<Player, int>();
    private IDisplay _display ;
    private IDice _dice;

    public GameController(Dice dice, Board board, Display display)
    {
        _board = board;
        _dice = dice;
        _display = display;
    }

    private void CreatePlayer(int numberOfUser)
    {
        for (int i = 1; i <= numberOfUser; i++)
        {
            Player playerClass = new Player("P" + i);
            _player.Add(playerClass, 1);
        }
        _display.ToConsole("Successfully add " + numberOfUser + " players\n");
    }

    private void MovePlayer(Player key, int dice)
    {
        _board.GenerateSnakeAndLadder();
        int newPosition = _player[key] + dice;
        int newPositionTotal = newPosition + _board.GetSnakeAndLadderPosition(newPosition);

        _player[key] = newPositionTotal > 100 ? 100 : newPositionTotal;
    }

    private void StartPlayer()
    {
        _display.ToConsole("How Many Players? ");
        while (!int.TryParse(Console.ReadLine(), out _maxPlayer))
        {
            Console.WriteLine("Integers only allowed.");
            Console.Write("Enter a number: ");
        }
        CreatePlayer(_maxPlayer);
    }

    // private void StartDice()
    // {
    //     _display.ToConsole("Set your maximum dice:  ");
    //     while (!int.TryParse(Console.ReadLine(), out _maxDice))
    //     {
    //         Console.WriteLine("Integers only allowed.");
    //         Console.Write("Enter a number: ");
    //     }
    //     _dice.SetMaxDice(_maxDice);
    // }

    private void StartExecuteGame()
    {
        while (!_won)
        {
            foreach (var item in _player)
            {
                int diceRoll = _dice.Roll();
                _display.ToConsole(item.Key + " please press enter to roll the dice\n");
                Console.ReadKey();
                MovePlayer(item.Key, diceRoll);
                _display.PrintBoard(_player, _board);
                _display.ToConsole(item.Key + " got " + diceRoll + " now at " + _player[item.Key] + "\n");

                if (_player[item.Key] >= 100)
                {
                    _display.ToConsole(item.Key + " win!");
                    _player.Clear();
                    _won = true;
                    break;
                }
            }
        }
    }

    private void CheckPlayAgain()
    {
        _display.ToConsole("\nDo You Want to play again?(y/n)");
        string check = Console.ReadLine()!;
        if (check.ToLower() == "y")
        {
            _won = false;
            _gameStart = true;
        }
        else
        {
            _display.ToConsole("\nThank you for playing!");
            _gameStart = false;
        }
    }

    private void DisplayText()
    {
        _display.ToConsole("Snake and Ladder Game\n");
        _display.ToConsole("Ladder are [] while snake are {}! \n");
    }

    public void StartGame()
    {
        while (_gameStart)
        {
            DisplayText();
            StartPlayer();
            // StartDice();
            StartExecuteGame();
            CheckPlayAgain();
        }
    }
}