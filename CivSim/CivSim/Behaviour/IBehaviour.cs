using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivSim.Behaviour
{
    interface IBehaviour<T>
    {
        void Update(T obj, SimWorld world);
    }
}
