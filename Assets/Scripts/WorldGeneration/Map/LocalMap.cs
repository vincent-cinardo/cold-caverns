using UnityEngine;

namespace Assets.Scripts.WorldGeneration
{
    public class LocalMap : MonoBehaviour
    {
        public int mapSize;
        public GameObject caveWall;
        public static int mapSizeX;
        public static int mapSizeY;
        public static MapTile[,] tiles;

        // Start is called before the first frame update
        //IMPROVE THE READABILITY OF THIS

        void Start()
        {
            mapSizeX = mapSize;
            mapSizeY = mapSize;
            tiles = new MapTile[mapSizeX, mapSizeY];
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    GameObject tile = UnityEngine.Resources.Load<GameObject>("Prefabs/Structures/Natural/MapTile");
                    tile = Instantiate(tile, new Vector3((float)x, (float)y, 0.0f), Quaternion.identity);
                    tiles[x, y] = tile.GetComponent<MapTile>();
                    tiles[x, y].x = x;
                    tiles[x, y].y = y;
                    if (Random.Range(0.0f, 1.0f) < 0.02f)
                    {
                        GameObject obj = UnityEngine.Resources.Load<GameObject>("Prefabs/Props/GlowFungus_B") as GameObject;
                        //tiles[x, y].structure = Instantiate(obj, new Vector3((float)x, (float)y, -0.1f), Quaternion.identity);
                    }
                }
            }

            for (int x = 0; x < mapSizeX; x++)
            {
                if (tiles[x, 0].structure != null)
                    Object.Destroy(tiles[x, 0].structure);

                if (tiles[x, 1].structure != null)
                    Object.Destroy(tiles[x, 1].structure);

                tiles[x, 0].structure = Instantiate(caveWall, new Vector3((float)x, 0.0f, -1.0f), Quaternion.identity);
                tiles[x, mapSizeY - 1].structure = Instantiate(caveWall, new Vector3((float)x, (float)(mapSizeY - 1), -1.0f), Quaternion.identity);
                if (Random.Range(0, 3) > 0)
                    tiles[x, 1].structure = Instantiate(caveWall, new Vector3((float)x, 1.0f, -1.0f), Quaternion.identity);
                if (Random.Range(0, 3) > 0)
                    tiles[x, mapSizeY - 2].structure = Instantiate(caveWall, new Vector3((float)x, (float)(mapSizeY - 2), -1.0f), Quaternion.identity);
            }

            for (int y = 0; y < mapSizeY; y++)
            {
                if (tiles[0, y].structure != null)
                    Object.Destroy(tiles[0, y].structure);

                if (tiles[mapSizeX - 1, y].structure != null)
                    Object.Destroy(tiles[mapSizeX - 1, y].structure);

                tiles[0, y].structure = Instantiate(caveWall, new Vector3(0.0f, (float)y, -1.0f), Quaternion.identity);
                tiles[mapSizeX - 1, y].structure = Instantiate(caveWall, new Vector3((float)(mapSizeX - 1), (float)y, -1.0f), Quaternion.identity);
                if (Random.Range(0, 3) > 0)
                    tiles[1, y].structure = Instantiate(caveWall, new Vector3(1.0f, (float)y, -1.0f), Quaternion.identity);
                if (Random.Range(0, 3) > 0)
                    tiles[mapSizeX - 2, y].structure = Instantiate(caveWall, new Vector3((float)(mapSizeX - 2), (float)y, -1.0f), Quaternion.identity);
            }

            //Build roads and buildings
            BuildingGeneration buildingGeneration = new BuildingGeneration(tiles, mapSizeX, mapSizeY);
            //buildingGeneration.Generate();
        }

        public static bool TileIsEmpty(int x, int y)
        {
            return tiles[x, y].structure == null;
        }

        public static void SetStructure(GameObject structure, int x, int y)
        {
            tiles[x, y].structure = structure;
        }
    }
}
