using UnityEngine;

namespace Assets.Scripts.Interact.ResourceNodes
{
    public class FuelNode : Interactable
    {
        public float value;

        // Start is called before the first frame update
        void Start()
        {
            base.Start();
            value = 10.0f;
            name = "Fuel";
            message = "Gather " + name;
        }
        public override float Gather(float amount)
        {
            if (value - amount <= 0.0f)
            {
                float haul = value;
                value = 0.0f;
                return haul;
            }
            Debug.Log("Woah, you just gatherered " + amount + " " + name + " " + value + " remaining.");
            value -= amount;
            return amount;
        }
    }
}
