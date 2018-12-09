using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using CivSim.MapGenerator;

namespace CivSim
{
    class VegeLayer : MapLayer
    {
        private IVisibleCellManager _visibleCellManager;

        public VegeLayer(int width, int height, IVisibleCellManager visibleCellManager, SimWorld world) : base(width, height)
        {
            _visibleCellManager = visibleCellManager;
            BuildVegetation(world);
            visibleCellManager.VisibleLayers.Add(1);
        }

        private void BuildVegetation(SimWorld world)
        {
            float[,] treeMap = new float[Width, Height];

            for(int i = 0; i<1; i++)
            {
                NoiseGenerator noiseGenerator = new NoiseGenerator();
                NoiseGenerator.Frequency = 0.06;
                NoiseGenerator.Octaves = 10;

                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        TileInfo tileInfo = world.getTileInfo<GeoLayer>(x, y);
                        if (noiseGenerator.Noise(x, y) < 0)
                        {
                            if (tileInfo.Terrain == TileInfo.TerrainType.Land)
                            {
                                RLNET.RLColor color = new RLNET.RLColor(0, tileInfo.TerrainHeight + (0.2f), 0);
                                _visibleCellManager.getNewCell(world.getTileInfo<GeoLayer>(tileInfo.X, tileInfo.Y).VisibleCell.Character, 
                                    tileInfo.X, tileInfo.Y, color, 1);
                            }
                        }
                    }
                }
            }
        }
    }
}
