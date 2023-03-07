using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Items
{
    /// <summary>
    /// Defined as an object within an item that can store other items (clothes, backpacks, and so on).
    /// </summary>
   class Container
   {
        List<Item> items;
        float maxVolume;
        float volume;
        bool storesWater;
        public Container(float maxVolume, bool storesWater)
        {
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
        public void Take(Item item)
        {
           //Might need to add more here
           //Comparable might need to be implemented
            if (items.Contains(item))
                items.Remove(item);
        }
        public List<Item> GetItems()
        {
            return items;
        }
    }
}
