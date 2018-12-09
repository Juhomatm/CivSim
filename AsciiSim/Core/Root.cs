using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiSim
{
    class Root
    {
        public RenderManager RenderManager { get; set; }
        public IWorld World { get; set; }

        public Root()
        {
            RenderManager = new RenderManager();
            World = new CivSim.SimWorld(RenderManager);
            //World = new Level(RenderManager, width, height);
        }

        public void Update()
        {
            World.Update();
        }
    }
}
