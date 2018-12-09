using RLNET;
using System.Collections.Generic;

namespace Common
{
    public interface IVisibleCellManager
    {
        VisibleCell getNewCell(Character character, int x, int y, RLColor color, int layer = 0);
        List<int> VisibleLayers { get; }
    }
}