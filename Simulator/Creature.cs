namespace Simulator;
    public class Creature
    {
    public string Name { get; init; } = "Noname";
    private int level = 1;
    public int Level
    {
        get => level;
        set => level = value > 0 ? value : 0;
    }

    public Creature(string name, int level=1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public string Info => $"Name:{Name} [{Level}]";

    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}");

}
