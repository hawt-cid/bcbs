using FluentAssertions;
using Xunit;

namespace Battleships.Test
{
    public class GameTest
    {
        [Fact]
        public void TestPlaySunk()
        {
            Game.Play(PayloadTestData.OneShip, PayloadTestData.OneShipGuesses)
                .Should().Be(1);
        }

        [Fact]
        public void TestPlaySunkMultiple()
        {

            Game.Play(PayloadTestData.MultipleShips, PayloadTestData.MultipleShipsGuesses)
                .Should().Be(PayloadTestData.MultipleShips.Length);
        }

        [Fact]
        public void TestPlayNoSunkPartialHits()
        {
            Game.Play(PayloadTestData.MultipleShips, PayloadTestData.MultipleShipsGuessesPartial)
                .Should().Be(0);
        }


        [Fact]
        public void TestOutOfBoundsGuesses()
        {
            foreach (var i in PayloadTestData.OutofBoundsCoordinates)
            {
                Assert.Throws<CoordinateOutOfBoardException>(() =>
                    Game.Play(PayloadTestData.MultipleShips, new string[] { i }));
            }
        }

        [Fact]
        public void TestOutOfBoundsShips()
        {
            foreach (var i in PayloadTestData.InvalidShipPositions)
            {
                Assert.Throws<ShipOutOfBoundsException>(() =>
                    Game.Play(new string[] { i }, PayloadTestData.MultipleShipsGuesses));
            }
        }

        [Fact]
        public void TestShipsIntersecting()
        {
            Assert.Throws<ShipsIntersectingException>(() =>
                Game.Play(PayloadTestData.IntersectingShips, PayloadTestData.MultipleShipsGuesses));
        }
    }
}
