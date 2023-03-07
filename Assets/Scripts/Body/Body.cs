using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    protected float constitution;
    protected List<string> keys;
    protected Dictionary<string, BodyPart> parts;
    public void AttachPart(BodyPart bodyPart)
    {
        parts.Add(bodyPart.name, bodyPart);
        keys.Add(bodyPart.name);
    }

    public BodyPart GetPart(string part)
    {
        return parts[part];
    }
    public void DetachPart(string part)
    {
        parts.Remove(part);
        keys.Remove(part);
    }
    public void DamagePart(string part, float value)
    {
        parts[part].Damage(value);
    }

    public virtual void DamageRandomPart(float value)
    {
        int index = Random.Range(0, keys.Count - 1);
        parts[keys[index]].Damage(value);
    }

    public void HealPart(string part, float value)
    {
        parts[part].Heal(value);
    }
}
