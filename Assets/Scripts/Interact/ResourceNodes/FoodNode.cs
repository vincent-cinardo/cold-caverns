using UnityEngine;
using Assets.Scripts.Survival;

namespace Assets.Scripts.Interact.ResourceNodes
{
    public class FoodNode : ResourceNode
    {
        // Start is called before the first frame update
        void Start()
        {
            base.Start();
            type = TYPE.FOOD;
            value = 100.0f;
            name = "Food";
            message = "Gather " + name;
            provisionManager = GameObject.Find("GameManager").GetComponent<ProvisionManager>();
        }

        public override float Gather(float amount)
        {
            if (value - amount <= 0.0f)
            {
                float haul = value;
                value = 0.0f;
                provisionManager.suppliedFood -= haul;
                return haul;
            }
            Debug.Log("Woah, you just gatherered " + amount + " " + name + " " + value + " remaining.");
            value -= amount;
            provisionManager.suppliedFood -= amount;
            return amount;
        }
    }
}