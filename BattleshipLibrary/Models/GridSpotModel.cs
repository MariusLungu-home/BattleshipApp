namespace BattleshipLibrary.Models
{
    public partial class GridSpotModel
    {
        public string SpotLetter { get; set; }
        public int SpotNumber { get; set; }
        public GridSpotStatus status { get; set; } = GridSpotStatus.Empty;
        public GridSpotStatus Status { get; internal set; }
    }
}
