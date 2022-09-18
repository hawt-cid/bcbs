using System;
using System.Collections.Generic;

namespace Battleships
{
    public class ShipsIntersectingException : Exception
    {
        public ShipsIntersectingException(IReadOnlyCollection<Ship> ships)
        {

        }
    }
}