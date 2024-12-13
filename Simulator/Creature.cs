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

    public void Go(Direction direction)
    {
        string directionStr = direction.ToString().ToLower();
        Console.WriteLine($"{Name} goes {directionStr}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directions)
    {
        var parsedDirections = DirectionParser.Parse(directions);
        Go(parsedDirections);
    }
    public Creature() { }

    public abstract string Info { get; }

    public abstract void SayHi();

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
