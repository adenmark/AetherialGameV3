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
        if (trigger.gameObject.tag == "EnemyChase")
        {
            trigger.gameObject.GetComponent<EnemyChase>().Damage();
        }
        if (trigger.gameObject.tag == "EnemyProximity")
        {
            trigger.gameObject.GetComponent<EnemyProximity>().Damage();
        }
        if (trigger.gameObject.tag == "EnemyTurret")
        {
            trigger.gameObject.GetComponent<TurretBodyScript>().Damage();
        }
        if (trigger.gameObject.tag == "Spawner")
        {
            trigger.gameObject.GetComponent<SpawnObjectScript>().Damage();
        }
    }
}
