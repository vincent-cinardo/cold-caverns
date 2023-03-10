using UnityEngine;
using Assets.Scripts.Items;
using Assets.Scripts.UI;
using Assets.Scripts.WorldGeneration;

namespace Assets.Scripts.Interact
{
    public abstract class Interactable : MonoBehaviour
    {
        public ActionListManager actionListManager;
        public Controller controller;
        public MapTile mapTile;
        public string message;

        public enum TYPE {
            FUEL, WATER, FOOD
        };

        public TYPE type;

        protected void Start()
        {
            actionListManager = GameObject.Find("UICanvas").GetComponent<ActionListManager>();
            mapTile = LocalMap.tiles[(int)transform.position.x, (int)transform.position.y];
            //Debug.Log(name + " is at " + transform.position.x + " and " + transform.position.y);
        }

        //IMPORTANT!!!!!!!!!!!!! In the future, the controller will be passed in.
        //This ensures that both player and AI controllers can be called.
        public virtual void Interact() { }
        public virtual void Take(Item item) { }

        public virtual void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains("Actor"))
            {
                other.GetComponent<Controller>().nearbyInteractables.Add(this);
                if (other.name.Contains("Player"))
                {
                    GameObject.Find("UICanvas").GetComponent<ActionListManager>().AddAction(this);
                }
            }
        }
        public virtual void OnTriggerExit(Collider other)
        {
            if (other.name.Contains("Actor"))
            {
                other.GetComponent<Controller>().nearbyInteractables.Remove(this);
                if (other.name.Contains("Player"))
                {
                    GameObject.Find("UICanvas").GetComponent<ActionListManager>().RemoveAction(this);
                } 
            }
        }
    }
}
