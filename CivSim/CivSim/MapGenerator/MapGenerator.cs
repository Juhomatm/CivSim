using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivSim.MapGenerator
{
    class MapGenerator
    {
        public static TileInfo[,] getMap(int width, int height, IVisibleCellManager visibleCellManager)
        {
            TileInfo[,] tiles = new TileInfo[width, height];

            int[,] heightmap = getHeightmap(width, height);
            int median = getMedian(heightmap);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    TileInfo tileInfo = new TileInfo(x, y, visibleCellManager);
                    if (heightmap[x, y] > median)
                    {
                        tileInfo.setTerrain(TileInfo.TerrainType.Land);
                        tileInfo.setTerrainHeight((heightmap[x, y] - median) / 255f);
                    }
                    else
                    {
                        tileInfo.setTerrain(TileInfo.TerrainType.Sea);
                    }
                    tiles[x, y] = tileInfo;
                }
            }
            return tiles;
        }

        private static int getMedian(int[,] map)
        {
            List<int> values = new List<int>();
            foreach (int val in map)
            {
                values.Add(val);
            }
            return values.OrderBy(v => v).ToArray()[values.Count / 2];
        }

        private static int[,] getHeightmap(int width, int height)
        {
            HeightmapGenerator heightmapGenerator = new HeightmapGenerator();
            int[,] heightMap = new int[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    heightMap[x, y] = heightmapGenerator.GetHeight(x, y, width, height);
                }
            }
            return heightMap;
        }
    }
}
