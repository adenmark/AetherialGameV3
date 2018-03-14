using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NukeScript : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;

    public GameObject NukeExplosionParticle;
    public GameObject NukeSpeedUp;
    public GameObject NukeTrail;

    [Header("Nuke Attributes")]

    private float nukeSpeed = 0;
    public float rotateSpeed;
    private float NukeTimer = 0;

    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Boss").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * nukeSpeed;

        NukeTimer += Time.deltaTime;
        IncreaseSpeed();
    }

    public void IncreaseSpeed()
    {
        if (target != null)
        {
            if (NukeTimer == 1)
            {
                nukeSpeed += 10;
                Instantiate(NukeSpeedUp, transform.position, transform.rotation);
                Instantiate(NukeTrail, transform.position, transform.rotation);
            }
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
