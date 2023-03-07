using UnityEngine;
using Assets.Scripts.Survival;
using Assets.Scripts.Interact;

namespace Assets.Scripts.WorldGeneration.AutoBuilding
{
    class AutoBuildShack : AutoBuild
    {
        public AutoBuildShack(MapTile[,] map, int x, int y, int dimX, int dimY) : base(map, x, y, dimX, dimY) { }

        public AutoBuildShack() { }
        public override void Build()
        {
            //Cant do this yet need to optimize maptile
            //GameObject ceiling = UnityEngine.Resources.Load<GameObject>("Prefabs/Structures/Shack/MetalRoof");
            GameObject flooring = UnityEngine.Resources.Load<GameObject>("Prefabs/Structures/ConnexHome1/MetalFloor");
            GameObject stove = UnityEngine.Resources.Load<GameObject>("Prefabs/Furniture/Stove");
            GameObject bed = UnityEngine.Resources.Load<GameObject>("Prefabs/Furniture/Bed");
            GameObject storage = UnityEngine.Resources.Load<GameObject>("Prefabs/Furniture/Storage");

            stove = Instantiate(stove, new Vector3(x, y, -0.5f), Quaternion.identity);
            bed = Instantiate(bed, new Vector3((float)(x + dimX) - 1.5f, y + dimY - 1, -0.5f), Quaternion.identity);
            storage = Instantiate(storage, new Vector3(x, y + dimY - 1, -0.5f), Quaternion.identity);

            //Redundant, REMEDY AFTER TESTING
            GameObject actor = UnityEngine.Resources.Load<GameObject>("Prefabs/AI/AIActor");
            actor = Instantiate(actor, new Vector3(x + dimX / 2, y + dimY / 2, 0.0f), Quaternion.Euler(new Vector3(0, 90, -90)));
            Needs needs = actor.GetComponent<Needs>();
            needs.stove = stove.GetComponent<Stove>();
            needs.storage = stove.GetComponent<Container>();
            needs.bed = bed.GetComponent<Bed>();

            for (int i = x; i < x + dimX; i++)
            {
                for (int j = y; j < y + dimY; j++)
                {
                    flooring = Instantiate(flooring, new Vector3((float)(i), (float)(j), 0.0f), Quaternion.identity);
                    MapTile mapTile = flooring.GetComponent<MapTile>();
                    map[i, j] = mapTile;
                    mapTile.x = i;
                    mapTile.y = j;


                    //if (j == y)
                    //    Instantiate(connexFront, new Vector3((float)(i), (float)(j - 0.5f), -1.5f), Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f)));
                }
            }

            //shelter.Add(Instantiate(ceiling, new Vector3((float)(x + 2), (float)(y + 1), -3.0f), Quaternion.Euler(-45.0f, 0.0f, 0.0f)));
        }
    }
}
