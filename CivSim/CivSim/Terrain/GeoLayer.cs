using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivSim
{
    class GeoLayer : MapLayer
    {
        public GeoLayer(int width, int height, IVisibleCellManager visibleCellManager)
            :base(width, height)
        {
            Tiles = MapGenerator.MapGenerator.getMap(width, height, visibleCellManager);
        }
    }
}
