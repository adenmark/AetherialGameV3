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
        if (trigger.gameObject.tag == "EnemyChase")
        {
            trigger.gameObject.GetComponent<EnemyChase>().Damage();
            Die();
        }
        if (trigger.gameObject.tag == "EnemyProximity")
        {
            trigger.gameObject.GetComponent<EnemyProximity>().Damage();
            Die();
        }
        if (trigger.gameObject.tag == "Spawner")
        {
            trigger.gameObject.GetComponent<SpawnObjectScript>().Damage();
            Die();
        }
        if (trigger.gameObject.tag == "EnemyTurret")
        {
            trigger.gameObject.GetComponent<TurretBodyScript>().Damage();
            Die();
        }
        if (trigger.gameObject.tag == "Scenery")
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

