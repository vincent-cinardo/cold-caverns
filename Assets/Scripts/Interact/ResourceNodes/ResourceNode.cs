using UnityEngine;
using Assets.Scripts.Survival;
using Assets.Scripts.UI;

namespace Assets.Scripts.Interact.ResourceNodes
{
    public abstract class ResourceNode : Interactable
    {
        protected float value;
        public ProvisionManager provisionManager;

        void Start()
        {
            base.Start();
            provisionManager = GameObject.Find("GameManager").GetComponent<ProvisionManager>();
        }
        public abstract float Gather(float amount);

        public override void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains("Actor"))
            {
                other.GetComponent<Controller>().nearbyResources.Add(this);
                if (other.name.Contains("Player"))
                {
                    GameObject.Find("UICanvas").GetComponent<ActionListManager>().AddAction(this);
                }
            }
        }
        public override void OnTriggerExit(Collider other)
        {
            if (other.name.Contains("Actor"))
            {
                other.GetComponent<Controller>().nearbyResources.Remove(this);
                if (other.name.Contains("Player"))
                {
                    GameObject.Find("UICanvas").GetComponent<ActionListManager>().RemoveAction(this);
                }
            }
        }
    }
}