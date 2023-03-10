using UnityEngine;
using Assets.Scripts.Interact;

namespace Assets.Scripts.Survival
{
    public class Needs : MonoBehaviour
    {
        //Could probably just use this object as a variable in controller class.
        //Instead of an entire component.
        //Warmth rate should pull from the game manager/provision manager.
        public float warmth;
        public float water;
        //Need sleep...
        public float food;
        private float freezeRate;
        private float thirstRate;
        private float starveRate;

        public float fuelStored;
        public float waterStored;
        public float foodStored;

        public Stove stove;
        public Bed bed;
        public Container storage;
        public ProvisionManager provisionManager;


        void Start()
        {
            warmth = Random.Range(80.0f, 100.0f);
            water = Random.Range(80.0f, 100.0f);
            food = Random.Range(80.0f, 100.0f);
            freezeRate = 0.5f;
            thirstRate = 0.2f;
            starveRate = 0.1f;
            provisionManager = GameObject.Find("GameManager").GetComponent<ProvisionManager>();
            provisionManager.collectiveFuel += warmth;
            provisionManager.collectiveWater += water;
            provisionManager.collectiveFood += food;
        }

        private void FixedUpdate()
        {

            float warmthLoss = freezeRate * Time.deltaTime;
            float waterLoss = thirstRate * Time.deltaTime;
            float foodLoss = starveRate * Time.deltaTime;


            water -= waterLoss;
            food -= foodLoss;

            if (warmth <= 0.0f)
            {
                //Add back
                provisionManager.collectiveFuel -= waterLoss;
                warmth = 0.0f;
            }
            else
            {
                warmth -= warmthLoss;
                provisionManager.collectiveFuel -= waterLoss;
            }

            if (water <= 0.0f)
            {
                //Debug.Log("Died of thirst.");
                provisionManager.collectiveWater -= waterLoss;
                water -= 0.0f;
            }
            else
            {
                provisionManager.collectiveWater -= waterLoss;
                water -= waterLoss;
            }

            if (food <= 0.0f)
            {
                //Debug.Log(gameObject.name + " died of hunger.");
                provisionManager.collectiveFood -= foodLoss;
                food = 0.0f;
            }
            else
            {
                provisionManager.collectiveFood -= foodLoss;
                food -= foodLoss;
            }
        }

        //ADJUST THESE FUNCTIONS SO THEY ACCOUNT FOR warmth + amount  > 100...
        public void Warm(float amount)
        {
            warmth = warmth + amount > 100.0f ? 100 : warmth + amount;
            provisionManager.collectiveFuel += amount;
        }
        public void Drink(float amount)
        {
            water += amount;
            provisionManager.collectiveWater += amount;
        }
        public void Eat(float amount)
        {
            food += amount;
            provisionManager.collectiveFood += amount;
        }
    }
}