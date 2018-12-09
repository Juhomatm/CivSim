using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphCruncher.Pathfinding
{
    class DefaultNode<T> : IAStarSearchNode<DefaultNode<T>>
    {
        public DefaultNode(
            T item,
            T destination,
            Func<T, IEnumerable<T>> getNeighbours)
        {
            Item = item;
            Destination = destination;
            GetNeighbours = getNeighbours;
        }

        public T Item { get; private set; }
        public T Destination { get; private set; }
        public Func<T, IEnumerable<T>> GetNeighbours { get; private set; }

        public IEnumerable<DefaultNode<T>> Neighbours
        {
            get
            {
                foreach (T neighbour in GetNeighbours(Item))
                {
                    yield return new DefaultNode<T>(
                        neighbour,
                        Destination,
                        GetNeighbours);
                }
            }
        }

        #region Equals override

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            DefaultNode<T> otherNode = obj as DefaultNode<T>;
            if (otherNode == null)
            {
                return false;
            }

            return Item.Equals(otherNode.Item);
        }

        public bool Equals(DefaultNode<T> otherNode)
        {
            if (otherNode == null)
            {
                return false;
            }

            return Item.Equals(otherNode.Item);
        }

        public override int GetHashCode()
        {
            return Item.GetHashCode();
        }

        #endregion
    }
}
