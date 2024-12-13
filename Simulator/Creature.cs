namespace Simulator;
    public class Creature
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

    public Creature() { }

    public string Info => $"Name:{Name} [{Level}]";

    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}");

    public void Upgrade()
    {
        level = Math.Min(level + 1, 10);
    }
}
