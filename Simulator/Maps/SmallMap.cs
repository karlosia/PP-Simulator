namespace Simulator.Maps
{
    public class SmallMap : Map
    {
        public readonly List<Creature>?[,] pola;
        public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 20 || sizeY > 20)
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Rozmiar SmallMap nie może przekraczać 20 punktów.");
        pola = new List<Creature>?[sizeX, sizeY];       
        }

        public override void Add(Creature creature, Point point)
        {
            if (!Exist(point))
            {
                throw new ArgumentOutOfRangeException("Punkt, który wybrałeś nie należy do mapy");
                }

            
            if (pola[point.X, point.Y] == null)
            {
                
                pola[point.X, point.Y] = new List<Creature>();
            }

            
            pola[point.X, point.Y].Add(creature);
        }

      public override void Remove(Creature creature, Point point)
        {
            
            var creaturesAtPoint = pola[point.X, point.Y];
            if (creaturesAtPoint != null)
            {
                
                creaturesAtPoint.Remove(creature);
            }
        }
        public override List<Creature> At(Point point)
        {
            
            return pola[point.X, point.Y] ?? new List<Creature>();
        }

        public override List<Creature> At(int x, int y) { 
            return At(new Point(x, y));}
        



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
