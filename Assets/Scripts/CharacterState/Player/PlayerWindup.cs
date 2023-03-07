using UnityEngine;
using Assets.Scripts.CharacterState.Control;

namespace Assets.Scripts.CharacterState.Player
{
    public class PlayerWindup : PlayerState
    {
        private float windupTime;
        public PlayerWindup(PlayerController handler, float windupTime) : base(handler) 
        {
            this.windupTime = windupTime;
            Debug.Log("Windup");
        }

        public override void Update()
        {
            //Block should be the only thing to interupt here, blocking state;

            if (windupTime <= 0)
            {
                handler.state = new PlayerMove(handler);
                return;
            }

            windupTime -= Time.deltaTime;
        }
    }
}
