namespace Simulator.Maps
{
    public class SmallMap : Map
    {

        public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 20 || sizeY > 20)
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Rozmiar SmallMap nie może przekraczać 20 punktów.");
        }

        public override Point Next(Point p, Direction d)
        {
            throw new NotImplementedException();
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            throw new NotImplementedException();
        }
    }
}
