using GraphCruncher.Pathfinding;
using System.Collections.Generic;
using System;

class GridAStarX {

    public static void FindPath(INavGrid grid, IGridPoint start, IGridPoint destination)
    {
        AStar.FindPath(start, destination, (p1, p2) => (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y), p => grid.getPassableNeighbours(p));
    }
}


class GridPoint : IGridPoint
{
    public GridPoint(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }
}

public interface IGridPoint
{
    int X { get; set; }
    int Y { get; set; }
}

interface IGridPath
{
    IGridPoint GetPathNodePoint(int index);
}

class GridPath : IGridPath
{
    private int[] xs;
    private int[] ys;

    public GridPath(IGridPoint[] points)
    {
        xs = new int[points.Length];
        ys = new int[points.Length];
        int i = -1;
        foreach (var p in points)
        {
            i++;
            xs[i] = p.X;
            ys[i] = p.Y;
        }
    }

    public IGridPoint GetPathNodePoint(int index)
    {
        return new GridPoint(xs[index], ys[index]);
    }
}

public interface INavGrid
{
    void SetPassable(IGridPoint point, bool isPassable);
    bool IsPassable(IGridPoint point);
    IEnumerable<IGridPoint> getPassableNeighbours(IGridPoint p);
}

public class NavGrid : INavGrid
{
    HashSet<Pair> obastaclePoints = new HashSet<Pair>();

    public IEnumerable<IGridPoint> getPassableNeighbours(IGridPoint p)
    {
        List<IGridPoint> neighbours = new List<IGridPoint>();
        for (int relativeX = -1; relativeX <= 1; relativeX++)
        {
            for (int relativeY = -1; relativeY <= 1; relativeY++)
            {
                if (relativeX == 0 && relativeY == 0)
                {
                    continue;
                }
                int x = p.X + relativeX;
                int y = p.Y + relativeY;
                if (IsPassable(new GridPoint(x, y)))
                {
                    neighbours.Add(new GridPoint(p.X + relativeX, p.Y + relativeY));
                }
            }
        }
        return neighbours;
    }

    public bool IsPassable(IGridPoint point)
    {
        return obastaclePoints.Contains(Pair.fromPoint(point));
    }

    public void SetPassable(IGridPoint point, bool isPassable)
    {
        var coordinates = Pair.fromPoint(point);
        bool isObstacle = obastaclePoints.Contains(coordinates);
        if (isPassable && isObstacle)
        {
            obastaclePoints.Remove(coordinates);
        }
        else if (!isPassable && !isObstacle)
        {
            obastaclePoints.Add(coordinates);
        }
    }

    private struct Pair
    {
        public static Pair fromPoint(IGridPoint p)
        {
            return new Pair() { First = p.X, Second = p.Y };
        }

        public int First;
        public int Second;

        public override Int32 GetHashCode()
        {
            return First.GetHashCode() ^ Second.GetHashCode();
        }
    }
}