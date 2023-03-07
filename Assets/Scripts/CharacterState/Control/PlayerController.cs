using System.Collections.Generic;
using Assets.Scripts.Interact;
using Assets.Scripts.CharacterState.Player;

namespace Assets.Scripts.CharacterState.Control
{
    public class PlayerController : Controller
    {
        public PlayerState state;
        void Start()
        {
            state = new PlayerIdle(this);
            nearbyInteractables = new List<Interactable>();
            equipment = new Equipment(30.0f);
        }

        void Update()
        {
            state.Update();
        }
    }
}