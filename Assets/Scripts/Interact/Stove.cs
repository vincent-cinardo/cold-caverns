using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Interact
{
    public class Stove : Interactable
    {
        public float fuel;
        float speed;
        //fuel per second.
        // Start is called before the first frame update
        void Start()
        {
            fuel = 20.0f;
            speed = 1.0f;
            name = "stove";
            message = "Refuel Stove";
        }

        // Update is called once per frame
        void Update()
        {
            fuel -= speed * Time.deltaTime;
        }
    }
}