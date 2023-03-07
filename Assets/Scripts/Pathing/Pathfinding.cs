using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pathing
{
    public class Pathfinding : MonoBehaviour
    {
        public static List<Pathnode> FindPath(int mapSize, Pathnode start, Pathnode target)
        {
            Heap<Pathnode> open = new Heap<Pathnode>(mapSize);
            HashSet<Pathnode> closed = new HashSet<Pathnode>();

            open.AddNode(start);

            while (open.count > 0)
            {
                Pathnode current = open.RemoveRoot();
                closed.Add(current);

                if (current.x == target.x && current.y == target.y)
                {
                    return RetracePath(current);
                }

                foreach (Pathnode neighbor in current.tile.GetNeighbors())
                {
                    if (!neighbor.tile.traversable || closed.Contains(neighbor)) //Remember to check if its walkable first. !neighbor.tile.walkable
                        continue;

                    int costToNeighbor = current.g + Heuristic(current, neighbor);
                    if (costToNeighbor < neighbor.g || !(open.Contains(neighbor)))
                    {
                        neighbor.previous = current;
                        neighbor.g = costToNeighbor;
                        neighbor.h = Heuristic(neighbor, target);
                        neighbor.f = neighbor.g + neighbor.h;
                        if (!(open.Contains(neighbor)))
                            open.AddNode(neighbor);
                    }
                }
            }

            return new List<Pathnode>();
        }

        public static List<Pathnode> RetracePath(Pathnode lastNode)
        {
            List<Pathnode> path = new List<Pathnode>();
            Pathnode current = lastNode;

            while (current.previous != null)
            {
                path.Add(current);
                current = current.previous;
            }
            path.Reverse();
            return path;
        }

        public static int Heuristic(Pathnode start, Pathnode target)
        {
            int dx = Math.Abs(start.x - target.x);
            int dy = Math.Abs(start.y - target.y);
            return dx > dy ?
                14 * dy + 10 * (dx - dy) :
                14 * dx + 10 * (dy - dx);
        }

        public static float Heuristic(Vector3 start, Vector3 target)
        {
            float dx = Mathf.Abs(start.x - target.x);
            float dy = Mathf.Abs(start.y - target.y);
            return dx > dy ?
                14.0f * dy + 10.0f * (dx - dy) :
                14.0f * dx + 10.0f * (dy - dx);
        }
    }
}
