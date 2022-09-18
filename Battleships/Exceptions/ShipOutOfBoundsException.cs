using System;

namespace Battleships
{
    public class ShipOutOfBoundsException : Exception
    {
        public ShipOutOfBoundsException() : base($"Ships are placed out of board bounds.")
        {
        
        }
    }
}