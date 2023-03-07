using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalRotation : MonoBehaviour
{
    private Vector3 up;
    void Start()
    {
        up = new Vector3(0.0f, -90.0f, 30.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = up;
        Vector3 triangle = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        triangle = Camera.main.ScreenToWorldPoint(triangle);
        triangle = triangle - transform.position;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(triangle.y, triangle.x);
        transform.Rotate(0.0f, -angle, 0.0f, Space.Self);

        transform.position += new Vector3(
            Input.GetAxisRaw("Horizontal") * Time.deltaTime * 5.0f,
            Input.GetAxisRaw("Vertical") * Time.deltaTime * 5.0f,
            0.0f
        );
    }
}
