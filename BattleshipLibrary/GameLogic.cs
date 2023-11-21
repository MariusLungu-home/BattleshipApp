using BattleshipLibrary.Models;

namespace BattleshipLibrary
{
    public class GameLogic
    {
        public static void AskForShipPlacements(PlayerInfoModel player)
        {
            throw new NotImplementedException();
        }

        public static int GetShotsCount(PlayerInfoModel winner)
        {
            throw new NotImplementedException();
        }

        public static bool IdentifyShotResult(PlayerInfoModel opponent, string row, int column)
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

        public static void MarkShotResult(PlayerInfoModel activePlayer, string row, int column, bool isAHit)
        {
            throw new NotImplementedException();
        }

        public static bool PlaceShip(PlayerInfoModel player, string? location)
        {
            throw new NotImplementedException();
        }

        public static bool PlayerStillActive(PlayerInfoModel opponent)
        {
            throw new NotImplementedException();
        }

        public static (string row, int column) SplitShotIntoRowAndColumn(string shot)
        {
            throw new NotImplementedException();
        }

        public static bool ValidateShot(PlayerInfoModel activePlayer, string row, int column)
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
