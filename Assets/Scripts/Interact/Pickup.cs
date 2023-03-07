using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Items;

namespace Assets.Scripts.Interact
{
    /// <summary>
    /// A pickup is a component of GameObject that holds a dropped item. It simply holds an Item.
    /// </summary>
    class Pickup : Interactable
    {
        Item item;
        public Pickup(Item item)
        {
            this.item = item;
        }

        void Start()
        {
            base.Start();
            Debug.Log("Pickups work");
            item = new Clothing("Jeans", 1, 1, 1, 1);
            type = TYPE.PICKUP;
            controller = GameObject.Find("Player").GetComponent<Controller>();
            message = "Take " + item.name;
        }

        public override void Interact()
        {
            //try to add this item to inventory, space permitting.
            controller.equipment.Store(item);
            controller.nearbyInteractables.Remove(this);
            actionListManager.RemoveAction(this);
            Destroy(gameObject);
        }

        public override void Take(Item item)
        {
            item = this.item;
            controller.nearbyInteractables.Remove(this);
            actionListManager.RemoveAction(this);
            Destroy(gameObject);
        }
    }
}
