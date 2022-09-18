using System;

namespace Battleships
{
    public static class StringParser
    {
        public static Coordinate CoordinateFromString(string s)
        {
            var numbers = s.Split(':');
            if (numbers.Length != 2)
                throw new InvalidCoordinateFormatException($"Wrong format of position {s}");

            var row = int.Parse(numbers[0]);
            var column = int.Parse(numbers[1]);
            return new Coordinate(row, column);
        }

        public static Ship ShipFromString(string s)
        {
            var shipEdges = s.Split(',');
            if (shipEdges.Length != 2)
                throw new InvalidShipInputException($"Wrong format of ship edges {s}");

            var firstEdge = CoordinateFromString(shipEdges[0]);
            var secondEdge = CoordinateFromString(shipEdges[1]);

            if (isInclining(firstEdge, secondEdge))
            {
                throw new InvalidShipInputException($"Ship {s} is inclining. Only horizontal/vertical ships allowed.");
            }

            var length = distance(firstEdge, secondEdge) + 1;

            if (length < 2 || length > 4)
            {
                throw new InvalidShipInputException($"Ship must be 2-4 units long!");
            }

            return new Ship(firstEdge, secondEdge);
        }

        private static bool isInclining(Coordinate from, Coordinate to)
        {
            return from.Row != to.Row && from.Column != to.Column;
        }

        private static int distance(Coordinate from, Coordinate to)
        {
            return Math.Max(Math.Abs(from.Row - to.Row), Math.Abs(from.Column - to.Column));
        }
    }
}
