//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CivSim.AI
//{
//    sealed class ProcessNode : IAcceptsInput
//    {
//        public List<ResourceBatch> IncomingResourceBatches { get; set; }
//        public Reactor ResourceBatchesUnderProcessing { get; set; }
//        public List<ResourceBatch> OutgoingResourceBatches { get; set; }

//        public Dictionary<ResourceType, IAcceptsInput> Outputs { get; set; }

//        public ProcessNode()
//        {
//            Outputs = new Dictionary<ResourceType, IAcceptsInput>();
//        }

//        public void AcceptInput(List<ResourceBatch> resourceBatches)
//        {
//            IncomingResourceBatches.AddRange(resourceBatches);
//        }

//        public void ProcessOutputs()
//        {
//            foreach (KeyValuePair<ResourceType, IAcceptsInput> outputEntry in Outputs)
//            {
//                outputEntry
//                    .Value
//                    .AcceptInput(OutgoingResourceBatches.Where(b => b.Resource.Type == outputEntry.Key).ToList());
//            }
//            OutgoingResourceBatches = null;
//        }

//        /** This should be run last. Clear incoming batches and add new outgoing batches. */
//        public void OnTickEnd()
//        {
//            ResourceBatchesUnderProcessing.Add(IncomingResourceBatches);
//            IncomingResourceBatches.Clear();
//            OutgoingResourceBatches = ResourceBatchesUnderProcessing.GetOutput();
//        }
//    }
//}
