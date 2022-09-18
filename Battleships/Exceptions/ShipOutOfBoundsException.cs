using System;
using System.Collections.Generic;

namespace Battleships
{
    public class ShipOutOfBoundsException : Exception
    {
        public ShipOutOfBoundsException(IEnumerable<Ship> misplacedShips) : base($"Ships are out of board bounds: {misplacedShips} ")
        {
        
        }
    }
}