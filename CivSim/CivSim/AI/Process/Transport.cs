//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CivSim.AI
//{
//    public class Transport
//    {

//    }

//    class Transport<T> : Transport where T : Resource
//    {
//        public ProcessNode InputNode { get; set; }
//        public ProcessNode OutputNode { get; set; }

//        public ResourceBatch NewResourceBatch;
//        public ResourceBatch OutgoingResourceBatch;

//        public void Input(ResourceBatch resourceBatch)
//        {
//            NewResourceBatch = resourceBatch;
//        }

//        public void Update()
//        {
//            OutputNode.Input(OutgoingResourceBatch);
//        }
//    }
//}
