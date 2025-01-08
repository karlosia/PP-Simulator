using System.Reflection.Metadata.Ecma335;

namespace Simulator.Maps;
/// <summary>
/// Map of points.
/// </summary>


public abstract class Map
{
    public int SizeY { get; set; }
    public int SizeX { get; set; }
    public readonly Rectangle mapArea;
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    protected Map(int sizeX, int sizeY)
    {
        if (sizeY < 5 || sizeX < 5)
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Rozmiar mapy musi mieć przynajmniej 5 punktów.");

        
        SizeY = sizeY;
        SizeX = sizeX;
        mapArea = new Rectangle(0, 0, SizeX-1, SizeY-1);
    }
    public bool Exist(Point p)
    {

        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        return mapArea.Contains(p);
    }
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}