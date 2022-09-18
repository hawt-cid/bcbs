using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    public class Ship
    {
        private readonly IReadOnlyCollection<ShipMass> _shipMass;

        public Ship(Coordinate from, Coordinate to)
        {
            _shipMass = shipMassFromEdges(from, to);
        }

        public bool IsSunken()
        {
            return _shipMass.All(mass => mass.IsHit());
        }

        public void RegisterShot(Coordinate shotTarget)
        {
            foreach (var shipMassHit in _shipMass.Where(sm => sm.Coordinate.Equals(shotTarget)))
            {
                shipMassHit.RegisterHit();
            }
        }

        public IReadOnlyCollection<Coordinate> GetMassCoordinates()
        {
            return _shipMass.Select(sm => sm.Coordinate).ToArray();
        }

        private static IReadOnlyCollection<ShipMass> shipMassFromEdges(Coordinate from, Coordinate to)
        {
            List<ShipMass> mass = new List<ShipMass>();

            var minX = Math.Min(from.Row, to.Row);
            var maxX = Math.Max(from.Row, to.Row);
            var minY = Math.Min(from.Column, to.Column);
            var maxY = Math.Max(from.Column, to.Column);

            for (var x = minX; x <= maxX; x++)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    mass.Add(new ShipMass(new Coordinate(x, y)));
                }
            }

            return mass.ToArray();
        }
    }
}