namespace BattleshipLibrary.Models
{
    public partial class GridSpotModel
    {
        public enum GridSpotStatus
        {
            Empty = 0,
            Ship,
            Miss,
            Hit,
            Sunk
        }
    }
}
