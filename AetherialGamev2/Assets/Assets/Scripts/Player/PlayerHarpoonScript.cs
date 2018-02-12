using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarpoonScript : MonoBehaviour
{
    Rigidbody2D rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyChase")
        {
            collision.gameObject.GetComponent<EnemyChase>().Damage();
            Die();
        }
        if (collision.gameObject.tag == "EnemyProximity")
        {
            collision.gameObject.GetComponent<EnemyProximity>().Damage();
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
