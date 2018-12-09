using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphCruncher.Pathfinding
{
    class AStar
    {
        public static T[] FindPath<T>(
            T start,
            T destination,
            Func<T, T, double> getDistanceBetween,
            Func<T, IEnumerable<T>> getNeighbours)
        {
            DefaultNode<T> startingNode = new DefaultNode<T>(start, destination, getNeighbours);
            DefaultNode<T> destinationNode = new DefaultNode<T>(destination, destination, getNeighbours);
            Func<DefaultNode<T>, DefaultNode<T>, double> totalDistanceSoFar = (n1, n2) => getDistanceBetween(n1.Item, n2.Item);
            Func<DefaultNode<T>, double> estimateToDestination = (n) => getDistanceBetween(n.Item, destination);

            Path<DefaultNode<T>> path = FindPath(startingNode, destinationNode, totalDistanceSoFar, estimateToDestination);
            if (path == null)
            {
                return null;
            }
            return path
                .Select(n => n.Item)
                .ToArray();
        }

        public static Path<TNode> FindPath<TNode>(
            TNode start,
            TNode destination,
            Func<TNode, TNode, double> totalDistanceSoFar,
            Func<TNode, double> estimateToDestination)
            where TNode : IAStarSearchNode<TNode>
        {
            var closedNodes = new HashSet<TNode>();
            var priorityQueue = new PriorityQueue<double, Path<TNode>>();
            priorityQueue.Enqueue(0, new Path<TNode>(start));
            while (!priorityQueue.IsEmpty)
            {
                var path = priorityQueue.Dequeue();
                if (closedNodes.Contains(path.LastStep))
                {
                    continue;
                }
                if (path.LastStep.Equals(destination))
                {
                    return path;
                }
                closedNodes.Add(path.LastStep);
                foreach (TNode neighbourNode in path.LastStep.Neighbours)
                {
                    if (neighbourNode is INeedsToKnowParent<TNode>)
                    {
                        ((INeedsToKnowParent<TNode>)neighbourNode).SetParent(path.LastStep);
                    }
                    double d = totalDistanceSoFar(path.LastStep, neighbourNode);
                    var newPath = path.AddStep(neighbourNode, d);
                    double priority = newPath.TotalCost + estimateToDestination(neighbourNode);
                    priorityQueue.Enqueue(priority, newPath);
                }
            }
            return null;
        }
    }
}
