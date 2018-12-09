using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivSim.AI
{
    abstract class Multiplexer : IAcceptsInput
    {
        public List<IAcceptsInput> Outputs { get; set; }

        public abstract void AcceptInput(List<ResourceBatch> resourceBatches);
    }
}
