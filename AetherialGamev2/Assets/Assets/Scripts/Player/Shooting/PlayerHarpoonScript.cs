using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarpoonScript : MonoBehaviour
{
    public GameObject HarpoonParticle;

    public float HarpoonPierce;
    private float HarpoonCounter = 0;

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
            HarpoonCounter++;
            if (HarpoonCounter >= HarpoonPierce)
            {
                Destroy(gameObject);
            }
        }
        if (trigger.CompareTag("Scenery"))
        {
            Destroy(gameObject);
        }
        if (trigger.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(HarpoonParticle, transform.position, Quaternion.identity);
    }
}

