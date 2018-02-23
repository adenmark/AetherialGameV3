using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBodyScript : MonoBehaviour
{
    public Transform target;
    public Transform rotatingGun;

    public float range;
    public float health;

    void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
    }

    void Update ()
    {

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().Damage();
        }
    }

    public void Damage()
    {
        health--;
        if (health == 0)
        {
            //Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
