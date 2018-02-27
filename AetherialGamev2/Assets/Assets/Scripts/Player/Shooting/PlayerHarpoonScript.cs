using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarpoonScript : MonoBehaviour
{
    public GameObject Turret;

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
            Die();
        }
        if (trigger.CompareTag("Scenery"))
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

