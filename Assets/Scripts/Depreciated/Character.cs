using UnityEngine;
using Assets.Scripts.Pathing;
using System.Collections.Generic;
using Assets.Scripts.WorldGeneration;

public class Character : MonoBehaviour
{
    public Sprite[] sprites;
    public MapTile currentTile;
    public List<Pathnode> path;
    private Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        path = new List<Pathnode>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (path.Count > 0)
        {
            Vector3 moveLocation = new Vector3(path[0].x, path[0].y, -1.0f);
            float modifier;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                modifier = gameObject.GetComponent<CharacterSheet>().maxSpeed;
            }
            else
            {
                modifier = gameObject.GetComponent<CharacterSheet>().walkSpeed;
            }

            if (Mathf.Abs(gameObject.transform.position.x - moveLocation.x) < 0.01f && Mathf.Abs(gameObject.transform.position.y - moveLocation.y) < 0.01f)
            {
                currentTile = path[0].tile;
                path.Remove(path[0]);
                //Change look direction to next one here.
                //Need to optimize this.
                if (path.Count > 0)
                {
                    if (path[0].y - gameObject.transform.position.y < 0)
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];

                    }
                    else if (path[0].y - gameObject.transform.position.y == 0)
                    {
                        if (path[0].x - gameObject.transform.position.x < 0)
                        {
                            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
                        }
                        else gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
                    }
                    else gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
                }
            }
            else gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, moveLocation, Time.deltaTime * modifier);
        }
        else if (currentTile == null) //TRY TO OPTIMIZE WITH STATE MACHINE
        {
            currentTile = LocalMap.tiles[(int)Mathf.Floor(transform.position.x), (int)Mathf.Floor(transform.position.y)];
        }
    }
    public void SetPath(List<Pathnode> path)
    {
        if (this.path.Count > 0)
        {
            Pathnode currentDest = this.path[0];
            path[0] = currentDest;
            this.path = path;
        }
        else this.path = path;
    }
    public void SetPathClose(List<Pathnode> path)
    {
        if (this.path.Count > 0)
        {
            Pathnode currentDest = this.path[0];
            path[0] = currentDest;
            this.path = path;
        }
        else this.path = path;
        path.RemoveAt(path.Count - 1);
    }
}