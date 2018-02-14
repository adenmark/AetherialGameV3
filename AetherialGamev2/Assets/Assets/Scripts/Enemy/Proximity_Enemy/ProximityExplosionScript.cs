using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityExplosionScript : MonoBehaviour {

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
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().Damage();
        }
    }
}
