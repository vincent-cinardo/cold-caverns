using UnityEngine;
using Assets.Scripts.CharacterState.Control; 

namespace Assets.Scripts.CharacterState.Player
{
    public class PlayerIdle : PlayerState
    {
        public PlayerIdle(PlayerController handler) : base(handler)
        { 
            animator.Play("Idle");
            Debug.Log("Idle");
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                handler.state = new PlayerWindup(handler, 0.5f);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                handler.state = new PlayerRoll(handler);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                int count = handler.nearbyInteractables.Count;
                if (count == 1)
                {
                    //Interact directly
                }
                else if (count > 1)
                { 
                    //Open the listManager, the list of interactables.
                }
            }

            Vector2 vec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (vec != Vector2.zero)
            {
                handler.state = new PlayerMove(handler);
            }
        }
    }
}
