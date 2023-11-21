using BattleshipLibrary;
using BattleshipLibrary.Models;

namespace BattleshipUI
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();

            PlayerInfoModel playerInfo1 = CreatePlayer("Player 1");
            PlayerInfoModel playerInfo2 = CreatePlayer("Player 2");

            Console.ReadLine();
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Battleship!");

            Console.WriteLine();
        }

        private static PlayerInfoModel CreatePlayer(string playerTitle)
        {
            PlayerInfoModel player = new PlayerInfoModel();

            Console.WriteLine($"Player information for: {playerTitle}");

            // ask the user for their name
            player.Name = AskForUsersName();

            // load up the shot grid
            GameLogic.InitializeGrid(player);

            // ask the user for their 5 ship placements
            PlaceShips(player);

            // clear the screen/grid
            Console.Clear();

            return player;
        }

        private static string AskForUsersName()
        {
            Console.WriteLine("What is your name: ");
            string output = Console.ReadLine();
            
            return output;
        }

        private static void PlaceShips(PlayerInfoModel player)
        {
            do
            {
                Console.WriteLine($"Where do you want to place the ship { player.ShipLocations.Count + 1 }");
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