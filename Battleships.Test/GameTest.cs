using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Battleships.Test
{
    public class GameTest
    {
        private string[] oneShip = new string[] { "3:2,3:5" };
        private string[] oneShipGuesses = new string[] { "3:2", "3:3", "3:4", "3:5" };

        private string[] multipleShips = new string[] { "3:2,3:5", "5:2,5:3", "6:6,8:6" };
        private string[] multipleShipsGuesses = new string[] { 
                        "3:2", "3:3", "3:4", "3:5", // first ship
                        "5:2", "5:3", // second ship
                        "6:6", "7:6", "8:6" // third ship
        };
        private string[] multipleShipsGuessesPartial = new string[] {
            "3:2", "3:3", "3:4", // first ship
            "5:2", // second ship
            "6:6", "7:6" // third ship
        };
        private string[] invalidCoordinatesInputFormat = new string[] { "3,2", "32" };

        private string[] outofBoundsCoordinates = new string[] { "-3:12" };

        private string[] invalidShipShape = new string[] { "3:2,4:5" };
        private string[] invalidShipSize = new string[] { "1:1,6:6", "1:1,1:1" };

        [Fact]
        public void TestPlaySunk()
        {
            Game.Play(oneShip, oneShipGuesses).Should().Be(1);
        }

        [Fact]
        public void TestPlaySunkMultiple()
        {

            Game.Play(multipleShips, multipleShipsGuesses).Should().Be(3);
        }

        [Fact]
        public void TestPlayNoSunkPartialHits()
        {
            Game.Play(multipleShips, multipleShipsGuessesPartial).Should().Be(0);
        }

        [Fact]
        public void TestInvalidGuessFormat()
        {
            foreach (var i in invalidCoordinatesInputFormat)
            {
                Assert.Throws<InvalidCoordinateFormatException>(() => Game.Play(multipleShips, new string[] {i}));
            }
        }

        [Fact]
        public void TestInvalidShipSize()
        {
            foreach (var i in invalidShipSize)
            {
                Assert.Throws<InvalidShipInputException>(() => Game.Play(new string[] { i }, multipleShipsGuesses));
            }
        }

        [Fact]
        public void TestInvalidShipShape()
        {
            foreach (var i in invalidShipShape)
            {
                Assert.Throws<InvalidShipInputException>(() => Game.Play(new string[] { i }, multipleShipsGuesses));
            }
        }
    }
}
