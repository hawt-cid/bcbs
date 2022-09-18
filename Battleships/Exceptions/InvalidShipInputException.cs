using System;

namespace Battleships
{
    public class InvalidShipInputException : Exception
    {
        public InvalidShipInputException(string message) : base(message)
        {
        }
    }
}