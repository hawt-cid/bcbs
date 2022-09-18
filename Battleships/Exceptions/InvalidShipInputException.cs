using System;

namespace Battleships
{
    public class InvalidShipInputException : Exception
    {
        public InvalidShipInputException(ArgumentException ae) : base(ae.Message, ae)
        {
        }

        public InvalidShipInputException(InvalidCoordinateFormatException icfe) : base(icfe.Message, icfe)
        {
        }
    }
}