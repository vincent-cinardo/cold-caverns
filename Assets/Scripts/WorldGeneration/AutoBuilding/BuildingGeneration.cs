using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.WorldGeneration.AutoBuilding;
using Random = UnityEngine.Random;

namespace Assets.Scripts.WorldGeneration
{
    class BuildingGeneration : MonoBehaviour
    {
        struct MapStructure {
            public int dimX;
            public int dimY;
            public AutoBuild autoBuild;
            public MapStructure(int dimX, int dimY, AutoBuild autoBuild)
            {
                this.dimX = dimX;
                this.dimY = dimY;
                this.autoBuild = autoBuild;
            }
        }
        struct MapChunk{
            public MapTile[,] mapTiles;
        };

        private List<MapStructure> structures;
        private MapChunk[,] mapChunks;
        private MapTile[,] mapTiles;

        public BuildingGeneration(MapTile[,] mapTiles, int sizeX, int sizeY)
        {
            //Define a list of predefined buildings
            structures = new List<MapStructure>();
            structures.Add(new MapStructure(9, 5, new AutoBuildConnex1()));
            structures.Add(new MapStructure(5, 5, new AutoBuildShack()));
            structures.Add(new MapStructure(3, 3, new AutoBuildJunkHome()));

            this.mapTiles = mapTiles;

            //Ensures each chunk is 10x10, must be some size which is divisible by the map dimensions.
            int chunkSize = 10;
            int chunkX = sizeX / chunkSize;
            int chunkY = sizeY / chunkSize;
            mapChunks = new MapChunk[chunkX, chunkY];

            //Divide map into chunks, which contain cells refering to map tiles.
            for (int x = 0; x < chunkX; x++)
            {
                for (int y = 0; y < chunkY; y++)
                {
                    mapChunks[x, y] = new MapChunk();
                    mapChunks[x, y].mapTiles = new MapTile[chunkSize, chunkSize];
                    for (int i = 0; i < chunkSize; i++)
                    {
                        for (int j = 0; j < chunkSize; j++)
                        {
                            mapChunks[x, y].mapTiles[i, j] = mapTiles[x * chunkSize + i, y * chunkSize + j];
                        }
                    }
                }
            }

            for (int x = 0; x < chunkX; x++)
            {
                for (int y = 0; y < chunkY; y++)
                {
                    //Randomly pick an object from structures array.
                    MapStructure structure = structures[Random.Range(0, structures.Count)];
                    AutoBuild autoBuild = structure.autoBuild;

                    //Random range between 0 to max distance we will place the object, without going over into the next chunk.
                    int mx = Random.Range(0, chunkSize - structure.dimX);
                    int my = Random.Range(0, chunkSize - structure.dimY);
                    

                    //Original locations, chunk-to-original coordinates.
                    int ox = x * chunkSize + mx;
                    int oy = y * chunkSize + my;

                    bool skip = false; ;
                    for (int i = 0; i < structure.dimX; i++)
                    {
                        for (int j = 0; j < structure.dimY; j++)
                        {
                            if (mapChunks[x, y].mapTiles[i + mx, j + my].structure != null)
                            {
                                skip = true;
                            }
                        }

                        if (skip)
                            break;

                        for (int j = 0; j < structure.dimY; j++)
                        {
                            Destroy(mapChunks[x, y].mapTiles[i + mx, j + my].gameObject);
                        }
                    }

                    if (skip)
                        continue;

                    autoBuild.SetVars(mapTiles, ox, oy, structure.dimX, structure.dimY);
                    autoBuild.Build();
                }
            }
        }
    }
}
