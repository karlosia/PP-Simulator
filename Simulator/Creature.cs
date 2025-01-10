﻿using Simulator.Maps;

namespace Simulator;
    public abstract class Creature : IMappable
    {
    public string name = "Unknown";
    private int level = 1;
    public Map? CurrentMap { get; private set; }
    public Point CurrentPosition { get; set; }

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

    public void AssignToMap(Map map, Point point)
    {
        CurrentMap = map;
        CurrentPosition = point;
        map.Add(this, point);
    }

    public string Go(Direction direction)
    {
        var nextPosition = CurrentMap.Next(CurrentPosition, direction);
        CurrentMap.Move(this, CurrentPosition, nextPosition);
        CurrentPosition = nextPosition;
        return $"{direction.ToString().ToLower()}";
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

    public Point GetPosition() => CurrentPosition;

    public void Upgrade()
    {
        level = Math.Min(level + 1, 10);
    }
}
