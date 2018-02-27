using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;

    public float speed;
    public float health;

    public GameObject explosion;
    public GameObject explosionEffect;

    void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
	
	void Update ()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
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
    }
}
