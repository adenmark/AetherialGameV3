using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().Damage();
            Die();
        }
        if (collision.CompareTag("Scenery"))
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
