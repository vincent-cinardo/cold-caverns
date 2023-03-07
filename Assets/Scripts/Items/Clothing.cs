using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Items
{
    class Clothing : Item
    {
        float maxDurability;
        float durability;
        float decayRate;
        float capacity;
        public Clothing(string name, float weight, float volume, float pocketsVolume, float durability) : base(name, weight, volume)
        {
            this.name = name;
            maxDurability = durability;
            this.durability = durability;
            capacity = pocketsVolume;
        }

        public void Decay(float amount)
        {
            durability -= amount;
            if (durability <= 0.0f)
            { 
                //Remove the clothing from the player model.
                //Destroy the clothing.
            }
        }
    }
}