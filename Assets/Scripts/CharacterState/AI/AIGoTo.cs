using UnityEngine;
using System;
using Assets.Scripts.Pathing;
using System.Collections.Generic;
using Assets.Scripts.WorldGeneration;

namespace Assets.Scripts.CharacterState.AI
{
    public class AIGoTo : AIState
    {
        public List<Pathnode> path;
        private Pathnode start;
        private Pathnode end;
        private Vector2 loc;
        private float travelTime;

        /// <summary>
        /// Create a path to the destination on the map and begin travel.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="mapTile"></param>
        /// <param name="stopShort">Specify whether to stop short of the target or occupy the same tile.</param>
        public AIGoTo(AIController handler, MapTile mapTile, bool stopShort) : base(handler)
        {
            start = new Pathnode(
                LocalMap.tiles[(int)(transform.position.x), (int)(transform.position.y)],
                (int)(transform.position.x),
                (int)(transform.position.y)
            );

            end = new Pathnode(mapTile, mapTile.x, mapTile.y);

            path = new List<Pathnode>();

            path = Pathfinding.FindPath(
                LocalMap.mapSizeX * LocalMap.mapSizeY,
                start,
                end
            );

            if (path.Count > 0 && stopShort)
            {
                path.RemoveAt(path.Count - 1);
            }

            loc = new Vector2(transform.position.x, transform.position.y);

            animator.Play("Walk");
        }

        public override void Update()
        {
            if (path.Count != 0)
            {
                float speed = 3.0f;
                float xDir = path[0].x - loc.x;
                float yDir = path[0].y - loc.y;
                float angle = Mathf.Rad2Deg * Mathf.Atan2(yDir, xDir);
                float xDist = Math.Abs(transform.position.x - path[0].x);
                float yDist = Math.Abs(transform.position.y - path[0].y);

                rigidbody.velocity = new Vector3(xDir, yDir, 0.0f) * speed;
                transform.rotation = Quaternion.Euler(-angle, 90.0f, -90.0f);

                if (xDist <= 0.1f && yDist <= 0.1f)
                {
                    loc = new Vector2(path[0].x, path[0].y);
                    path.RemoveAt(0);
                }
            }
            else
            {
                Debug.Log(handler.gameObject.name + "arrived at destination ");
                rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
                handler.state = handler.stateQueue.Dequeue();
            }
        }
    }
}