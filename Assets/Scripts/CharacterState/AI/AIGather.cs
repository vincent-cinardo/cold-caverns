using UnityEngine;
using Assets.Scripts.Interact;
using Assets.Scripts.Interact.ResourceNodes;

namespace Assets.Scripts.CharacterState.AI
{
    public class AIGather : AIState
    {
        private bool playing;
        private float gatherLength;
        public AIGather(AIController handler) : base(handler)
        {
            animator.Play("Idle");
            playing = false;
            gatherLength = 2.0f;
        }
        public override void Update()
        {
            if (!playing)
            {
                playing = true;
                animator.Play("Idle");
            }

            if (gatherLength <= 0.0f)
            {
                foreach (ResourceNode resources in handler.nearbyResources)
                {
                    Debug.Log(resources.type);
                    switch (resources.type)
                    {
                        //Gather an amount you can fit. Instead of 100...
                        case Interactable.TYPE.FUEL:
                            needs.Warm(resources.Gather(100.0f - needs.warmth));
                            break;
                        case Interactable.TYPE.WATER:
                            needs.Drink(resources.Gather(100.0f - needs.water));
                            break;
                        case Interactable.TYPE.FOOD:
                            needs.Eat(resources.Gather(100.0f - needs.food));
                            break;
                    }
                }
                handler.state = new AIAssess(handler);
            }
            gatherLength -= Time.deltaTime;
        }
    }
}