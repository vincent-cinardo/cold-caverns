using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Items;
using UnityEngine;

public class Equipment
{
    Item leftHand;
    Item rightHand;
    Item gloves;
    Item headwear;
    Item topLayer0;
    Item topLayer1;
    Item legLayer0;
    Item legLayer1;
    Item socks0;
    Item socks1;
    Item footwear;
    Item backpack;

    public float currentLoad;
    public float maxCapacity;
    public List<Item> inventory;

    public Equipment(float maxCapacity)
    {
        inventory = new List<Item>();
        currentLoad = 0.0f;
        this.maxCapacity = maxCapacity;
    }

    public void Equip(Item item)
    {
        
    }
    public void Unequip(Item item)
    {
        
    }

    public void Store(Item item)
    {
        float newLoad = item.volume + currentLoad;
        if (newLoad <= maxCapacity)
        {
            inventory.Add(item);
            currentLoad = newLoad;
            Debug.Log("Added " + item.name + " to inventory.");
        }
        else 
        { 
            //Cant put into inventory
        }
    }


}
