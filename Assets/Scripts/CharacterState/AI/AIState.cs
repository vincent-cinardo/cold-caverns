using UnityEngine;
using Assets.Scripts.Survival;

namespace Assets.Scripts.CharacterState.AI
{
    public class AIState : CharacterState
    {
        public AIController handler;
        public AIState(AIController handler)
        {
            this.handler = handler;
            transform = handler.transform;
            sheet = handler.gameObject.GetComponent<CharacterSheet>();
            animator = handler.gameObject.GetComponent<Animator>();
            rigidbody = handler.gameObject.GetComponent<Rigidbody>();
            needs = handler.gameObject.GetComponent<Needs>();
        }
    }
}
