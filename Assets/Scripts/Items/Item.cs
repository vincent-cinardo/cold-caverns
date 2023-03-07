using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Item
    {
        public float weight;
        public string name;
        public virtual float width { get; set; }
        public virtual float height { get; set; }
        public virtual float volume { get; set; }

        public Item() { }
        public Item(string name, float weight)
        {
            this.name = name;
            this.weight = weight;
        }
        public Item(string name, float weight, float width, float height)
        {
            this.name = name;
            this.weight = weight;
            this.width = width;
            this.height = height;

        }
        public Item(string name, float weight, float volume)
        {
            this.name = name;
            this.weight = weight;
            this.volume = volume;

        }
    }
}