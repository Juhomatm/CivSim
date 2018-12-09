using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RLNET;

namespace AsciiSim
{
    public class Program
    {
        private static RLRootConsole rootConsole;
        private static Root root;

        private static double elapsed;

        public static void Main()
        {
            int width = 200, height = 120;
            rootConsole = new RLRootConsole("ascii_8x8.png", width, height, 8, 8);
            root = new Root();
            rootConsole.Render += (s, e) => root.RenderManager.RenderDirtyCells(rootConsole);
            rootConsole.Update += RootConsole_Update;
            rootConsole.Run();
        }



        private static void RootConsole_Update(object sender, UpdateEventArgs e)
        {
            double interval = 0.1;
            elapsed += e.Time;
            if(elapsed < interval)
            {
                return;
            }
            elapsed -= interval;
            root.Update();
        }
    }
}
