using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivSim
{
    class MapLayer
    {
        public TileInfo[,] Tiles { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }

        public MapLayer(int width, int height)
        {
            Width = width;
            Height = height;
        }

    }
}
