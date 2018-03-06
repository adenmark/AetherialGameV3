using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarpoonScript : MonoBehaviour
{

	void Start ()
    {

    }
	
	void Update ()
    {

    }


    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Enemy"))
        {
            trigger.GetComponent<HealthScript>().Damage();
            Destroy(gameObject);
        }
        if (trigger.CompareTag("Scenery"))
        {
            Destroy(gameObject);
        }
    }
}

