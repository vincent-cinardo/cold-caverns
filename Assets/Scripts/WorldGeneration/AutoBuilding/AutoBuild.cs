using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.WorldGeneration.AutoBuilding
{
    public abstract class AutoBuild : MonoBehaviour
    {
        protected List<GameObject> shelter;
        public MapTile[,] map;
        public int x;
        public int y;
        public int dimX;
        public int dimY;
        /* Specify a position in the map which the autobuild will ensue,
         * taking place from bottom left to top right.
         */
        public AutoBuild() { }
        public AutoBuild(MapTile[,] map, int x, int y, int dimX, int dimY)
        {
            this.map = map;
            this.x = x;
            this.y = y;
            this.dimX = dimX;
            this.dimY = dimY;
            shelter = new List<GameObject>();
        }

        public void SetVars(MapTile[,] map, int x, int y, int dimX, int dimY)
        {
            this.map = map;
            this.x = x;
            this.y = y;
            this.dimX = dimX;
            this.dimY = dimY;
            shelter = new List<GameObject>();
        }

        public abstract void Build();
    }
}