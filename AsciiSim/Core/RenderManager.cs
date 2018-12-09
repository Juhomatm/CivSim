using Common;
using RLNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiSim
{
    class RenderManager : IVisibleCellManager
    {
        private List<VisibleCell> _visibleCells;
        public List<int> VisibleLayers { get; private set; }

        public RenderManager()
        {
            _visibleCells = new List<VisibleCell>();
            VisibleLayers = new List<int>();
            VisibleLayers.Add(0);
        }

        VisibleCell IVisibleCellManager.getNewCell(Character character, int x, int y, RLColor color, int layer)
        {
            VisibleCell cell = new VisibleCell(x, y, character, color, layer);
            _visibleCells.Add(cell);
            return cell;
        }

        public void Delete(VisibleCell cell)
        {
            _visibleCells.Remove(cell);
        }

        public void RenderDirtyCells(RLRootConsole console)
        {
            console.Clear();
            foreach (VisibleCell cell in _visibleCells)
            {
                if(VisibleLayers.Contains(cell.Layer))
                console.Set(cell.X, cell.Y, cell.Color, cell.BackColor, cell.Character.Code);
            }
            console.Draw();
        }
    }
}

