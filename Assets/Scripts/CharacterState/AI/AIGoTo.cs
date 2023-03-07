using UnityEngine;
using System;
using Assets.Scripts.Pathing;
using System.Collections.Generic;
using Assets.Scripts.WorldGeneration;

namespace Assets.Scripts.CharacterState.AI
{
    public class AIGoTo : AIState
    {
        //Can make private;
        public List<Pathnode> path;
        private Vector2 loc;
        private Pathnode start;
        private Pathnode end;
        public AIGoTo(AIController handler, MapTile mapTile) : base(handler)
        {
            path = new List<Pathnode>();

            start = new Pathnode(
                LocalMap.tiles[(int)(transform.position.x), (int)(transform.position.y)],
                (int)(transform.position.x),
                (int)(transform.position.y)
            );
            end = new Pathnode(mapTile, mapTile.x, mapTile.y);
            start.Print();

            int x = (int)(transform.position.x);
            int y = (int)transform.position.y;

            Debug.Log(x + " and " + y + " are the transform positions to ints");
            Debug.Log("The map tile [x, y] is " + "[" + LocalMap.tiles[x, y].x + "," + LocalMap.tiles[x, y].y + "]");
            Debug.Log("Direct retrieval [12,12]" + " [" + LocalMap.tiles[12,12].x);

            foreach (Pathnode node in LocalMap.tiles[x, y].GetNeighbors()) 
            {
                node.Print();
            }

            path = Pathfinding.FindPath(
                LocalMap.mapSizeX * LocalMap.mapSizeY,
                start,
                end
            );

            loc = new Vector2(transform.position.x, transform.position.y);
            Debug.Log("T");
        }

        public override void Update()
        {
            if (path.Count != 0)
            {
                float xDir = path[0].x - loc.x;
                float yDir = path[0].y - loc.y;

                rigidbody.velocity = new Vector3(xDir, yDir, 0.0f);
                float angle = Mathf.Rad2Deg * Mathf.Atan2(yDir, xDir);
                transform.rotation = Quaternion.Euler(-angle, 90.0f, -90.0f);
                if (Math.Abs(transform.position.x - (float)path[0].x) <= 0.1f && Math.Abs(handler.transform.position.y - (float)path[0].y) <= 0.1f)
                {
                    loc = new Vector2(path[0].x, path[0].y);
                    path.RemoveAt(0);
                }
            }
            else
            {
                rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
                handler.state = handler.stateQueue.Dequeue();
            }
        }
    }
}
