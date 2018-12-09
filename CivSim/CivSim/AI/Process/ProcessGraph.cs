//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CivSim.AI
//{
//    class ProcessGraph
//    {
//        private List<ProcessNode> _processNodes = new List<ProcessNode>();

//        public void Register(ProcessNode node)
//        {
//            _processNodes.Add(node);
//        }

//        public void Unregister(ProcessNode node)
//        {
//            _processNodes.Remove(node);
//        }

//        public void Update()
//        {
//            foreach (var node in _processNodes)
//            {
//                node.ProcessOutputs();
//            }
//            foreach (var node in _processNodes)
//            {
//                node.OnTickEnd();
//            }
//        }
//    }
//}
