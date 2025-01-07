using System.Drawing;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{

    public int Size { get;  }
    

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException("Rozmiar musi być od 5 do 10");
        }
        Size = size;
        
    }

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
    }

    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d);

        int wrappedX = (nextPoint.X + Size) % Size;
        int wrappedY = (nextPoint.Y + Size) % Size;

        return new Point(wrappedX, wrappedY);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextPoint = p.NextDiagonal(d);

        int wrappedX = (nextPoint.X + Size) % Size;
        int wrappedY = (nextPoint.Y + Size) % Size;

        return new Point(wrappedX, wrappedY);
    }
}
