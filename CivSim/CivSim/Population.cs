using CivSim.Behaviour;
using CivSim.Items;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivSim
{
    class Population
    {
        public int X { get; set; }
        public int Y { get; set; }
        public VisibleCell VisibleCell { get; private set; }

        public List<IBehaviour<Population>> Behaviours { get; private set; }
        public List<IItem> Items { get; private set; }

        public Population(int x, int y, IVisibleCellManager visibleCellManager)
        {
            X = x;
            Y = y;
            VisibleCell = visibleCellManager.getNewCell(new Character(SpecialCharacter.Dude), X, Y, RLNET.RLColor.Cyan);
            Behaviours = new List<IBehaviour<Population>>();
            Behaviours.Add(new Roam());
        }

        internal void Update(SimWorld simWorld)
        {
            foreach (IBehaviour<Population> behaviour in Behaviours)
            {
                behaviour.Update(this, simWorld);
            }
        }
    }
}
