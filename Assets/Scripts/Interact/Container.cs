using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Items;

namespace Assets.Scripts.Interact
{
    /// <summary>
    /// Defined as an object within an item that can store other items (clothes, backpacks, and so on).
    /// </summary>
   public class Container : Interactable
   {
        public List<Item> items;
        float maxVolume;
        float volume;
        bool storesWater;

        void Start()
        {
            base.Start();
            items = new List<Item>();
            items.Add(new Clothing("Jeans", 10.0f, 1.0f, 1.0f, 10.0f));
            name = "container";
            message = "Open";
        }

        public Container(float maxVolume, bool storesWater)
        {
            items = new List<Item>();
            volume = 0.0f;
            this.maxVolume = maxVolume;
            this.storesWater = storesWater;
            items = new List<Item>();
        }
        public void Store(Item item)
        {
            float newVolume = volume + item.volume;
            if (newVolume <= maxVolume)
                items.Add(item);
            else Debug.Log("NOT ENOUGH SPACE");
        }

        public override void Interact()
        { 
            //Opens inventory.
        }

        public override void Take(Item item)
        {
            //For now only takes the first item in a list of items.
            //In future, pressing E in Idle or move will open a menu.
            if (items.Count > 0)
            {
                item = items[0];
                Debug.Log("Removed " + item);
                items.RemoveAt(0);
            }
            else Debug.Log("This storage is empty.");
        }
        public List<Item> GetItems()
        {
            return items;
        }
    }
}