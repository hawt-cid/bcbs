namespace Battleships.Test
{
    public class PayloadTestData
    {
        public static string[] OneShip = new string[] { "3:2,3:5" };
        public static string[] OneShipGuesses = new string[] { "3:2", "3:3", "3:4", "3:5" };

        public static string[] MultipleShips = new string[] { "3:2,3:5", "5:2,5:3", "6:6,8:6", "0:0,0:3", "9:9,9:6" };
        public static string[] MultipleShipsGuesses = new string[] {
            "3:2", "3:3", "3:4", "3:5", // first ship
            "5:2", "5:3", // second ship
            "6:6", "7:6", "8:6", // third ship
            "0:0", "0:1", "0:2", "0:3", // fourth ship
            "9:6", "9:7", "9:8", "9:9" // fifth ship
        };
        public static string[] MultipleShipsGuessesPartial = new string[] {
            "3:2", "3:3", "3:4", // first ship
            "5:2", // second ship
            "6:6", "7:6", // third ship
            "0:0", "0:1", "0:2", // fourth ship
            "9:6", "9:7", "9:9" // fifth ship
        };
        public static string[] InvalidCoordinatesInputFormat = new string[] { "3,2", "32" };
               
        public static string[] OutofBoundsCoordinates = new string[] { "-3:12", "-5:4", "16:4", "20:20" };
               
        public static string[] InvalidShipShape = new string[] { "3:2,4:5" };
        public static string[] InvalidShipSize = new string[] { "1:1,6:6", "1:1,1:1" };
        public static string[] InvalidShipFormat = new string[] { "1:11:1" };

        public static string[] InvalidShipPositions = new string[] { "-3:5,0:5", "8:1,11:1" };
        public static string[] IntersectingShips = new string[] { "1:1,4:1", "2:1,2:4" };
    }
}