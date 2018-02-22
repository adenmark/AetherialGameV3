using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public Transform target;
    public float range;

	void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

    void UpdateTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
    }
	
	void Update ()
    {
		
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
