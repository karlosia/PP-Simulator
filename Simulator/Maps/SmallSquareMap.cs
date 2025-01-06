namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public int Size { get; }

    private readonly Rectangle mapArea;
    

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException("Niepoprawny rozmiar mapy. Mapa powinna mieć rozmiar od 5 do 20 punktów.");
        }

        Size = size;
        mapArea = new Rectangle(0, 0, Size - 1, Size - 1);
    }
    
    public override bool Exist(Point p)
    {
        return mapArea.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        if (Exist(nextPoint))
            return nextPoint;
        return p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        if (Exist(nextPoint))
            return nextPoint;
        return p;
    }
}
