using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurretBullet : MonoBehaviour
{
    public GameObject destroyEffect;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().Damage();
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
    }
}
