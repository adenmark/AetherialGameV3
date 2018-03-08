using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayerScript : MonoBehaviour
{
    public Transform player;

    public float smoothSpeed;   // Higher the value the faster it will look on (0-1)
    public Vector3 offset;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

        void FixedUpdate()
    {
        if (player != null) // Temporary Fix
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
