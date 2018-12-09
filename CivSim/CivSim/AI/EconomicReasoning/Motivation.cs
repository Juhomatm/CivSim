using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivSim.AI
{
    class Motivation
    {
        public List<KeyValuePair<int, ToDoEntry>> ToDoList { get; set; }

        public Dictionary<ResourceType, MarginalValue> ResourceMarginalValues { get; set; }


    }
}
