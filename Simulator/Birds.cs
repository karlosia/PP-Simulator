﻿namespace Simulator
{
    public class Birds : Animals
    {
        public Birds(string name, bool canFly)
            : base(name, canFly)
        {
           Symbol = CanFly ? 'B' : 'b';
            Symbol = CanFly ? 'B' : 'b';
        }

        public override string Info
        {
            get
            {
                string FlyStatus = CanFly ? "fly+" : "fly-";
                return $"{Description} ({FlyStatus}) <{Size}>";
            }
        }
        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
        public override string Go(Direction direction)
        {
            Point nextPosition;

            if (CanFly)
            {
                // Latające ptaki poruszają się o dwa pola
                nextPosition = CurrentMap.Next(CurrentPosition, direction);
                nextPosition = CurrentMap.Next(nextPosition, direction); // Latające ptaki przesuwają się o dwa pola
            }
            else
            {
                // Nieloty o trzy pola
                nextPosition = CurrentMap.Next(CurrentPosition, direction);
                nextPosition = CurrentMap.Next(nextPosition, direction);
                nextPosition = CurrentMap.Next(nextPosition, direction);
            }

            CurrentMap.Move(this, CurrentPosition, nextPosition);
            CurrentPosition = nextPosition;

            return $"{direction.ToString().ToLower()}";
        }
    }
}
