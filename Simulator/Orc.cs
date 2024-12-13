﻿namespace Simulator;
public class Orc : Creature
{
    private int rage;
    public int Rage
    {
        get { return rage;  }
        init { rage = Validator.Limiter(value, 0, 10); }
    }

    public Orc() : base() { }

    public Orc(string name = "Unknown", int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi, I am {Name}, an Orc with {Rage} rage!");
    }

    private int huntCount = 0;
    public void Hunt()
    {
        huntCount++;
        Console.WriteLine($"{Name} is hunting.");


        if (huntCount % 2 == 0)
        {
            rage++;
            Console.WriteLine($"{Name}'s rage increased to {Rage}!");
        }
    }
    public override int Power => (Level * 7) + (Rage * 3);
    public override string Info => $"[{Rage}]";
}

    