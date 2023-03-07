using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBody : Body
{
    // Start is called before the first frame update
    void Start()
    {
        keys = new List<string>();
        parts = new Dictionary<string, BodyPart>();
        AttachPart(new BodyPart("head", 80.0f));
        AttachPart(new BodyPart("neck", 80.0f));
        AttachPart(new BodyPart("chest", 100.0f));
        AttachPart(new BodyPart("abdomen", 100.0f));
        AttachPart(new BodyPart("left arm", 100.0f));
        AttachPart(new BodyPart("left leg", 100.0f));
        AttachPart(new BodyPart("right arm", 100.0f));
        AttachPart(new BodyPart("right leg", 100.0f));
    }

    public override void DamageRandomPart(float value)
    {
        int index;
        if (Random.Range(0, 4) < 3)
        {
            index = Random.Range(0, 4);
        }
        else index = Random.Range(4, keys.Count-1);
        parts[keys[index]].Damage(value);
    }
}