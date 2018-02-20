using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    //Rigidbody2D rb;

    public Transform player;

    public float speed;
    public float health;

    public GameObject explosion;

    void Start ()
    {
        //rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }
	
	void Update ()
    {
        if(player != null) // Temporary Fix
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().Damage();
            Instantiate(explosion, transform.position, Quaternion.identity);
            Die();
        }
    }

    public void Damage()
    {
        health--;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
