using UnityEngine;
using Assets.Scripts.CharacterState.Control;

namespace Assets.Scripts.CharacterState.Player
{
    public class PlayerRoll : PlayerState
    {
        float rollTime;
        public PlayerRoll(PlayerController handler) : base(handler)
        {
            animator.Play("Roll");
            //edit these values when you get a new roll animation
            float length = animator.GetCurrentAnimatorStateInfo(0).length;
            //Hardcoded! get the lenght of animation instead.
            //FIX THIS
            rollTime = 1.5f * 0.416f;
            animator.speed = 1.0f / rollTime;
            Debug.Log("Roll");

        }

        public override void Update()
        {

            if (rollTime <= 0.0f)
            {
                animator.speed = 1.0f;
                rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
                handler.state = new PlayerIdle(handler);
            }
            else
            {
                rollTime -= Time.deltaTime;

                Vector3 direction = transform.rotation * Vector3.forward;

                rigidbody.velocity = new Vector3(
                    direction.x * 5.0f,
                    direction.y * 5.0f,
                    0.0f
                );
            }
        }
    }
}
