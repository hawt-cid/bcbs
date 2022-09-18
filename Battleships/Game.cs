﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    // Imagine a game of battleships.
    //   The player has to guess the location of the opponent's 'ships' on a 10x10 grid
    //   Ships are one unit wide and 2-4 units long, they may be placed vertically or horizontally
    //   The player asks if a given co-ordinate is a hit or a miss
    //   Once all cells representing a ship are hit - that ship is sunk.
    public class Game
    {
        // ships: each string represents a ship in the form first co-ordinate, last co-ordinate
        //   e.g. "3:2,3:5" is a 4 cell ship horizontally across the 4th row from the 3rd to the 6th column
        // guesses: each string represents the co-ordinate of a guess
        //   e.g. "7:0" - misses the ship above, "3:3" hits it.
        // returns: the number of ships sunk by the set of guesses
        public static int Play(string[] inputShips, string[] inputGuesses)
        {
            var ships = parseShips(inputShips);
            var guesses = parseGuesses(inputGuesses);

            var board = new SquareBoard(ships);
            board.ShootAt(guesses);

            return board.CountSunkenShips();
        }

        private static IReadOnlyCollection<Coordinate> parseGuesses(string[] guesses)
        {
            try
            {
                return guesses.Select(StringParser.CoordinateFromString).ToArray();
            }
            catch (ArgumentException ae)
            {
                throw new InvalidCoordinateFormatException(ae);
            }
        }

        private static IReadOnlyCollection<Ship> parseShips(string[] ships)
        {
            try
            {
                return ships.Select(StringParser.ShipFromString).ToArray();
            }
            catch (InvalidCoordinateFormatException icfe)
            {
                throw new InvalidShipInputException(icfe);
            }
            catch (ArgumentException ae)
            {
                throw new InvalidShipInputException(ae);
            }
        }
    }
}
