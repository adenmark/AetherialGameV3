using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;

    public float speed;

    public GameObject explosion;
    public GameObject explosionEffect;
    public GameObject deathEffect;

    void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
	
	void Update ()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else // Can be removed, just cute <3
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
    }
}
