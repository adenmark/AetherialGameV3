using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGunScript : MonoBehaviour
{
    public float speed;

    public Transform target;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
