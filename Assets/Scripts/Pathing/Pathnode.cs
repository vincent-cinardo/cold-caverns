using UnityEngine;

namespace Assets.Scripts.Pathing
{
    public class Pathnode : IHeapItem<Pathnode>
    {
        public MapTile tile;
        public Pathnode previous;
        public int x, y;
        public int g, h;
        public int f;
        public int n { get; set; }
        public Pathnode(Pathnode node, int x, int y)
        {
            this.previous = node;
            this.x = x;
            this.y = y;
            g = 0;
            h = 0;
            f = 0;
        }
        public Pathnode(MapTile tile, int x, int y)
        {
            this.tile = tile;
            this.previous = null;
            this.x = x;
            this.y = y;
            g = 0;
            h = 0;
            f = 0;
        }
        public Pathnode(MapTile tile)
        {
            this.tile = tile;
            this.previous = null;
            this.x = tile.x;
            this.y = tile.y;
            Debug.Log("Pathnode x is " + x);
            Debug.Log("Pathnode x is " + y);
            g = 0;
            h = 0;
            f = 0;
        }

        public int CompareTo(Pathnode node)
        {
            int compare = f.CompareTo(node.f);
            if (compare == 0)
            {
                compare = h.CompareTo(node.h);
            }
            return compare;
        }

        public void Print()
        {
            Debug.Log("Node[" + tile.x + "," + tile.y + "]");
        }
    }
}