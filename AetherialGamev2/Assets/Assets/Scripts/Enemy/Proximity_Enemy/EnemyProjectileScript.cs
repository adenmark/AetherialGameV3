using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{

    void Start ()
    {

	}

    void Update()
    {
        

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().Damage();
            Die();
        }
        if (collision.gameObject.tag == "Scenery")
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}