namespace Simulator;
    public abstract class Creature
    {
    public string name = "Unknown";
    private int level = 1;


    public string Name
    {
        get { return name;  }
        init
        {
            name = Validator.Shortener(value, 3, 25, '#');
        }
    }
    public int Level
    {
        get { return level; }
        init { level = Validator.Limiter(value, 1, 10); }
    }

    public Creature(string name, int level=1)
    {
        Name = name;
        Level = level;
    }

    public string Go(Direction direction) => $" {direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions)
    {
        List<string> moves = new List<string>();
        foreach (Direction direction in directions) 
        {
            moves.Add(Go(direction));
        }
        return moves.ToArray();
    }

    public string[] Go(string directions) => Go(DirectionParser.Parse(directions));
    
    public Creature() { }

    public abstract string Info { get; }

    public abstract string Greeting();

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Name} [{Level}] {Info}";
    }
    public abstract int Power { get; }

    public void Upgrade()
    {
        level = Math.Min(level + 1, 10);
    }
}
