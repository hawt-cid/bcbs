using System;

namespace Battleships
{
    public class InvalidCoordinateFormatException : Exception
    {
        public InvalidCoordinateFormatException(string message): base(message)
        {
        }
    }
}