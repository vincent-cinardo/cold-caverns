using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.CharacterState;
using Assets.Scripts.Interact;

public abstract class Controller : MonoBehaviour
{
    public List<Interactable> nearbyInteractables;
    public Equipment equipment;
}