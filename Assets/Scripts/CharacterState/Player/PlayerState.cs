using UnityEngine;
using Assets.Scripts.Survival;
using Assets.Scripts.CharacterState.Control;

namespace Assets.Scripts.CharacterState.Player
{
    public class PlayerState : CharacterState
    {
        public PlayerController handler;
        public PlayerState(PlayerController handler)
        {
            this.handler = handler;
            transform = handler.transform;
            sheet = handler.gameObject.GetComponent<CharacterSheet>();
            animator = handler.gameObject.GetComponent<Animator>();
            rigidbody = handler.gameObject.GetComponent<Rigidbody>();
            needs = handler.gameObject.GetComponent<Needs>();
        }
        public virtual void Update() { }
    }
}
