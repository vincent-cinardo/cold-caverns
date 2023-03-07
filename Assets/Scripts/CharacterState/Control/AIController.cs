using UnityEngine;
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
        public FuelNode fuelNode;
        public Queue<AIState> stateQueue;
        public AIState state;
        // Start is called before the first frame update
        void Start()
        {
            stateQueue = new Queue<AIState>();
            state = new AIAssess(this);
            nearbyInteractables = new List<Interactable>();
            equipment = new Equipment(30.0f);
            fuelNode = GameObject.Find("Fuel").GetComponent<FuelNode>();
        }

        // Update is called once per frame
        void Update()
        {
            state.Update();
        }
    }

}
