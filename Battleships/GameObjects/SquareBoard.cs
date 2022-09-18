using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    internal class SquareBoard
    {
        private const int BOARD_SQUARE_WIDTH = 10;

        private readonly IReadOnlyCollection<Ship> _ships;
        
        internal SquareBoard(IReadOnlyCollection<Ship> ships)
        {
            validateShipsOnBoard(ships);
            this._ships = ships;
        }

        internal int CountSunkenShips()
        {
            return _ships.Count(s => s.IsSunken());
        }

        internal void ShootAt(IReadOnlyCollection<Coordinate> guesses)
        {
            validateGuesses(guesses);
            foreach (var s in _ships)
            {
                foreach (var g in guesses)
                {
                    s.RegisterShot(g);
                };
            }
        }

        private static void validateShipsOnBoard(IReadOnlyCollection<Ship> ships)
        {
            var misplacedShips = ships.Where(s => !IsInsideBoard((Ship)s)).ToArray();
            if (misplacedShips.Any())
            {
                throw new ShipOutOfBoundsException(misplacedShips);
            }
        }

        private static bool IsInsideBoard(Ship ship)
        {
            return
                Math.Max(ship.ShipStart.Row, ship.ShipEnd.Row) < BOARD_SQUARE_WIDTH &&
                Math.Min(ship.ShipStart.Row, ship.ShipEnd.Row) >= 0 &&
                Math.Max(ship.ShipStart.Column, ship.ShipEnd.Column) < BOARD_SQUARE_WIDTH &&
                Math.Min(ship.ShipStart.Column, ship.ShipEnd.Column) >= 0;
        }

        private static bool IsInsideBoard(Coordinate coordinate)
        {
            return coordinate.Row >= 0 && coordinate.Row < BOARD_SQUARE_WIDTH &&
                   coordinate.Column >= 0 && coordinate.Column < BOARD_SQUARE_WIDTH;
        }

        private void validateGuesses(IReadOnlyCollection<Coordinate> guesses)
        {
            foreach (var g in guesses)
            {
                if (!IsInsideBoard(g))
                {
                    throw new CoordinateOutOfBoardException(g);
                }
            }
        }
    }
}