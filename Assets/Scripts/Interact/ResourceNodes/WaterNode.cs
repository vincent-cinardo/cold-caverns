using UnityEngine;

namespace Assets.Scripts.Interact.ResourceNodes
{
    public class WaterNode : ResourceNode
    {
        // Start is called before the first frame update
        void Start()
        {
            base.Start();
            value = 100.0f;
            type = TYPE.WATER;
            name = "Water";
            message = "Gather " + name;
        }
        public override float Gather(float amount)
        {
            if (value - amount <= 0.0f)
            {
                float haul = value;
                value = 0.0f;
                provisionManager.suppliedWater -= haul;
                return haul;
            }
            Debug.Log("Woah, you just gatherered " + amount + " " + name + " " + value + " remaining.");
            value -= amount;
            provisionManager.suppliedWater -= amount;
            return amount;
        }
    }
}