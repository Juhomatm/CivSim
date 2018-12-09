using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivSim.AI
{
    class ResourceBatch
    {
        public Resource Resource { get; set; }
        public int Quantity { get; set; }

        internal ResourceBatch Add(ResourceBatch resourceBatch)
        {
            throw new NotImplementedException();
        }
    }
}
