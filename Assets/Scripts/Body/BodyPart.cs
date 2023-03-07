using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart
{
    public string name;
    public float health;
    public float maxHealth;
    public float protection = 0.0f;

    public BodyPart(string name, float maxHealth)
    {
        this.name = name;
        this.health = maxHealth;
        this.maxHealth = maxHealth;
    }
    public BodyPart(string name, float health, float maxHealth)
    {
        this.name = name;
        this.health = health;
        this.maxHealth = maxHealth;
    }
    public void Damage(float value)
    {
        health = health - value > 0.0f ? health - value : 0.0f;
        Debug.Log("Damaged " + name + " for " + value + ". Currently at " + health + " health.");
    }
    public void Heal(float value)
    {
        health = health + value < maxHealth ? health + value : maxHealth;
    }
}
