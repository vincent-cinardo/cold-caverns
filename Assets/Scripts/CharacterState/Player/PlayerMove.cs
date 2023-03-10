using UnityEngine;
using Assets.Scripts.CharacterState.Control;

namespace Assets.Scripts.CharacterState.Player
{
    class PlayerMove : PlayerState
    {
        public PlayerMove(PlayerController handler) : base(handler)
        {
            animator.Play("Walk");
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

            }

            float speed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 5.0f;
            }
            else speed = 3.0f;
            rigidbody.velocity = new Vector3(
                Input.GetAxisRaw("Horizontal") * speed,
                Input.GetAxisRaw("Vertical") * speed,
                0.0f
            );
            Vector2 vec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (vec != Vector2.zero)
            {
                float angle = Mathf.Rad2Deg * Mathf.Atan2(vec.y, vec.x);
                transform.rotation = Quaternion.Euler(-angle, 90.0f, -90.0f);
            }
            else handler.state = new PlayerIdle(handler);
        }
    }
}