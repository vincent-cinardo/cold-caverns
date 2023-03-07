using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeBehind : MonoBehaviour
{
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Color color = renderer.material.color;
            color.a = 0.5f;
            renderer.material.color = color;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Color color = renderer.material.color;
            color.a = 1.0f;
            renderer.material.color = color;
        }
    }
}
