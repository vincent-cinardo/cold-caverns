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
            needs = handler.gameObject.GetComponent<Needs>();
            animator = handler.gameObject.GetComponent<Animator>();
            rigidbody = handler.gameObject.GetComponent<Rigidbody>();
            sheet = handler.gameObject.GetComponent<CharacterSheet>();
        }
    }
}
