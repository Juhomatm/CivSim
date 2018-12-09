//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CivSim.AI
//{
//    class PassThroughReactor : Reactor
//    {
//        List<ResourceBatch> _resourceBatches;

//        public override void Add(List<ResourceBatch> incomingResourceBatches)
//        {
//            _resourceBatches = incomingResourceBatches;
//        }

//        public override List<ResourceBatch> GetOutput()
//        {
//            List<ResourceBatch> resourceBatches = _resourceBatches;
//            _resourceBatches = null;
//            return resourceBatches;
//        }
//    }
//}
