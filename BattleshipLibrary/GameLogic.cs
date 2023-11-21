using BattleshipLibrary.Models;
using System.Data.Common;
using System.Numerics;

namespace BattleshipLibrary
{
    public class GameLogic
    {
        public static void AskForShipPlacements(PlayerInfoModel player)
        {
            throw new NotImplementedException();
        }

        public static int GetShotsCount(PlayerInfoModel player)
        {
            int shotcount = 0;
            foreach (var shot in player.ShotGrid)
            {
                if (shot.status != GridSpotStatus.Empty)
                {
                    shotcount += 1;
                }
            }
            return shotcount;
        }

        public static bool IdentifyShotResult(PlayerInfoModel opponent, string row, int column)
        {
            bool isAHit = false;

            foreach (var ship in opponent.ShipLocations)
            {
                if (ship.SpotLetter.ToUpper() == row.ToUpper() && ship.SpotNumber == column)
                {
                    isAHit = true;
                }
            }
            return isAHit;
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
            foreach (var gridSpot in activePlayer.ShotGrid)
            {
                if (gridSpot.SpotLetter.ToUpper() == row.ToUpper() && gridSpot.SpotNumber == column)
                {
                    if (isAHit)
                    {
                        gridSpot.status = GridSpotStatus.Hit;
                    }
                    else
                    {
                        gridSpot.status = GridSpotStatus.Miss;
                    }
                }
            }
        }

        public static bool PlaceShip(PlayerInfoModel player, string? location)
        {
            bool output = false;
            (string row, int column) = SplitShotIntoRowAndColumn(location);
            
            bool isValidLocation = ValidateGridLocation(player, row, column);
            bool isSpotOpen = ValidateShipLocation(player, row, column);

            if (isValidLocation && isSpotOpen)
            {
                player.ShipLocations.Add(new GridSpotModel
                {
                    SpotLetter = row.ToUpper(),
                    SpotNumber = column,
                    Status = GridSpotStatus.Ship
                });
                output = true;
            }

            return output;
        }

        private static bool ValidateShipLocation(PlayerInfoModel player, string row, int column)
        {
            bool isValidLocation = true;
            foreach (var ship in player.ShipLocations)
            {
                if (ship.SpotLetter.ToUpper() == row.ToUpper() && ship.SpotNumber == column)
                {
                    isValidLocation = false;
                } 
            }
            return isValidLocation;
        }

        private static bool ValidateGridLocation(PlayerInfoModel player, string row, int column)
        {
            bool isValidLocation = false;
            
            foreach (var ship in player.ShotGrid)
            {
                if (ship.SpotLetter.ToUpper() == row.ToUpper() && ship.SpotNumber == column)
                {
                    isValidLocation = true;
                }
            }

            return isValidLocation;
        }

        public static bool PlayerStillActive(PlayerInfoModel player)
        {
            bool isActive = false;
            
            foreach(var ship in player.ShipLocations)
            {
                if (ship.Status != GridSpotStatus.Sunk)
                {
                    return isActive = true;
                }
            }

            return isActive;
        }

        public static (string row, int column) SplitShotIntoRowAndColumn(string shot)
        {
            // split show into row and column
            string row = "";
            int column = 0;

            if (shot.Length != 2)
            {
                throw new ArgumentException("This was an invalid shot type", "shot");
            }

            char[] shotArray = shot.ToArray();
            row = shotArray[0].ToString();
            column = int.Parse(shotArray[1].ToString());

            return (row, column);
        }

        public static bool ValidateShot(PlayerInfoModel activePlayer, string row, int column)
        {
            bool isValid = true;

            foreach (var gridSpot in activePlayer.ShotGrid)
            {
                if (gridSpot.SpotLetter == row.ToUpper() && gridSpot.SpotNumber == column)
                {
                    if (gridSpot.status == GridSpotStatus.Empty)
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
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
