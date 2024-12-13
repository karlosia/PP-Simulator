namespace Simulator;
    public abstract class Creature
    {
    public string name = "Unknown";
    private int level = 1;


    public string Name
    {
        get => name;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                name = "Unknown";
            }
            else
            {
                string trimmed = value.Trim();
                if (trimmed.Length < 3)
                {
                    trimmed = trimmed.PadRight(3, '#');
                }
                else if (trimmed.Length > 25)
                {
                    trimmed = trimmed.Substring(0, 25).TrimEnd();
                    if (trimmed.Length < 3)
                    {
                        trimmed = trimmed.PadRight(3, '#');
                    }
                }
                if (char.IsLower(trimmed[0]))
                {
                    trimmed = char.ToUpper(trimmed[0]) + trimmed.Substring(1);
                }
                name = trimmed;
            }
        }
    }
    public int Level
    {
        get => level;
        init { level = Math.Clamp(value, 1, 10); }
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

    public string Info => $"Name:{Name} [{Level}]";

    public abstract void SayHi();
    public abstract int Power { get; }

    public void Upgrade()
    {
        level = Math.Min(level + 1, 10);
    }
}
