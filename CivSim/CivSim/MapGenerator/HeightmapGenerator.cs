using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivSim.MapGenerator
{
    class HeightmapGenerator
    {
        NoiseGenerator _noiseGenerator = new NoiseGenerator();

        public int GetHeight(int x, int y, int width, int height)
        {
            int a0 = (int)((255 * 1) * GetHeight(x, y, _noiseGenerator));

            double distanceToCenter = DistanceToCenter(x, y, width, height);
            double treshold = 0.4;
            double distance;
            if (distanceToCenter > treshold)
            {
                distance = distanceToCenter;
            }
            else
            {
                distance = treshold;
            }
            double b = Math.Max(0, 1 - (distanceToCenter));
            a0 = (int)(a0 * b);
            if (a0 > 255)
            {
                a0 = 255;
            }
            if (a0 < 0)
            {
                a0 = 0;
            }
            return a0;
        }


        private static double GetHeight(int x, int y, NoiseGenerator noiseGenerator)
        {
            return (1 + noiseGenerator.Noise(x, y)) / 2;
        }

        static double DistanceToCenter(int x, int y, int width, int height)
        {
            double maxDistance = Math.Sqrt((width * width) + (height * height)) / 2;

            double dx = x - (width / 2);
            double dy = y - (height / 2);

            return Math.Sqrt((dx * dx) + (dy * dy)) / maxDistance;
        }
    }
}
