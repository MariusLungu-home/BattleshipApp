using BattleshipLibrary.Models;
using BattleshipLibrary;

namespace BattleshipUI
{
    public static class UI
    {
        public static void IdentifyWinner(PlayerInfoModel winner)
        {
            Console.WriteLine($"Congratulations to {winner.Name} for winning.");
            Console.WriteLine($"{winner.Name} took {GameLogic.GetShotsCount(winner)} shots");
        }

        public static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
        {
            bool isValidShot = false;
            string row = "";
            int column = 0;
            do
            {
                string shot = AskForShot();
                (row, column) = GameLogic.SplitShotIntoRowAndColumn(shot);
                isValidShot = GameLogic.ValidateShot(activePlayer, row, column);

                if (isValidShot == false)
                {
                    Console.WriteLine("Invalid shot location. Please try again.");
                }

            } while (isValidShot == false);

            bool isAHit = GameLogic.IdentifyShotResult(opponent, row, column);
            GameLogic.MarkShotResult(activePlayer, row, column, isAHit);
        }

        public static string AskForShot()
        {
            Console.WriteLine("Please write your shot selection: (like A1 or B1, etc)");
            string output = Console.ReadLine();

            return output;
        }

        // TODO - rewrite this to look like a chess board
        public static void DisplayShotGrid(PlayerInfoModel activePlayer)
        {
            string currentRow = activePlayer.ShotGrid[0].SpotLetter;

            foreach (var gridSpot in activePlayer.ShotGrid)
            {
                if (gridSpot.SpotLetter != currentRow)
                {
                    Console.WriteLine();
                    currentRow = gridSpot.SpotLetter;
                }

                if (gridSpot.status == GridSpotStatus.Empty)
                {
                    Console.Write($" {gridSpot.SpotLetter}{gridSpot.SpotNumber}");
                }

                if (gridSpot.status == GridSpotStatus.Hit)
                {
                    Console.Write($" X ");
                }
                else if (gridSpot.status == GridSpotStatus.Miss)
                {
                    Console.Write($" O ");
                }
                else
                {
                    Console.WriteLine(" ? ");
                }
            }
        }

        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine();
        }

        public static PlayerInfoModel CreatePlayer(string playerTitle)
        {
            PlayerInfoModel player = new PlayerInfoModel();
            Console.WriteLine($"Player information for: {playerTitle}");
            player.Name = AskForUsersName();
            GameLogic.InitializeGrid(player);
            PlaceShips(player);
            Console.Clear();

            return player;
        }

        public static string AskForUsersName()
        {
            Console.WriteLine("What is your name: ");
            string output = Console.ReadLine();

            return output;
        }

        public static void PlaceShips(PlayerInfoModel player)
        {
            do
            {
                Console.WriteLine($"Where do you want to place the ship {player.ShipLocations.Count + 1}");
                string location = Console.ReadLine();

                bool isValidLocation = GameLogic.PlaceShip(player, location);
                if (isValidLocation == false)
                {
                    Console.WriteLine("That was not a valid location. Please try again.");
                }
            } while (player.ShipLocations.Count < 5);
        }
    }
}
