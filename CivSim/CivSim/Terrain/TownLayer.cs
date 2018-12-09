using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivSim
{
    class TownLayer : MapLayer
    {
        public TownLayer(int width, int height, IVisibleCellManager visibleCellManager, SimWorld world) : base(width, height)
        {
            Random random = new Random();
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    TileInfo tileInfo = world.getTileInfo<GeoLayer>(x, y);
                    if (random.NextDouble() > 0.99)
                    {
                        if (tileInfo.Terrain == TileInfo.TerrainType.Land)
                        {
                            float points = 0;

                            int waterPoints = 0;
                            int landsAround = 0;
                            foreach (TileInfo info in world.getTileInfosAround<GeoLayer>(x, y, 5))
                            {
                                if(info.Terrain == TileInfo.TerrainType.Land)
                                {
                                    landsAround++;
                                }
                                else
                                {
                                    waterPoints++;
                                }
                                if(info.TerrainHeight < 0.1f)
                                {
                                    points += 0.1f;
                                }
                            }
                            if(waterPoints < 3)
                            {
                                points -= 5;
                            } else if(waterPoints < 7)
                            {
                                points -= 1;
                            }
                            else if (waterPoints < 20)
                            {
                                points += 2;
                            }
                            else if (waterPoints < 30)
                            {
                                points += 3;
                            }
                            else if (waterPoints < 60)
                            {
                                points += 2;
                            }
                            else if (waterPoints > 60)
                            {
                                points -= 6;
                            }

                            //points -= (Math.Abs(waterPoints - landsAround) / 20);
                            if (points <= 0) points = 1;
                            if (points > 9) points = 9;
                            visibleCellManager.getNewCell(new Character(48 + (int)points),
                                tileInfo.X, tileInfo.Y, RLNET.RLColor.Brown, 1);
                        }
                    }
                }
            }
        }
    }
}
