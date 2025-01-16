public class Player
{
    private string name {get; set;}
    
    public Player(string userName)
    {
        // last = lastName;
        name = userName;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Player other = (Player)obj;
        return name == other.name;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }

    public override string ToString()
    {
        return name;
    }
}