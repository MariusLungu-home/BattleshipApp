using BattleshipLibrary.Models;

namespace BattleshipLibrary
{
    public class GameLogic
    {
        public static void AskForShipPlacements(PlayerInfoModel player)
        {
            throw new NotImplementedException();
        }

        public static void InitializeGrid(PlayerInfoModel model) 
        {
            List<string> letters = new List<string>
            { 
                "A",
                "B",
                "C",
                "D",
                "E"
            };

            List<int> numbers = new List<int>()
            {
                1,
                2,
                3,
                4,
                5
            };

            foreach (var letter in letters)
            {
                foreach (var number in numbers)
                {
                    AddGridSpot(model, letter, number);
                }
            }
        }

        public static bool PlaceShip(PlayerInfoModel player, string? location)
        {
            throw new NotImplementedException();
        }

        private static void AddGridSpot(PlayerInfoModel model, string letter, int number)
        {
            GridSpotModel spot = new GridSpotModel {
                SpotLetter = letter,
                SpotNumber = number,
                Status = GridSpotStatus.Empty
            };
        }
    }
}
