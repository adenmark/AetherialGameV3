using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour {

    //public Transform target;
    public Transform player;
    //public GameObject missileExplosion;

    [Header("Missile Attributes")]

    public float missileSpeed;
    public float rotateSpeed;
    public float missileRange;

    private Rigidbody2D rb;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
    {
        if (player != null)
        {
            Vector2 direction = (Vector2)player.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * missileSpeed;
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<HealthScript>().Damage();
            //Instantiate(missileExplosion, transform.up, transform.rotation);
            Destroy(gameObject);
        }
    }
}
