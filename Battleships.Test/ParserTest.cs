using Xunit;

namespace Battleships.Test
{
    public class ParserTest
    {

        [Fact]
        public void TestInvalidGuessFormat()
        {
            foreach (var i in PayloadTestData.InvalidCoordinatesInputFormat)
            {
                Assert.Throws<InvalidCoordinateFormatException>(() => StringParser.CoordinateFromString(i));
            }
        }

        [Fact]
        public void TestInvalidShipSize()
        {
            foreach (var i in PayloadTestData.InvalidShipSize)
            {
                Assert.Throws<InvalidShipInputException>(() => StringParser.ShipFromString(i));
            }
        }

        [Fact]
        public void TestInvalidShipShape()
        {
            foreach (var i in PayloadTestData.InvalidShipShape)
            {
                Assert.Throws<InvalidShipInputException>(() => StringParser.ShipFromString(i));
            }
        }

        [Fact]
        public void InvalidShipFormat()
        {
            foreach (var i in PayloadTestData.InvalidShipFormat)
            {
                Assert.Throws<InvalidShipInputException>(() => StringParser.ShipFromString(i));
            }
        }

    }
}