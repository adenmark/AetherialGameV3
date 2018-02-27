using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosionScript : MonoBehaviour {

    public float timeToDestroy;

    void Start()
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
        if (collision.CompareTag ("Player"))
        {
            collision.GetComponent<PlayerScript>().Damage();
        }
        if (collision.CompareTag ("Enemy"))
        {
            collision.GetComponent<HealthScript>().Damage();
        }
    }
}
