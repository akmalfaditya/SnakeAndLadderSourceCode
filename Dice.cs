public class Dice{

    private int _maxDice;

    // public Dice(int maxDice){
    //     _maxDice = maxDice;
    // }

    public void SetMaxDice(int maxNumber){
        _maxDice = maxNumber;

    }
    //tambahin size dadu max unlimited
    public int GetDice()
    {
        Random random = new();
        int dice = random.Next(1, _maxDice+1);

        return dice;
    }
}