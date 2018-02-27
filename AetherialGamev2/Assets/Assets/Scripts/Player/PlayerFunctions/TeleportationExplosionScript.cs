using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationExplosionScript : MonoBehaviour
{

    public float timeToDestroy;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        timeToDestroy -= Time.deltaTime;

        if (timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Enemy"))
        {
            trigger.GetComponent<HealthScript>().Damage();
        }
    }
}
