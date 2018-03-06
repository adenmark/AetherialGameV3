using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileDamageScript : MonoBehaviour
{
    public float timeToDestroy = 0.1f;

    void Start ()
    {
		
	}

    void Update()
    {
        timeToDestroy -= Time.deltaTime;

        if (timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<HealthScript>().Damage();
        }
    }
}
