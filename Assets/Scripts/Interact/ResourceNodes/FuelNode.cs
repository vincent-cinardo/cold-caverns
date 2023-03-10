using UnityEngine;
using Assets.Scripts.Survival;

namespace Assets.Scripts.Interact.ResourceNodes
{
    public class FuelNode : ResourceNode
    {
        // Start is called before the first frame update
        void Start()
        {
            base.Start();
            value = 100.0f;
            type = TYPE.FUEL;
            name = "Fuel";
            message = "Gather " + name;
            provisionManager = GameObject.Find("GameManager").GetComponent<ProvisionManager>();
        }
        public override float Gather(float amount)
        {
            if (value - amount <= 0.0f)
            {
                float haul = value;
                value = 0.0f;
                provisionManager.suppliedFuel -= haul;
                return haul;
            }
            Debug.Log("Woah, you just gatherered " + amount + " " + name + " " + value + " remaining.");
            value -= amount;
            provisionManager.suppliedFuel -= amount;
            return amount;
        }
    }
}