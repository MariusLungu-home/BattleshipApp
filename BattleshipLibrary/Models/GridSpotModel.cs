﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.Models
{
    public partial class GridSpotModel
    {
        public string SpotLetter { get; set; }
        public int SpotNumber { get; set; }
        public GridSpotStatus status { get; set; }
    }
}
