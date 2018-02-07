using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovementScript : MonoBehaviour
{
    public float speed = 5f;        //Speed at which the Cannon turns

    private void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;       // Direction between our position and target position, since mouse we use ScreenToWorldPoint
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;                                // Calculate the Angle
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);                                 // Create a roation from the Angle
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);        // Begin the rotation according to the speed
    }
}
