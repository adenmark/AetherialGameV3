using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NukeScript : MonoBehaviour
{
    public Transform target;
    public Transform firePoint;
    private Rigidbody2D rb;

    public GameObject NukeExplosionParticle;
    public GameObject NukeSpeedUp;

    [Header("Nuke Attributes")]

    private float nukeSpeed = 0;
    public float rotateSpeed;
    private float NukeTimer = 0;
    private float NukeCounter = 0;

    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Boss").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        IncreaseSpeed();
    }

    public void IncreaseSpeed()
    {
        NukeTimer += Time.deltaTime;
        if (target != null)
        {
            if (NukeTimer >= 2)
            {
                nukeSpeed += 3;
                NukeCounter++;
                if (NukeCounter == 1)
                {
                    Instantiate(NukeSpeedUp, firePoint.transform.position, transform.rotation);
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (target != null && NukeTimer >= 0)
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
