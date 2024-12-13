namespace Simulator
{
    internal class Birds : Animals
    {
        public bool CanFly = true;

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
    }
}
