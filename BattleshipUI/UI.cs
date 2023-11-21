using BattleshipLibrary.Models;
using BattleshipLibrary;

namespace BattleshipUI
{
    public static class UI
    {
        public static void IdentifyWinner(PlayerInfoModel winner)
        {
            Console.WriteLine($"Congratulations to {winner.UsersName} for winning!");
            Console.WriteLine($"{winner.UsersName} took {GameLogic.GetShotCount(winner)} shots.");
        }

        public static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
        {
            bool isValidShot = false;
            string row = "";
            int column = 0;

            do
            {
                string shot = AskForShot(activePlayer);
                try
                {
                    (row, column) = GameLogic.SplitShotIntoRowAndColumn(shot);
                    isValidShot = GameLogic.ValidateShot(activePlayer, row, column);
                }
                catch (Exception ex)
                {
                    isValidShot = false;
                }

                if (isValidShot == false)
                {
                    Console.WriteLine("Invalid Shot Location. Please try again.");
                }
            } while (isValidShot == false);

            bool isAHit = GameLogic.IdentifyShotResult(opponent, row, column);

            GameLogic.MarkShotResult(activePlayer, row, column, isAHit);

            DisplayShotResults(row, column, isAHit);
        }

        public static void DisplayShotResults(string row, int column, bool isAHit)
        {
            if (isAHit)
            {
                Console.WriteLine($"{row}{column} is a Hit!");
            }
            else
            {
                Console.WriteLine($"{row}{column} is a miss.");
            }

            Console.WriteLine();
        }

        public static string AskForShot(PlayerInfoModel player)
        {
            Console.Write($"{player.UsersName}, please enter your shot selection: ");
            string output = Console.ReadLine();

            return output;
        }

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

                if (gridSpot.Status == GridSpotStatus.Empty)
                {
                    Console.Write($" {gridSpot.SpotLetter}{gridSpot.SpotNumber} ");
                }
                else if (gridSpot.Status == GridSpotStatus.Hit)
                {
                    Console.Write(" X  ");
                }
                else if (gridSpot.Status == GridSpotStatus.Miss)
                {
                    Console.Write(" O  ");
                }
                else
                {
                    Console.Write(" ?  ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Battleship Lite");
            Console.WriteLine("created by Tim Corey");
            Console.WriteLine();
        }

        public static PlayerInfoModel CreatePlayer(string playerTitle)
        {
            PlayerInfoModel output = new PlayerInfoModel();

            Console.WriteLine($"Player information for {playerTitle}");

            // Ask the user for their name
            output.UsersName = AskForUsersName();

            // Load up the shot grid
            GameLogic.InitializeGrid(output);

            // Ask the user for their 5 ship placements
            PlaceShips(output);

            // Clear
            Console.Clear();

            return output;
        }

        public static string AskForUsersName()
        {
            Console.Write("What is your name: ");
            string output = Console.ReadLine();

            return output;
        }

        public static void PlaceShips(PlayerInfoModel model)
        {
            do
            {
                Console.Write($"Where do you want to place ship number {model.ShipLocations.Count + 1}: ");
                string location = Console.ReadLine();

                bool isValidLocation = false;

                try
                {
                    isValidLocation = GameLogic.PlaceShip(model, location);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                if (isValidLocation == false)
                {
                    Console.WriteLine("That was not a valid location. Please try again.");
                }
            } while (model.ShipLocations.Count < 5);
        }
    }
}
