using UnityEngine;
using Assets.Scripts.Interact;
using System.Collections.Generic;
using Assets.Scripts.Interact.ResourceNodes;

public abstract class Controller : MonoBehaviour
{
    public List<Interactable> nearbyInteractables;
    public List<ResourceNode> nearbyResources;
    public Equipment equipment;
}