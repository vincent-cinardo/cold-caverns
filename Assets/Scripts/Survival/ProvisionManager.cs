using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Survival
{
    public class ProvisionManager : MonoBehaviour
    {
        //Might need to add this component before initialize all the characters.
        //Then, check collective hunger every x seconds.
        public float collectiveWarmth, collectiveWater, collectiveFood;

        public float maxFood, maxWater, maxFuel;

        public float suppliedWarmth;
        public float suppliedWater;
        public float suppliedFood;

        //Time 
        public float eatTime, drinkTime, fuelTime;

        
        // Start is called before the first frame update
        void Start()
        {
            eatTime = 20.0f;
            drinkTime = 20.0f;
            fuelTime = 20.0f;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (collectiveWarmth <= maxFuel * 0.80 && fuelTime <= 0.0f)
            {
                //Sticks falling in event
            }
            fuelTime -= Time.deltaTime;

            if (collectiveWater <= maxWater * 0.80 && drinkTime <= 0.0f)
            {
                //Snow event;
            }
            drinkTime -= Time.deltaTime;

            if (collectiveFood <= maxFood * 0.80 && eatTime <= 0.0f)
            {
                //
            }
            eatTime -= Time.deltaTime;
        }
    }
}