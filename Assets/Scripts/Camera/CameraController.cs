using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Camera camera;

    void Start()
    {
        camera = gameObject.GetComponent<Camera>();   
    }

    // Update is called once per frame
    void Update()
    {
        camera.orthographicSize += Input.mouseScrollDelta.y * Time.deltaTime * 10.0f;
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y - 8.0f, transform.position.z);
    }
}
