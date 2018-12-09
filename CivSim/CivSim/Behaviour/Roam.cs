using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivSim.Behaviour
{
    class Roam : IBehaviour<Population>
    {
        private int deltaX;
        private int deltaY;

        private bool hasLanded;
        private int waitCounter = 0;

        public Roam()
        {
            deltaX = (SimWorld.globalRandom.NextDouble() > 0.5) ? 1 : -1;
            deltaY = (SimWorld.globalRandom.NextDouble() > 0.5) ? 1 : -1;
        }

        public void Update(Population population, SimWorld world)
        {
            if(waitCounter > 0)
            {
                waitCounter--;
                return;
            }
            if(hasLanded)
            {
                population.VisibleCell.Character = new Common.Character(1);
                population.VisibleCell.Color = RLNET.RLColor.Cyan;
            }
            else
            {
                population.VisibleCell.Character = new Common.Character(243);
                population.VisibleCell.Color = RLNET.RLColor.Brown;
            }

            int oldX = population.X;
            int oldY = population.Y;
            population.X += deltaX;
            population.Y += deltaY;

            bool outsideMap = false;
            if (population.X < 0 || population.X >= world.Width)
            {
                deltaX *= -1;
                outsideMap = true;
            }

            if (population.Y < 0 || population.Y >= world.Height)
            {
                deltaY *= -1;
                outsideMap = true;
            }
            if (outsideMap)
            {
                return;
            }

            if (!hasLanded && world.getTileInfo<GeoLayer>(population.X, population.Y).Terrain == TileInfo.TerrainType.Land)
            {
                hasLanded = true;
                waitCounter = 5;
            }

            if (hasLanded && world.getTileInfo<GeoLayer>(population.X, population.Y).Terrain == TileInfo.TerrainType.Sea)
            {
                population.X = oldX;
                population.Y = oldY;
                if (SimWorld.globalRandom.NextDouble() > 0.5)
                {
                    deltaY *= -1;
                }
                else
                {
                    deltaX *= -1;
                }
            }

            population.VisibleCell.X = population.X;
            population.VisibleCell.Y = population.Y;
        }
    }
}
