using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivSim.AI
{
    public enum ResourceType
    {
        
    }

    class Resource
    {
        public int Quantity { get; set; }
        public ResourceType Type { get; private set; }
    }
}
