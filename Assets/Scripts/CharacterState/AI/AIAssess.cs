using UnityEngine;
using Assets.Scripts.Survival;

namespace Assets.Scripts.CharacterState.AI
{
    class AIAssess : AIState
    {
        public AIAssess(AIController handler) : base(handler) { }
        public override void Update()
        {
            //animator.Play("Gather");
            if (needs.warmth <= 20.0f)
            {
                if (handler.fuelNode == null)
                {
                    handler.fuelNode = handler.provisionManager.ClosestFuel(transform.position);
                }

                handler.state = new AIGoTo(handler, handler.fuelNode.mapTile, true);
                handler.stateQueue.Enqueue(new AIGather(handler));
                
                //Go back home to stove.
                //handler.stateQueue.Enqueue(new AIGoTo(handler, handler));
                
                //Is there a decent amount of fuel in your stove?
                //Yes: Go home.
                //No: Is there fuel outside?.
                //Yes: Get fuel.
                //No: Break in, warm up, take fuel.
            }

            if (needs.water <= 20.0f)
            {
                if (handler.waterNode == null)
                {
                    handler.waterNode = handler.provisionManager.ClosestWater(transform.position);
                }

                handler.state = new AIGoTo(handler, handler.waterNode.mapTile, true);
                handler.stateQueue.Enqueue(new AIGather(handler));
                //Water on you? Drink.
                //Is there a decent amount of water at home?
                //Yes: Go home.
                //No: Is there water outside?.
                //Yes: Get water.
                //No: Break in, drink, fill water and take home.
            }

            if (needs.food <= 20.0f)
            {
                if (handler.foodNode == null)
                {
                    handler.foodNode = handler.provisionManager.ClosestFood(transform.position);
                }

                handler.state = new AIGoTo(handler, handler.foodNode.mapTile, false);
                handler.stateQueue.Enqueue(new AIGather(handler));
                //Food on you? Eat.
                //Is there a decent amount of water at home?
                //Yes: Go home, eat and take some.
                //No: Is there water outside?.
                //Yes: Get food.
                //No: Break in, eat, grab food and take home.
            }

            //Go and socialize at the gathering spot
        }
    }
}
