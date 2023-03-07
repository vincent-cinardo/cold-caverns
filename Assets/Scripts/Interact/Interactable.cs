using UnityEngine;
using Assets.Scripts.Items;
using Assets.Scripts.UI;
using Assets.Scripts.WorldGeneration;

namespace Assets.Scripts.Interact
{
    public abstract class Interactable : MonoBehaviour
    {
        public MapTile mapTile;
        public ActionListManager actionListManager;
        public Controller controller;
        public string message;
        public enum TYPE {
            GATHER, PICKUP, STORAGE
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

        public virtual float Gather(float amount) { return 0; }
        public virtual void Take(Item item) { }

        void OnTriggerEnter(Collider other)
        {
            if (other.name == "Player")
            {
                other.GetComponent<Controller>().nearbyInteractables.Add(this);
                if (GameObject.Find("UICanvas").GetComponent<ActionListManager>())
                    Debug.Log("Nice");
                GameObject.Find("UICanvas").GetComponent<ActionListManager>().AddAction(this);
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.name == "Player")
            {
                other.GetComponent<Controller>().nearbyInteractables.Remove(this);
                GameObject.Find("UICanvas").GetComponent<ActionListManager>().RemoveAction(this);
            }
        }
    }
}
