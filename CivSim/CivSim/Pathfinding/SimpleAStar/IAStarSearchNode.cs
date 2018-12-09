using System.Collections.Generic;

namespace GraphCruncher.Pathfinding
{
    public interface IAStarSearchNode<T>
    {
        IEnumerable<T> Neighbours { get; }
    }
}
