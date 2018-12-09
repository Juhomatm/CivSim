using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace CivSim
{
    public class SimWorld : IWorld
    {
        public static Random globalRandom = new Random();

        private IVisibleCellManager _visibleCellManager;
        private List<Population> _populations;
        private List<MapLayer> _mapLayers;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public SimWorld(IVisibleCellManager visibleCellManager)
        {
            _visibleCellManager = visibleCellManager;
            Width = 200;
            Height = 120;
            _mapLayers = new List<MapLayer>();
            _mapLayers.Add(new GeoLayer(Width, Height, visibleCellManager));
            _mapLayers.Add(new VegeLayer(Width, Height, visibleCellManager, this));
            _mapLayers.Add(new TownLayer(Width, Height, visibleCellManager, this));
            _populations = new List<Population>();
        }

        internal T GetMapLayer<T>() where T : MapLayer
        {
            return _mapLayers.OfType<T>().FirstOrDefault();
        }

        internal TileInfo getTileInfo<T>(int x, int y) where T : MapLayer
        {
            if(x < 0 || y < 0 || x >= GetMapLayer<T>().Tiles.GetLength(0) || y >= GetMapLayer<T>().Tiles.GetLength(1))
            {
                return null;
            }
            return GetMapLayer<T>().Tiles[x, y];
        }

        internal TileInfo[] getTileInfosAround<T>(int x, int y, int radius) where T : MapLayer
        {
            List<TileInfo> tileInfos = new List<TileInfo>();

            for(int relativeX = -radius; relativeX <= radius; relativeX++)
            {
                for (int relativeY = -radius; relativeY <= radius; relativeY++)
                {
                    tileInfos.Add(getTileInfo<T>(x + relativeX, y + relativeY));
                }
            }
            return tileInfos.Where(i => i != null).ToArray();
        }

        public void Update()
        {
            if(_populations.Count == 0)
            {
                _populations.Add(new Population(50, 50, _visibleCellManager));
                _populations.Add(new Population(50, 50, _visibleCellManager));
                _populations.Add(new Population(50, 50, _visibleCellManager));
                _populations.Add(new Population(50, 50, _visibleCellManager));
                _populations.Add(new Population(40, 35, _visibleCellManager));
                _populations.Add(new Population(100, 10, _visibleCellManager));
                _populations.Add(new Population(8, 100, _visibleCellManager));
                _populations.Add(new Population(8, 100, _visibleCellManager));
                _populations.Add(new Population(8, 100, _visibleCellManager));
                _populations.Add(new Population(8, 100, _visibleCellManager));
            }
            foreach (Population population in _populations)
            {
                population.Update(this);
            }
        }
    }
}

