using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    internal class SquareBoard
    {
        private readonly IReadOnlyCollection<Ship> _ships;
        private readonly int _squareWidth;
        
        public SquareBoard(int squareBoardWidth, IReadOnlyCollection<Ship> ships)
        {
            _squareWidth = squareBoardWidth;
            ensureValidShipsOnBoard(ships);
            this._ships = ships;
        }

        public int CountSunkenShips()
        {
            return _ships.Count(s => s.IsSunken());
        }

        public void ShootAt(IReadOnlyCollection<Coordinate> guesses)
        {
            ensureValidGuesses(guesses);
            
            foreach (var s in _ships)
            {
                foreach (var g in guesses)
                {
                    s.RegisterShot(g);
                };
            }
        }

        private void ensureValidShipsOnBoard(IReadOnlyCollection<Ship> ships)
        {
            var shipsOnBoard = ships.Select(s => new { IsOnBoard = isInsideBoard(s), Mass = s.GetMassCoordinates() }).ToArray();

            if (shipsOnBoard.Any(s => !s.IsOnBoard))
            {
                throw new ShipOutOfBoundsException();
            }

            var intersectingMass = shipsOnBoard.SelectMany(s => s.Mass)
                .GroupBy(s => s).Where(g => g.Count() > 1);

            if (intersectingMass.Any())
            {
                throw new ShipsIntersectingException(ships);
            }
        }

        private bool isInsideBoard(Ship ship)
        {
            var allMass = ship.GetMassCoordinates();

            return allMass.All(
                    m => m.Row >= 0 && m.Row < _squareWidth && 
                    m.Column >= 0 && m.Column < _squareWidth );
        }

        private bool isInsideBoard(Coordinate coordinate)
        {
            return coordinate.Row >= 0 && coordinate.Row < _squareWidth &&
                   coordinate.Column >= 0 && coordinate.Column < _squareWidth;
        }

        private void ensureValidGuesses(IReadOnlyCollection<Coordinate> guesses)
        {
            foreach (var g in guesses)
            {
                if (!isInsideBoard(g))
                {
                    throw new CoordinateOutOfBoardException(g);
                }
            }
        }
    }
}