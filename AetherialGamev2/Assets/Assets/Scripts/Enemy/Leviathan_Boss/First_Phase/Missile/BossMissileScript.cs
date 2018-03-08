using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissileScript : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;

    public GameObject MissileExplosion;

    [Header("Missile Attributes")]

    public float missileSpeed;
    public float rotateSpeed;

    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = transform.up * missileSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerScript>().Damage();
            Destroy(gameObject);
        }
        if (collision.CompareTag("PlayerProjectile"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(MissileExplosion, transform.position, transform.rotation);
    }
}
