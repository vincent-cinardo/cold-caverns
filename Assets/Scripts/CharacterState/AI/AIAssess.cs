using UnityEngine;

namespace Assets.Scripts.CharacterState.AI
{
    class AIAssess : AIState
    {
        public AIAssess(AIController handler) : base(handler) {}

        public override void Update()
        {
            //animator.Play("Gather");
            if (needs.warmth <= 20.0f)
            {
                handler.state = new AIGoTo(handler, handler.fuelNode.mapTile);
                handler.stateQueue.Enqueue(new AIGather(handler));
                //Is there a decent amount of fuel in your stove?
                //Yes: Go home.
                //No: Is there fuel outside?.
                //Yes: Get fuel.
                //No: Break in, warm up, take fuel.
            }

            if (needs.food <= 20.0f)
            {
                //Food on you? Eat.
                //Is there a decent amount of water at home?
                //Yes: Go home, eat and take some.
                //No: Is there water outside?.
                //Yes: Get food.
                //No: Break in, eat, grab food and take home.
            }

            if (needs.water <= 20.0f)
            {
                //Water on you? Drink.
                //Is there a decent amount of water at home?
                //Yes: Go home.
                //No: Is there water outside?.
                //Yes: Get water.
                //No: Break in, drink, fill water and take home.
            }

            //Go and socialize at the gathering spot
        }
    }
}
