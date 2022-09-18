using System;

namespace Battleships
{
    public class CoordinateOutOfBoardException : Exception
    {
        public CoordinateOutOfBoardException(Coordinate coordinate) : base($"Coordinate {coordinate} out of board bounds.")
        {
        }
    }
}