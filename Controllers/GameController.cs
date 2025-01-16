
// ditaruh di display, gamecontroller cm ngirim data mentah
//jadi IDice dari program main
//pakeaccessmodifier private & underscore

//better jd interface semua
//console ditaruh di class baru
public class GameController
{
    
   
    private bool _won = false;
    private bool _gameStart = true;
   
    private Dictionary<IPlayer, int> _player = new Dictionary<IPlayer, int>();
    private IDice _dice;


    public int diceRoll(){
        return _dice.Roll();
    }
    public Dictionary<IPlayer, int> GetPLayer(){
        return _player;
    }

    public bool GetWinCondition(){
        return _won;
    }

    public void SetWinCondition(bool setWinStatus){
        _won = setWinStatus;
    }

    public bool GetGameStatus(){
        return _gameStart;
    }

    public void SetGameStatus(bool setGameStatus){
        _gameStart = setGameStatus;
    }

    public GameController(Dice dice)
    {
        _dice = dice;
        
    }

    public void CreatePlayer(int numberOfUser)
    {
        for (int i = 1; i <= numberOfUser; i++)
        {
            Player playerClass = new Player("P" + i);
            _player.Add(playerClass, 1);
        }
    }

    public void MovePlayer(IPlayer key, int diceRoll, IBoard board)
    {
        board.GenerateSnakeAndLadder();
        int newPosition = _player[key] + diceRoll;
        
        int newPositionTotal = newPosition >100?100: newPosition + board.GetSnakeAndLadderPosition(newPosition);

        _player[key] = newPositionTotal;
    }

    

    
}