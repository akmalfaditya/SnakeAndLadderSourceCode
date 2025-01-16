class Program
{
    static void Main()
    {
        GameController game = new GameController(new Dice(6), new Board(), new Display());
        game.StartGame();
    }
}



