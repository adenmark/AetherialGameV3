using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBodyScript : MonoBehaviour
{

    //public Transform player;

    public float health;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
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
