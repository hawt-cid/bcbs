using System;

namespace Battleships
{
    public class InvalidCoordinateFormatException : Exception
    {
        public InvalidCoordinateFormatException(ArgumentException ae): base(ae.Message, ae)
        {
        }
    }
}