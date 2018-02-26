using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProximity : MonoBehaviour {

    private Vector3 fireTo;
    public GameObject projectile;
    public Transform target;

    [Header("Enemy Attributes")]

    public float health;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    [Header("Projectile Attribute")]

    private float fireCountdown;
    public float fireRate;
    public float projectileSpeed;

    void Start ()
    {
        target = GameObject.FindWithTag("Player").transform;
	}
	
	void Update ()
    {
        if (target != null) // Temporary Fix
        {
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            }
            else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            }

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
	}

    void Shoot()
    {
        Vector2 targetPosition = new Vector2(target.position.x, target.position.y);
        fireTo = new Vector3(targetPosition.x, targetPosition.y, 0f) - transform.position;

        GameObject Bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;

        Bullet.GetComponent<Rigidbody2D>().AddForce(fireTo.normalized * projectileSpeed);
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
