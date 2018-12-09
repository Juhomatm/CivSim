
namespace GraphCruncher.Pathfinding
{
    /// <summary>
    /// Search node should implement this interface if it needs to know its parent node to make the estimates.
    /// </summary>
    public interface INeedsToKnowParent<T>
    {
        void SetParent(T parent);
    }
}
