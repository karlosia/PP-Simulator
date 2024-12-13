namespace Simulator;

    public class Elf : Creature
{
    private int agility;
    public int Agility
    {
        get => agility;
        set => agility = value < 0 ? 0 : (value > 10 ? 10 : value);
    }

    public Elf() : base() { }

    public Elf(string name = "Unknown", int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi, I am {Name}, an Elf with {Agility} agility!");
    }

    private int singCount = 0;
    public void Sing()
    {
        singCount++;
        Console.WriteLine($"{Name} is singing.");

        if (singCount % 3 == 0)
        {
            Agility = Agility < 10 ? Agility + 1 : 10; 
            Console.WriteLine($"{Name}'s agility increased to {Agility}!");
        }
    }
    public override int Power => (Level * 8) + (Agility * 2);
}
