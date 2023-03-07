using UnityEngine;
using Assets.Scripts.Survival;

namespace Assets.Scripts.CharacterState
{
    public abstract class CharacterState
    {
        public Transform transform;
        public CharacterSheet sheet;
        public Animator animator;
        public Rigidbody rigidbody;
        public Needs needs;
        public virtual void Update() { }
    }
}
