using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraFollow : MonoBehaviour
{
    public Transform targetObject;

    public Vector3 cameraOffset;
    public float smoothFactor = 0.5f;
    public bool lookAtTarget = false;

    private float startingYPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Finds object with player tag
        targetObject = GameObject.FindWithTag("Player").transform;
        cameraOffset = transform.position - targetObject.transform.position;

        // Store the camera's starting y position
        startingYPosition = transform.position.y;
    }

    void LateUpdate()
    {
        // Follows object on the y and z axes, but stays at a fixed height
        Vector3 newPosition = new Vector3(transform.position.x, startingYPosition, targetObject.transform.position.z + cameraOffset.z);
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);

        if (lookAtTarget)
        {
            transform.LookAt(targetObject);
        }
    }
}
