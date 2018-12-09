using System.Collections.Generic;

namespace CivSim.AI
{
    internal interface IAcceptsInput
    {
        void AcceptInput(List<ResourceBatch> resourceBatches);
    }
}