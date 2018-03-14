using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NukeScript : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;

    public GameObject NukeExplosionParticle;

    [Header("Nuke Attributes")]

    public float nukeSpeed;
    public float rotateSpeed;

    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Boss").transform;
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
            rb.velocity = transform.up * nukeSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(NukeExplosionParticle, transform.position, transform.rotation);
    }
}
