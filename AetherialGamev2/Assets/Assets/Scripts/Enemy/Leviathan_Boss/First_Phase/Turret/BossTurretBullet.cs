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
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
    }
}
