using System;
using System.Collections;
using System.Collections.Generic;
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
            warmth = 100.0f;
            water = 100.0f;
            food = 100.0f;
            freezeRate = 0.5f;
            thirstRate = 0.2f;
            starveRate = 0.1f;
            provisionManager = GameObject.Find("GameManager").GetComponent<ProvisionManager>();
            provisionManager.collectiveWarmth += warmth;
            provisionManager.collectiveWater += water;
            provisionManager.collectiveFood += food;
            provisionManager.maxFood += food;
            provisionManager.maxWater += water;
            provisionManager.maxFuel += warmth;
        }

        private void FixedUpdate()
        {
            float warmthLoss = freezeRate * Time.deltaTime;
            float waterLoss = thirstRate * Time.deltaTime;
            float foodLoss = starveRate * Time.deltaTime;

            warmth -= warmthLoss;
            water -= waterLoss;
            food -=  foodLoss;
            provisionManager.collectiveWarmth -= warmthLoss;
            provisionManager.collectiveWater -= waterLoss;
            provisionManager.collectiveFood -= foodLoss;

            if (warmth <= 0.0f)
            {
                //Die
                Debug.Log("Died of the cold.");
            }

            if (water <= 0.0f)
            {
                Debug.Log("Died of thirst.");
            }

            if (food <= 0.0f)
            {
                Debug.Log(gameObject.name + " died of hunger.");
            }
        }
    }
}
