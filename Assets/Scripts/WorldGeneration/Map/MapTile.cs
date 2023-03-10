using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Pathing;
using Assets.Scripts.WorldGeneration;

public class MapTile : MonoBehaviour
{
    public GameObject[] Items;
    public int x, y;
    //Keep this below 0
    public float noiseScale;
    public bool traversable = true;
    public bool reserve = false;
    public GameObject structure = null;
    private bool onStart = true;

    private enum Flooring {
        STONE, ICE
    }

    private MeshRenderer spriteR;
    private int FloorType;

    public MapTile(bool onStart)
    {
        this.onStart = onStart;
    }

    void Awake()
    {
        traversable = true;
        spriteR = gameObject.GetComponent<MeshRenderer>();
        if (onStart)
        {
            noiseScale = 4.0f;
            FloorType = UnityEngine.Random.Range((int)Flooring.STONE, (int)Flooring.ICE + 1);
            Debug.Log(noiseScale);
            SetFloorSprite(FloorType);
        }
    }

    void SetFloor(int FloorType)
    {
        this.FloorType = FloorType;
    }

    void SetFloorSprite(int FloorType)
    {
        float offset = (float) UnityEngine.Random.Range(0, 1000);
        float sampleX = (((float)x / (float)LocalMap.mapSizeX) * noiseScale);
        float sampleY = (((float)y / (float)LocalMap.mapSizeY) * noiseScale);
        float perlin = Mathf.PerlinNoise(sampleX + 500.0f, sampleY + 500.0f);
        Debug.Log(x + "," + y + " divided by "+ noiseScale + " so perlin(" + sampleX + ", " + sampleY + ") = " + perlin);

        if (perlin < 0.40f)
        {
            FloorType = (int)Flooring.STONE;
        }
        else if (perlin < 0.8f)
        {
            FloorType = (int)Flooring.ICE;
        }

        switch (FloorType)
        {
            //Need to find a way to make these into mesh renderer
            case (int) Flooring.STONE:
                spriteR.material = Resources.Load<Material>("Materials/Ice") as Material;
                //Debug.Log(spriteR.material.GetTexture());
                break;
            case (int) Flooring.ICE:
                    spriteR.material = Resources.Load<Material>("Materials/Stone") as Material;
                break;
        }
    }
    public List<Pathnode> GetNeighbors()
    {
        DateTime before = DateTime.Now;
        float xf = (float)x;
        float yf = (float)y;
        List<Pathnode> neighbors = new List<Pathnode>();
        int mapW = LocalMap.mapSizeX;
        int mapH = LocalMap.mapSizeY;
        
        //West neighbor
        if (x > 0)
        {
            neighbors.Add(new Pathnode(LocalMap.tiles[x - 1, y], x - 1, y));

            //Southwest
            if(y > 0)
                neighbors.Add(new Pathnode(LocalMap.tiles[x - 1, y - 1], x - 1, y - 1));
            //Northwest
            if (y < mapH - 1)
                neighbors.Add(new Pathnode(LocalMap.tiles[x - 1, y + 1], x - 1, y + 1));
        }

        //East neighbor
        if (x < mapW - 1)
        {
            neighbors.Add(new Pathnode(LocalMap.tiles[x + 1, y], x + 1, y));

            //Southeast neighbor
            if (y > 0)
                neighbors.Add(new Pathnode(LocalMap.tiles[x + 1, y - 1], x + 1, y - 1));

            //Northeast neighbor
            if (y < mapH - 1)
                neighbors.Add(new Pathnode(LocalMap.tiles[x + 1, y + 1], x + 1, y + 1));
        }

        //South neighbor
        if (y > 0)
            neighbors.Add(new Pathnode(LocalMap.tiles[x, y - 1], x, y - 1));

        //North neighbor
        if (y < mapH - 1)
            neighbors.Add(new Pathnode(LocalMap.tiles[x, y + 1], x, y + 1));

        return neighbors;
    }
}