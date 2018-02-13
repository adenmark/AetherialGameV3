using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProximity : MonoBehaviour {

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject projectile;
    public Transform player;

    public float health;

    void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;

        timeBetweenShots = startTimeBetweenShots;
	}
	
	void Update ()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        } else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        } else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        } else
        {
            timeBetweenShots -= Time.deltaTime;
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().Damage();
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
