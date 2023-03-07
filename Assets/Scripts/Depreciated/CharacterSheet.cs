using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSheet : MonoBehaviour
{
	public float hp;
	public float maxHP;
	//public Equipment equipment;

    //Attributes
    public float strength, agility, speed, constitution, intelligence, charisma;
	public enum ATTRIBUTE {
		STRENGTH, AGILITY, SPEED, CONSTITUTION, INTELLIGENCE, CHARISMA
	}

    //Skills
    public float sword, axe, hammer, polearm, crossbow,bow, throwing, smithing,
        bowyery, alchemy, mining, farming, lumberjacking;

    //Statistics
	//Make readonly
    public float weight, carryWeightCurrent, carryWeightMax, dodgeChance, blockChance, 
        fallChance, hitChance, walkSpeed, maxSpeed, damageTakenMultiplier,
        stamina, maxStamina, craftingSpeed, learningRate, craftingEffectiveness;

    // Start is called before the first frame update
    void Start()
    {
		SetAttribute(ATTRIBUTE.STRENGTH, 100.0f);
		SetAttribute(ATTRIBUTE.AGILITY, 100.0f);
		SetAttribute(ATTRIBUTE.SPEED, 100.0f);
		SetAttribute(ATTRIBUTE.CONSTITUTION, 100.0f);
		SetAttribute(ATTRIBUTE.INTELLIGENCE, 100.0f);
		SetAttribute(ATTRIBUTE.CHARISMA, 100.0f);
		//equipment = GetComponent<Equipment>();
		hp = 100.0f;
		maxHP = 100.0f;
		sword = 100.0f; axe = 100.0f; hammer = 100.0f; polearm = 100.0f;
		crossbow = 100.0f; bow = 100.0f; throwing = 100.0f; smithing = 100.0f;
		bowyery = 100.0f; alchemy = 100.0f; mining = 100.0f; farming = 100.0f; 
		lumberjacking = 100.0f;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void SetAttribute(ATTRIBUTE attribute, float value)
	{
		switch (attribute)
		{
			case ATTRIBUTE.STRENGTH:
				strength = value;
				carryWeightMax = value * 2.0f;
				break;
			case ATTRIBUTE.AGILITY:
				agility = value;
				dodgeChance = value * 0.5f;
				blockChance = value * 0.5f;
				fallChance = value * 0.5f;
				hitChance = value * 0.5f;
				break;
			case ATTRIBUTE.SPEED:
				speed = value;
				maxSpeed = value * 0.26f;
				walkSpeed = value * 0.1f;
				break;
			case ATTRIBUTE.CONSTITUTION:
				constitution = value;
				damageTakenMultiplier = value * 0.1f;
				maxStamina = value * 2.0f;
				break;
			case ATTRIBUTE.INTELLIGENCE:
				intelligence = value;
				learningRate = value / 100.0f;
				craftingSpeed = value * 0.5f;
				craftingEffectiveness = value * 0.5f;
				break;
			case ATTRIBUTE.CHARISMA:
				charisma = value;
				break;
		}
	}

	void ChangeAttribute(ATTRIBUTE attribute, float value)
	{
		switch (attribute)
		{
			case ATTRIBUTE.STRENGTH:
				strength += value;
				carryWeightMax += value * 2.0f;
				break;
			case ATTRIBUTE.AGILITY:
				agility += value;
				dodgeChance += value * 0.5f;
				blockChance += value * 0.5f;
				fallChance += value * 0.5f;
				hitChance += value * 0.5f;
				break;
			case ATTRIBUTE.SPEED:
				speed += value;
				maxSpeed += value * 0.26f;
				walkSpeed += value * 0.1f;
				break;
			case ATTRIBUTE.CONSTITUTION:
				constitution += value;
				damageTakenMultiplier += value * 0.1f;
				maxStamina += value * 2.0f;
				break;
			case ATTRIBUTE.INTELLIGENCE:
				intelligence += value;
				learningRate += value / 100.0f;
				craftingSpeed += value * 0.5f;
				craftingEffectiveness += value * 0.5f;
				break;
			case ATTRIBUTE.CHARISMA:
				charisma += value;
				break;
		}
	}

	public void Hurt(float value)
	{
		//if (equipment != null)
		//{ 
			
		//}

		hp = hp - value <= 0.0f ? 0.0f : hp - value;
		Debug.Log(gameObject.name + " was hit for " + value);
	}
}