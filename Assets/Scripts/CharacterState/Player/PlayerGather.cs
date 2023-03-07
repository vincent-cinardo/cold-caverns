using UnityEngine;
using Assets.Scripts.CharacterState.Control;

namespace Assets.Scripts.CharacterState.Player
{
    class PlayerGather : PlayerState
    {
        public PlayerGather(PlayerController handler) : base(handler)
        {
            //animator.Play("Gather");
            Debug.Log("Gather");
        }
        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                handler.state = new PlayerIdle(handler);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                handler.state = new PlayerWindup(handler, 0.5f);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                handler.state = new PlayerRoll(handler);
            }

            Vector2 vec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (vec != Vector2.zero)
            {
                handler.state = new PlayerMove(handler);
            }

            /*
             Check if you have a container that can store the resource in question.
             You do? Return value of gather, add it to container that has space.
             IE fill your waterskin.

            Take this return value and add it to your inventory.
             */
            
            handler.nearbyInteractables[0].Gather(Time.deltaTime);
        }
    }
}
