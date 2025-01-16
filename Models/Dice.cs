
//jd interface
//tambahin size dadu max unlimited
public class Dice : IDice
{
    private int _maxDice;

    public Dice(int maxNumber)
    {
        _maxDice = maxNumber;
    }
    public void SetMaxDice(int maxNumber)
    {
        _maxDice = maxNumber;
    }

    public int Roll()
    {
        return new Random().Next(1, _maxDice + 1);
    }
}