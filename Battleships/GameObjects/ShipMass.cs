namespace Battleships
{
    internal class ShipMass
    {
        public Coordinate Coordinate { get; }
        private bool _wasHit;

        public ShipMass(Coordinate coordinate)
        {
            this.Coordinate = coordinate;
        }

        public void RegisterHit()
        {
            _wasHit = true;
        }

        public bool IsHit()
        {
            return _wasHit;
        }
    }
}