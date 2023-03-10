using UnityEngine;
using Assets.Scripts.Survival;
using Assets.Scripts.Interact;
using System.Collections.Generic;
using Assets.Scripts.CharacterState.AI;
using Assets.Scripts.Interact.ResourceNodes;

namespace Assets.Scripts.CharacterState
{
    /// <summary>
    /// Use pushdown automatata for AI decisionmaking.
    /// </summary>
    public class AIController : Controller
    {
        public ProvisionManager provisionManager;
        public FuelNode fuelNode;
        public WaterNode waterNode;
        public FoodNode foodNode;
        public Queue<AIState> stateQueue;
        public AIState state;
        
        // Start is called before the first frame update
        void Start()
        {
            state = new AIAssess(this);
            stateQueue = new Queue<AIState>();
            nearbyInteractables = new List<Interactable>();
            equipment = new Equipment(30.0f);
            provisionManager = GameObject.Find("GameManager").GetComponent<ProvisionManager>();
            //fuelNode = GameObject.Find("Fuel").GetComponent<FuelNode>();
            //waterNode = GameObject.Find("Water").GetComponent<WaterNode>();
            //foodNode = GameObject.Find("Food").GetComponent<FoodNode>();
        }

        // Update is called once per frame
        void Update()
        {
            state.Update();
        }
    }

}
