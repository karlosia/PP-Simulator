using Simulator.Maps;

namespace Simulator;
    public abstract class Creature
    {
    public string name = "Unknown";
    private int level = 1;
    public Map? CurrentMap { get; private set; } 
    public Point CurrentPosition { get; private set; } 

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

    public void AssignToMap(Map map, Point position)
    {
        if (CurrentMap != null)
            throw new InvalidOperationException("Stwór jest już przypisany do mapy.");

        CurrentMap = map;
        CurrentPosition = position;

        map.Add(this, position);
    }

    public void Go(Direction direction)
    {
        if (CurrentMap == null)
            throw new InvalidOperationException("Stwór nie jest przypisany do żadnej mapy.");

        Point newPosition = CurrentMap.Next(CurrentPosition, direction);

        MoveTo(newPosition);
    }

    private void MoveTo(Point newPosition)
    {
        if (CurrentMap == null)
            throw new InvalidOperationException("Stwór nie jest przypisany do żadnej mapy.");

        CurrentMap.Remove(this, CurrentPosition);

        CurrentMap.Add(this, newPosition);

        CurrentPosition = newPosition;
    }

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
